using System;
using System.Collections.Generic;
using System.IO;

namespace DevToolsAndReferenceAnalyzer.TfsBindingCleanerClasses
{
    /// <summary>
    /// Class that implements the TFS Migration Cleaner feature functionality.
    /// </summary>
    public sealed class TfsMigrationMethods
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TfsMigrationMethods"/> class.
        /// </summary>
        public TfsMigrationMethods()
        {
            SeriousIssues = string.Empty;
        }

        public string SeriousIssues { get; set; }

        /// <summary>
        /// Deletes the TFS related files for a Solution and related Projects.
        /// </summary>
        /// <param name="solutionFilePath">The solution file path.</param>
        /// <returns>A status string listing which files were removed.</returns>
        /// <exception cref="System.IO.FileNotFoundException">File Not Found Exception</exception>
        public string DeleteTfsRelatedFilesForSolutionAndRelatedProjects(string solutionFilePath)
        {
            #region Preconditions
            if (!File.Exists(solutionFilePath)) { throw new FileNotFoundException(solutionFilePath); }
            #endregion

            string fullSolutionPath = Path.GetFullPath(solutionFilePath);

            string solutionPath = Path.GetDirectoryName(fullSolutionPath);
            string solutionFileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullSolutionPath);

            string results = "Deleting Tfs Related Files for Solution: " + solutionFilePath + Environment.NewLine;
            results += "--------------------------------------------------------" + Environment.NewLine + Environment.NewLine;

            Environment.CurrentDirectory = solutionPath;

            results += DeleteTfsSolutionOrProjectFiles(solutionFileNameWithoutExtension, ".");

            Solution solution = new Solution(solutionFilePath);

            foreach (SolutionProject project in solution.Projects)
            {
                results += DeleteTfsSolutionOrProjectFiles(project.ProjectName, project.RelativePath);
            }

            return results + Environment.NewLine;
        }

        /// <summary>
        /// Removes the TFS project entries for all Project files in a Solution.
        /// </summary>
        /// <param name="solutionFilePath">The solution file path.</param>
        /// <returns>A status string listing which Project files were cleaned.</returns>
        /// <exception cref="System.IO.FileNotFoundException">File Not Found exception</exception>
        public string RemoveTfsProjectEntriesForAllProjectsInSolution(string solutionFilePath)
        {
            #region Preconditions
            if (!File.Exists(solutionFilePath)) { throw new FileNotFoundException(solutionFilePath); }
            #endregion

            string results = "Removing Tfs Related Project Entries for the Solution: " + solutionFilePath + Environment.NewLine;
            results += "--------------------------------------------------------" + Environment.NewLine + Environment.NewLine;

            string fullSolutionPath = Path.GetFullPath(solutionFilePath);

            string solutionPath = Path.GetDirectoryName(fullSolutionPath);
            string solutionFileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullSolutionPath);

            Environment.CurrentDirectory = solutionPath;

            Solution solution = new Solution(fullSolutionPath);

            foreach (SolutionProject project in solution.Projects)
            {
                results += RemoveTfsRelatedEntriesForProjectFile(project.RelativePath);
            }

            return results + Environment.NewLine;
        }

        /// <summary>
        /// Removes the TFS entries for a Solution file.
        /// </summary>
        /// <param name="solutionFilePath">The solution file path.</param>
        /// <returns>A status string noting that the Solution file has been cleaned.</returns>
        /// <exception cref="System.IO.FileNotFoundException">File Not Found exception.</exception>
        public string RemoveTfsEntriesForSolution(string solutionFilePath)
        {
            string solutionTfsVersionControlMatchStartString = "GlobalSection(TeamFoundationVersionControl) = preSolution";
            string solutionTfsVersionControlMatchEndString = "EndGlobalSection";

            #region Preconditions
            if (!File.Exists(solutionFilePath)) { throw new FileNotFoundException(solutionFilePath); }
            #endregion

            string results = "Removing Tfs Entries from Solution:  " + solutionFilePath + Environment.NewLine + Environment.NewLine;

            string fullSolutionPath = Path.GetFullPath(solutionFilePath);

            Environment.CurrentDirectory = Path.GetDirectoryName(fullSolutionPath);

            UtilityMethods.MakeFileWritable(fullSolutionPath);
            UtilityMethods.BackupFile(fullSolutionPath);

            TextReader reader = File.OpenText(fullSolutionPath);

            string line = reader.ReadLine();
            string newSolutionContents = string.Empty;
            bool insideTargetGlobalSection = false;

            while (line != null)
            {
                if (!insideTargetGlobalSection && line.Contains(solutionTfsVersionControlMatchStartString))
                {
                    insideTargetGlobalSection = true;
                }
                else if (insideTargetGlobalSection && line.Contains(solutionTfsVersionControlMatchEndString))
                {
                    insideTargetGlobalSection = false;
                }
                else if (!insideTargetGlobalSection)
                {
                    newSolutionContents += line + Environment.NewLine;
                }
                line = reader.ReadLine();
            }

            reader.Dispose();

            File.Delete(solutionFilePath);

            File.WriteAllText(solutionFilePath, newSolutionContents);

            return results;
        }

        /// <summary>
        /// Removes the TFS related entries for a specific Project file.
        /// </summary>
        /// <param name="relativePathWithFileName">Name of the relative path with file.</param>
        /// <returns>Status string noting that the Project file has been cleaned.</returns>
        private string RemoveTfsRelatedEntriesForProjectFile(string relativePathWithFileName)
        {
            string results = "Removing Tfs Related Entries in Project File:  " + relativePathWithFileName + Environment.NewLine;

            List<string> tfsEntryNames = new List<string>() { "SccProjectName", "SccLocalPath", "SccAuxPath", "SccProvider" };

            string projectFilePath = Path.GetFullPath(relativePathWithFileName);

            if (!File.Exists(projectFilePath))
            {
                SeriousIssues += " - PROJECT FILE COULD NOT BE FOUND, COULD BE AN EXTERNAL LIBRARY: " + projectFilePath + Environment.NewLine;
                return string.Empty;
            }

            UtilityMethods.MakeFileWritable(projectFilePath);

            TextReader reader = File.OpenText(projectFilePath);

            string newContents = string.Empty;
            string line = reader.ReadLine();

            while (line != null)
            {
                bool skipLine = false;

                foreach (string tfsEntry in tfsEntryNames)
                {
                    if (line.Contains(tfsEntry))
                    {
                        skipLine = true;
                        break;
                    }
                }

                if (!skipLine)
                {
                    newContents += line + Environment.NewLine;
                }
                line = reader.ReadLine();
            }

            reader.Dispose();

            UtilityMethods.BackupFile(projectFilePath);

            File.Delete(projectFilePath);

            File.WriteAllText(projectFilePath, newContents);

            return results;
        }

        /// <summary>
        /// Deletes the TFS related files from a Solution or Project directory.
        /// </summary>
        /// <param name="solutionOrProjectNameWithoutExtension">The solution or project name without extension.</param>
        /// <param name="relativePath">The relative path.</param>
        /// <returns>Status string noting that the files in a Solution or Project's directory have been deleted.</returns>
        private string DeleteTfsSolutionOrProjectFiles(string solutionOrProjectNameWithoutExtension, string relativePath)
        {
            string fullPath = Path.Combine(Environment.CurrentDirectory, relativePath);

            //string workingFolderPath = Path.GetDirectoryName(Path.GetFullPath(relativePath));
            string workingFolderPath = Path.GetDirectoryName(fullPath);

            string results = "Deleting TFS files for Solution/Project " + solutionOrProjectNameWithoutExtension + Environment.NewLine;
            results += "-------------------------------------------" + Environment.NewLine;

            List<string> tfsRelatedFiles = new List<string>() { "mssccprj.scc", ".vssscc", "vssver.scc", ".vbproj.vspscc", ".csproj.vspscc" };

            foreach (string relatedFileName in tfsRelatedFiles)
            {
                string fullRelatedFileName = relatedFileName;
                if (fullRelatedFileName.IndexOf('.') == 0)
                {
                    fullRelatedFileName = solutionOrProjectNameWithoutExtension + fullRelatedFileName;
                }

                string fullFilePath = Path.Combine(workingFolderPath, fullRelatedFileName);

                if (File.Exists(fullFilePath))
                {
                    UtilityMethods.MakeFileWritable(fullFilePath);

                    File.Delete(fullFilePath);

                    results += "Deleted File:  " + fullFilePath + Environment.NewLine;
                }
            }
            return results + Environment.NewLine;
        }
    }
}
