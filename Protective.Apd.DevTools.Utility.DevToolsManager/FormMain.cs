using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.TeamFoundation.VersionControl.Client;
using DevToolsAndReferenceAnalyzer.TfsBindingCleanerClasses;
using DevToolsAndReferenceAnalyzer.SolutionReferenceAnalysisClasses;
using DevToolsAndReferenceAnalyzer.ChangesetGrabberClasses;

namespace DevToolsAndReferenceAnalyzer
{
    /// <summary>
    /// Class that is the main form for the application.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class FormMain : Form
    {
        #region Fields (private)

        private Color STATUS_BAR_ACTIVE_COLOR = Color.LightGreen;
        private Color STATUS_BAR_INACTIVE_COLOR = SystemColors.Control;

        private List<ProjectReferenceInfo> _referenceAnalysisProjectReferenceInfoList = new List<ProjectReferenceInfo>();

        private ChangesetGrabberMethods _changesetGrabber = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain"/> class.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            ChangesetGrabberTextTfsUrl.Text = Properties.Settings.Default.changeSetTfsUrl;
            ChangesetGrabberTextDomainAndUsername.Text = Properties.Settings.Default.changeSetUserName;
            ChangesetGrabberTextSourceBranch.Text = Properties.Settings.Default.changeSetSourceBranch;
            ChangesetGrabberTextTargetBranch.Text = Properties.Settings.Default.changeSetTargetBranch;
            ChangesetGrabberTextSaveToFolder.Text = Properties.Settings.Default.changeSetSavePath;
        }

        #endregion

        #region Methods - Tfs Solution Cleaner

        private void TfsMigrationButtonSelectSolutionFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openSolutionFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                TfsCleanerTextSolutionFile.Text = openSolutionFileDialog.FileName;
            }
        }

        private void TfsMigrationButtonProcess_Click(object sender, EventArgs e)
        {
            #region Preconditions
            if (string.IsNullOrEmpty(TfsCleanerTextSolutionFile.Text))
            {
                MessageBox.Show("Please select a solution file...");
                return;
            }
            if (string.IsNullOrEmpty(TfsMigrationTextSolutionBackupFolder.Text))
            {
                MessageBox.Show("Please select a solution backup folder...");
                return;
            }
            #endregion

            string warningMessage = @"Warning: 
 - This process starts by making a complete backup of the Solution 
     to the Solution Backup Folder.

 - This process will delete files associated with TFS bindings, 
     including mssccprj.scc, [project].vssscc, vsserver.scc, 
     [project].vbproj.vspscc, and [project].csproj.vspscc files.
 - This process will also edit the solution and related 
     project files, but backups of each file will be created
     in the same location as the file that is being edited.

Do you want to continue?";

            DialogResult result = MessageBox.Show(warningMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                MigrationProcessSolution(TfsCleanerTextSolutionFile.Text);
            }
            else
            {
                MessageBox.Show("Process aborted...", "Process Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void MigrationProcessSolution(string solutionFilePath)
        {
            // backup solution folder
            string sourceFolder = Path.GetDirectoryName(TfsCleanerTextSolutionFile.Text);

            statusStrip.BackColor = STATUS_BAR_ACTIVE_COLOR;
            UpdateStatus("Backing up the entire Solution to the Solution Backup Folder...");

            UtilityMethods.DeepDirectoryCopy(sourceFolder, TfsMigrationTextSolutionBackupFolder.Text);

            var vs = new TfsMigrationMethods();

            UpdateStatus("Removing TFS Binding information from the Solution...");

            string resultString = vs.RemoveTfsEntriesForSolution(solutionFilePath);

            UpdateStatus("Removing TFS Binding information from related Projects...");

            resultString += vs.RemoveTfsProjectEntriesForAllProjectsInSolution(solutionFilePath);

            UpdateStatus("Deleting TFS related files from the entire Solution...");

            resultString += vs.DeleteTfsRelatedFilesForSolutionAndRelatedProjects(solutionFilePath);

            this.Cursor = Cursors.Default;
            statusStrip.BackColor = STATUS_BAR_INACTIVE_COLOR;
            UpdateStatus("TFS Migration Cleanup is complete...");

            if (!string.IsNullOrEmpty(vs.SeriousIssues))
            {
                string seriousIssueMessage = "SERIOUS ISSUES ENCOUNTERED, they will also be repeated at the top of the results window that will open when this message is closed." + Environment.NewLine;
                seriousIssueMessage += "----------------------------" + Environment.NewLine;
                seriousIssueMessage += vs.SeriousIssues;

                resultString = seriousIssueMessage + Environment.NewLine + resultString;

                MessageBox.Show(seriousIssueMessage, "Serious Issues Encountered...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            TfsMigrationTextResults.Text = resultString;

            MessageBox.Show("TFS Migration Cleanup completed, see the Results box for details...");
        }

        private void TfsMigrationButtonSelectBackupFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                TfsMigrationTextSolutionBackupFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        #endregion

        #region Methods - Solution Reference Analyzer

        private void BindReferenceDetails(BindingSource bindingSource)
        {
            ReferenceAnalyzerTextAsemblyName.DataBindings.Clear();
            ReferenceAnalyzerTextAsemblyName.DataBindings.Add(new Binding("Text", bindingSource, "AssemblyName"));

            ReferenceAnalyzerTextFullyQualifiedName.DataBindings.Clear();
            ReferenceAnalyzerTextFullyQualifiedName.DataBindings.Add(new Binding("Text", bindingSource, "FullyQualifiedName"));

            ReferenceAnalyzerTextPath.DataBindings.Clear();
            ReferenceAnalyzerTextPath.DataBindings.Add(new Binding("Text", bindingSource, "Path"));

            ReferenceAnalyzerTextReferenceType.DataBindings.Clear();
            ReferenceAnalyzerTextReferenceType.DataBindings.Add(new Binding("Text", bindingSource, "ReferenceType"));

            ReferenceAnalyzerTextRequiredTargetFramework.DataBindings.Clear();
            ReferenceAnalyzerTextRequiredTargetFramework.DataBindings.Add(new Binding("Text", bindingSource, "RequiredTargetFramework"));

            ReferenceDetails referenceDetails = bindingSource.Current as ReferenceDetails;

            ReferenceAnalyzerListProjectsContainingReference.DataSource = GetProjectContainingReferenceByReferenceDetails(referenceDetails);

            if (!string.IsNullOrEmpty(ReferenceAnalyzerTextPath.Text))
            {
                ReferenceAnalyzerButtonOpenReferencePath.Enabled = true;
            }
            else
            {
                ReferenceAnalyzerButtonOpenReferencePath.Enabled = false;
            }
        }

        private void ReferenceAnalyzerListProjectReferences_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindReferenceDetails(projectReferencesBindingSource);
        }

        private void ReferenceAnalyzerListFrameworkReferences_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindReferenceDetails(frameworkReferencesBindingSource);
        }

        private void ReferenceAnalyzerListLibraryReferences_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindReferenceDetails(libraryReferencesBindingSource);
        }

        private List<string> GetProjectContainingReferenceByReferenceDetails(ReferenceDetails details)
        {
            var projectNames = (from project in _referenceAnalysisProjectReferenceInfoList
                                where project.AllReferences.Contains(details)
                                select project.ProjectName).OrderBy(s => s).ToList();

            return projectNames;
        }

        private void ReferenceAnalyzerBtnSelectSolution_Click(object sender, EventArgs e)
        {
            DialogResult result = openSolutionFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                ReferenceAnalyzerTextSolutionFile.Text = openSolutionFileDialog.FileName;

                ReferenceAnalyzerLoadSolution();
            }

            ReferenceAnalyzerListLibraryReferences.SelectedIndex = -1;
            ReferenceAnalyzerListProjectReferences.SelectedIndex = -1;
            ReferenceAnalyzerListFrameworkReferences.SelectedIndex = -1;

            ReferenceAnalyzerTextAsemblyName.DataBindings.Clear();
            ReferenceAnalyzerTextAsemblyName.Text = string.Empty;

            ReferenceAnalyzerTextFullyQualifiedName.DataBindings.Clear();
            ReferenceAnalyzerTextFullyQualifiedName.Text = string.Empty;

            ReferenceAnalyzerTextPath.DataBindings.Clear();
            ReferenceAnalyzerTextPath.Text = string.Empty;

            ReferenceAnalyzerTextReferenceType.DataBindings.Clear();
            ReferenceAnalyzerTextReferenceType.Text = string.Empty;

            ReferenceAnalyzerTextRequiredTargetFramework.DataBindings.Clear();
            ReferenceAnalyzerTextRequiredTargetFramework.Text = string.Empty;

            ReferenceAnalyzerListProjectsContainingReference.DataSource = null;
            ReferenceAnalyzerListProjectsContainingReference.Text = string.Empty;
        }

        private void ReferenceAnalyzerLoadSolution()
        {
            if (string.IsNullOrEmpty(ReferenceAnalyzerTextSolutionFile.Text))
            {
                MessageBox.Show("Please select a Solution file...");
                return;
            }

            string solutionFilePath = ReferenceAnalyzerTextSolutionFile.Text;

            #region Preconditions
            if (!File.Exists(solutionFilePath)) { throw new FileNotFoundException(solutionFilePath); }
            #endregion

            this.Cursor = Cursors.WaitCursor;
            statusStrip.BackColor = STATUS_BAR_ACTIVE_COLOR;

            string solutionFolderPath = Path.GetDirectoryName(solutionFilePath);

            Environment.CurrentDirectory = solutionFolderPath;

            Solution solution = new Solution(solutionFilePath);

            int projectCount = solution.Projects.Count;
            int index = 1;

            foreach (SolutionProject project in solution.Projects)
            {
                // reset the environment directory to the solution for loading the project
                Environment.CurrentDirectory = solutionFolderPath;

                UpdateStatus(string.Format("Processing Project {1} out of {2}: {0}", project.ProjectName, index, projectCount));
                index++;

                ProjectReferenceInfo projectReferenceInfo = ReferenceMethods.GetReferenceDetailsForProject(project);

                _referenceAnalysisProjectReferenceInfoList.Add(projectReferenceInfo);
            }

            // collect all unique references by type
            List<ReferenceDetails> allProjectReferences = _referenceAnalysisProjectReferenceInfoList.SelectMany(info => info.ProjectReferences).Distinct().OrderBy(info => info.AssemblyName).ToList();
            List<ReferenceDetails> allFrameworkReferences = _referenceAnalysisProjectReferenceInfoList.SelectMany(info => info.FrameworkReferences).Distinct().OrderBy(info => info.AssemblyName).ToList();
            List<ReferenceDetails> allLibraryReferences = _referenceAnalysisProjectReferenceInfoList.SelectMany(info => info.LibraryReferences).Distinct().OrderBy(info => info.AssemblyName).ToList();

            projectReferencesBindingSource.DataSource = allProjectReferences;
            frameworkReferencesBindingSource.DataSource = allFrameworkReferences;
            libraryReferencesBindingSource.DataSource = allLibraryReferences;

            UpdateStatus("Analyzing References...");
            string analysisResults = ReferenceMethods.AnalyzeReferences(_referenceAnalysisProjectReferenceInfoList);

            ReferenceAnalyzerTextAnalysisResults.Text = analysisResults;

            this.Cursor = Cursors.Default;
            statusStrip.BackColor = STATUS_BAR_INACTIVE_COLOR;
            UpdateStatus("Finished analyzing references.");
        }

        private void ReferenceAnalyzerListProjectReferences_MouseDown(object sender, MouseEventArgs e)
        {
            ReferenceAnalyzerListFrameworkReferences.SelectedIndex = -1;
            ReferenceAnalyzerListLibraryReferences.SelectedIndex = -1;
        }

        private void ReferenceAnalyzerListFrameworkReferences_MouseDown(object sender, MouseEventArgs e)
        {
            ReferenceAnalyzerListLibraryReferences.SelectedIndex = -1;
            ReferenceAnalyzerListProjectReferences.SelectedIndex = -1;
        }

        private void ReferenceAnalyzerListLibraryReferences_MouseDown(object sender, MouseEventArgs e)
        {
            ReferenceAnalyzerListProjectReferences.SelectedIndex = -1;
            ReferenceAnalyzerListFrameworkReferences.SelectedIndex = -1;
        }

        private void ReferenceAnalyzerButtonOpenReferencePath_Click(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(ReferenceAnalyzerTextPath.Text));
        }

        #endregion

        #region Methods - Changeset Grabber

        private void ChangesetGrabberButtonRetrieveChangesetList_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            statusStrip.BackColor = STATUS_BAR_ACTIVE_COLOR;
            UpdateStatus("Loading Changesets...");

            _changesetGrabber = new ChangesetGrabberMethods(ChangesetGrabberTextTfsUrl.Text, ChangesetGrabberTextDomainAndUsername.Text, ChangesetGrabberTextPassword.Text);

            List<Changeset> changesets = _changesetGrabber.GetChangesetList(ChangesetGrabberTextSourceBranch.Text, ChangesetGrabberTextTargetBranch.Text);

            changesetBindingSource.DataSource = changesets;

            this.Cursor = Cursors.Default;
            statusStrip.BackColor = STATUS_BAR_INACTIVE_COLOR;
            UpdateStatus(string.Format("Completed loading {0} Changesets.", changesets.Count));
        }

        private void changesetBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (changesetBindingSource.Current == null) { return; }

            Changeset changeset = changesetBindingSource.Current as Changeset;

            this.Cursor = Cursors.WaitCursor;
            statusStrip.BackColor = STATUS_BAR_ACTIVE_COLOR;
            UpdateStatus("Loading Changeset: " + changeset.ArtifactUri);

            List<ChangeItemDetails> changeItemDetailList = _changesetGrabber.GetChangeItemDetails(changeset.ArtifactUri);

            changeItemDetailsBindingSource.DataSource = changeItemDetailList;

            this.Cursor = Cursors.Default;
            statusStrip.BackColor = STATUS_BAR_INACTIVE_COLOR;
            UpdateStatus("Completed loading Changeset.");
        }

        private void ChangesetGrabberButtonLoadToFileSystem_Click(object sender, EventArgs e)
        {
            string basePath = ChangesetGrabberTextSaveToFolder.Text;

            if (!Directory.Exists(basePath))
            {
                MessageBox.Show("The folder to save files to must already exist, please create the folder path or enter a different one.");
                return;
            }

            if (changesetBindingSource.Current == null)
            {
                MessageBox.Show("Please select a Changeset.");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            statusStrip.BackColor = STATUS_BAR_ACTIVE_COLOR;
            UpdateStatus("Saving Changeset Files to the File System...");

            Changeset changeset = changesetBindingSource.Current as Changeset;

            Uri changesetUri = changeset.ArtifactUri;

            bool replaceExistingFiles = ChangesetGrabberCheckboxReplaceExistingFiles.Checked;
            bool backupExistingFiles = ChangesetGrabberCheckboxBackupExistingFiles.Checked;

            try
            {
                _changesetGrabber.RetrieveChangesetFilesFromTfs(changesetUri, basePath, replaceExistingFiles, backupExistingFiles);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            this.Cursor = Cursors.Default;
            statusStrip.BackColor = STATUS_BAR_INACTIVE_COLOR;
            UpdateStatus(string.Format("Finished, {0} Changeset Files Saved to the File System ({1} - {2}).", changeItemDetailsBindingSource.Count, changeset.ChangesetId, changeset.Comment));
        }

        private void ChangesetGrabberButtonOpenSaveToFolder_Click(object sender, EventArgs e)
        {
            string folderPath = ChangesetGrabberTextSaveToFolder.Text;

            if (Directory.Exists(folderPath))
            {
                Process.Start(folderPath);
            }
            else
            {
                MessageBox.Show("The Save To Folder path doesn't exist.");
            }
        }

        private void ChangesetGrabberTextTfsUrl_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.changeSetTfsUrl = ChangesetGrabberTextTfsUrl.Text;
            Properties.Settings.Default.Save();
        }

        private void ChangesetGrabberTextDomainAndUsername_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.changeSetUserName = ChangesetGrabberTextDomainAndUsername.Text;
            Properties.Settings.Default.Save();
        }

        private void ChangesetGrabberTextSourceBranch_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.changeSetSourceBranch = ChangesetGrabberTextSourceBranch.Text;
            Properties.Settings.Default.Save();
        }

        private void ChangesetGrabberTextTargetBranch_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.changeSetTargetBranch = ChangesetGrabberTextTargetBranch.Text;
            Properties.Settings.Default.Save();

        }

        private void ChangesetGrabberTextSaveToFolder_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.changeSetSavePath = ChangesetGrabberTextSaveToFolder.Text;
            Properties.Settings.Default.Save();
        }


        #endregion

        #region Methods (private)

        private void UpdateStatus(string status)
        {
            lblFormStatus.Text = status;
            statusStrip.Refresh();
        }

        #endregion

    }
}
