using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace DevToolsAndReferenceAnalyzer.ChangesetGrabberClasses
{
    /// <summary>
    /// Class that implements the Changeset Loader feature functionality.
    /// </summary>
    public class ChangesetGrabberMethods 
    {
        private VersionControlServer _versionControlServer = null;
        private TfsTeamProjectCollection _teamProjectCollection = null;
        private MergeCandidate[] _mergeCandidates = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangesetGrabberMethods"/> class.
        /// </summary>
        /// <param name="tfsServerUrl">The TFS server URL.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public ChangesetGrabberMethods(string tfsServerUrl, string userName, string password)
        {
            Uri tfsServerUri = new Uri(tfsServerUrl);

            if (!string.IsNullOrEmpty(userName))
            {
                NetworkCredential credentials = new NetworkCredential(userName, password);

                _teamProjectCollection = new TfsTeamProjectCollection(tfsServerUri, credentials);
            }
            else
            {
                _teamProjectCollection = new TfsTeamProjectCollection(tfsServerUri);
            }

            _versionControlServer = _teamProjectCollection.GetService<VersionControlServer>() as VersionControlServer;
        }

        /// <summary>
        /// Gets the difference changeset list between two TFS branches.
        /// </summary>
        /// <param name="sourceBranchUrl">The source branch URL.</param>
        /// <param name="targetBranchUrl">The target branch URL.</param>
        /// <returns>List of changesets.</returns>
        public List<Changeset> GetChangesetList(string sourceBranchUrl, string targetBranchUrl)
        {
            _mergeCandidates = _versionControlServer.GetMergeCandidates(sourceBranchUrl, targetBranchUrl, RecursionType.Full);

            _mergeCandidates = _mergeCandidates.OrderByDescending(c => c.Changeset.ChangesetId).ToArray();

            List<Changeset> changesets = (from mergeCandidate in _mergeCandidates
                                          select mergeCandidate.Changeset).OrderByDescending(c => c.ChangesetId).ToList();

            return changesets;
        }

        /// <summary>
        /// Gets the details about the item associated with a changeset.
        /// </summary>
        /// <param name="changesetUri">The changeset URI.</param>
        /// <returns>List of ChangeItemDetail objects.</returns>
        public List<ChangeItemDetails> GetChangeItemDetails(Uri changesetUri)
        {
            Changeset changeset = _versionControlServer.ArtifactProvider.GetChangeset(changesetUri);            

            List<ChangeItemDetails> changeItemDetailList = new List<ChangeItemDetails>();

            foreach (Change change in changeset.Changes)
            {
                var changeItemDetails = new ChangeItemDetails(change);

                changeItemDetailList.Add(changeItemDetails);
            }

            return changeItemDetailList;
        }

        /// <summary>
        /// Retrieves the changeset files from TFS, organizing them on the local file system in the same folder pattern as they are stored in TFS.
        /// </summary>
        /// <param name="changesetUri">The changeset URI.</param>
        /// <param name="basePath">The base path.</param>
        /// <param name="replaceExistingFiles">if set to <c>true</c> [replace existing files].</param>
        /// <param name="backupExistingFiles">if set to <c>true</c> [backup existing files].</param>
        public void RetrieveChangesetFilesFromTfs(Uri changesetUri, string basePath, bool replaceExistingFiles, bool backupExistingFiles)
        {
            string fullPath = Path.GetFullPath(basePath);

            Changeset changeset = _versionControlServer.ArtifactProvider.GetChangeset(changesetUri);

            List<ChangeItemDetails> changeItemDetails = GetChangeItemDetails(changesetUri);

            CreateOrValidateChangeSetStructureAndFiles(fullPath, changeItemDetails, replaceExistingFiles);

            LoadChangesetFilesToFileSystem(fullPath, changeset, backupExistingFiles);
        }

        /// <summary>
        /// Creates the folder structure for all items in a TFS changeset (if it doesn't already exist), and validates that target files either don't exist (if no replacing existing files) or that they are writable.
        /// </summary>
        /// <param name="basePath">The base path.</param>
        /// <param name="changeItemDetails">The change item details.</param>
        /// <param name="replaceExistingFiles">if set to <c>true</c> [replace existing files].</param>
        /// <exception cref="System.IO.IOException">
        /// File exists, but configuration was set to not replace existing files:  + completePathWithFileName
        /// or
        /// File is read only, check out or make writable:  + completePathWithFileName
        /// </exception>
        private void CreateOrValidateChangeSetStructureAndFiles(string basePath, List<ChangeItemDetails> changeItemDetails, bool replaceExistingFiles)
        {
            foreach (ChangeItemDetails details in changeItemDetails)
            {
                if (details.ItemType == "File")
                {
                    string partialPath = details.ServerItem.Substring(2); // trim off the "$/" from the front

                    string partialPathWithoutFileName = Path.GetDirectoryName(partialPath);

                    string completePathWithFileName = Path.Combine(basePath, partialPath);

                    List<string> folders = partialPathWithoutFileName.Split('\\').ToList();

                    string currentPath = basePath;

                    // create the folder structure if neeeded
                    foreach (string folder in folders)
                    {
                        string pathToCheckOrCreate = Path.Combine(currentPath, folder);

                        if (!Directory.Exists(pathToCheckOrCreate))
                        {
                            Directory.CreateDirectory(pathToCheckOrCreate);
                        }
                        currentPath = pathToCheckOrCreate;
                    }

                    // check for an existing file, ensure that it is not readonly
                    if (File.Exists(completePathWithFileName))
                    {
                        if (!replaceExistingFiles)
                        {
                            throw new IOException("File exists, but configuration was set to not replace existing files: " + completePathWithFileName);
                        }

                        if (UtilityMethods.IsFileReadOnly(completePathWithFileName))
                        {
                            throw new IOException("File is read only, check out or make writable: " + completePathWithFileName);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Loads the changeset files to file system.
        /// </summary>
        /// <param name="basePath">The base path.</param>
        /// <param name="changeset">The changeset.</param>
        /// <param name="backupExistingFiles">if set to <c>true</c> [backup existing files].</param>
        private void LoadChangesetFilesToFileSystem(string basePath, Changeset changeset, bool backupExistingFiles)
        {
            foreach (Change change in changeset.Changes)
            {
                string partialPath = change.Item.ServerItem.Substring(2); // trim off the "$/" from the front             

                string completePathWithFileName = Path.Combine(basePath, partialPath);

                if (File.Exists(completePathWithFileName))
                {
                    if (backupExistingFiles)
                    {
                        UtilityMethods.BackupFile(completePathWithFileName);
                    }

                    File.Delete(completePathWithFileName);
                }

                change.Item.DownloadFile(completePathWithFileName);

                UtilityMethods.MakeFileWritable(completePathWithFileName);
            }

        }   
    }
}
