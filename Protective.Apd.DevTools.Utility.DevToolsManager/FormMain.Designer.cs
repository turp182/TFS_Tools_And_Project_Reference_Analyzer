namespace DevToolsAndReferenceAnalyzer
{
    public partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label assemblyNameLabel;
            System.Windows.Forms.Label fullyQualifiedNameLabel;
            System.Windows.Forms.Label pathLabel;
            System.Windows.Forms.Label referenceTypeLabel;
            System.Windows.Forms.Label requiredTargetFrameworkLabel;
            System.Windows.Forms.Label label8;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageTfsBindingCleaner = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TfsMigrationTextResults = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TfsMigrationButtonSelectBackupFolder = new System.Windows.Forms.Button();
            this.TfsMigrationTextSolutionBackupFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TfsMigrationButtonProcess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMigrationSelectSolutionFile = new System.Windows.Forms.Button();
            this.TfsCleanerTextSolutionFile = new System.Windows.Forms.TextBox();
            this.tabPageSolutionReferenceAnalyzer = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.ReferenceAnalyzerTextSolutionFile = new System.Windows.Forms.TextBox();
            this.ReferenceAnalyzerBtnSelectSolution = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ReferenceAnalyzerTextAnalysisResults = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ReferenceAnalyzerButtonOpenReferencePath = new System.Windows.Forms.Button();
            this.ReferenceAnalyzerListProjectsContainingReference = new System.Windows.Forms.ListBox();
            this.ReferenceAnalyzerTextRequiredTargetFramework = new System.Windows.Forms.TextBox();
            this.ReferenceAnalyzerTextAsemblyName = new System.Windows.Forms.TextBox();
            this.ReferenceAnalyzerTextReferenceType = new System.Windows.Forms.TextBox();
            this.ReferenceAnalyzerTextFullyQualifiedName = new System.Windows.Forms.TextBox();
            this.ReferenceAnalyzerTextPath = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ReferenceAnalyzerListProjectReferences = new System.Windows.Forms.ListBox();
            this.projectReferencesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ReferenceAnalyzerListFrameworkReferences = new System.Windows.Forms.ListBox();
            this.frameworkReferencesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReferenceAnalyzerListLibraryReferences = new System.Windows.Forms.ListBox();
            this.libraryReferencesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tabChangesetGrabber = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.ChangesetGrabberButtonOpenSaveToFolder = new System.Windows.Forms.Button();
            this.ChangesetGrabberButtonLoadToFileSystem = new System.Windows.Forms.Button();
            this.ChangesetGrabberCheckboxReplaceExistingFiles = new System.Windows.Forms.CheckBox();
            this.ChangesetGrabberCheckboxBackupExistingFiles = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ChangesetGrabberTextSaveToFolder = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.ChangesetGrabberDataGridChangesetFiles = new System.Windows.Forms.DataGridView();
            this.changeTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changeItemDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.ChangesetGrabberDataGridChangesets = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changesetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.ChangesetGrabberTextDomainAndUsername = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ChangesetGrabberTextPassword = new System.Windows.Forms.TextBox();
            this.ChangesetGrabberTextTargetBranch = new System.Windows.Forms.TextBox();
            this.ChangesetGrabberTextTfsUrl = new System.Windows.Forms.TextBox();
            this.ChangesetGrabberTextSourceBranch = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ChangesetGrabberButtonRetrieveChangesetList = new System.Windows.Forms.Button();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.projectAnalysisSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openSolutionFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblFormStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            assemblyNameLabel = new System.Windows.Forms.Label();
            fullyQualifiedNameLabel = new System.Windows.Forms.Label();
            pathLabel = new System.Windows.Forms.Label();
            referenceTypeLabel = new System.Windows.Forms.Label();
            requiredTargetFrameworkLabel = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageTfsBindingCleaner.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageSolutionReferenceAnalyzer.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectReferencesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameworkReferencesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryReferencesBindingSource)).BeginInit();
            this.tabChangesetGrabber.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChangesetGrabberDataGridChangesetFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeItemDetailsBindingSource)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChangesetGrabberDataGridChangesets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changesetBindingSource)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectAnalysisSettingsBindingSource)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // assemblyNameLabel
            // 
            assemblyNameLabel.AutoSize = true;
            assemblyNameLabel.Location = new System.Drawing.Point(6, 16);
            assemblyNameLabel.Name = "assemblyNameLabel";
            assemblyNameLabel.Size = new System.Drawing.Size(85, 13);
            assemblyNameLabel.TabIndex = 10;
            assemblyNameLabel.Text = "Assembly Name:";
            // 
            // fullyQualifiedNameLabel
            // 
            fullyQualifiedNameLabel.AutoSize = true;
            fullyQualifiedNameLabel.Location = new System.Drawing.Point(6, 42);
            fullyQualifiedNameLabel.Name = "fullyQualifiedNameLabel";
            fullyQualifiedNameLabel.Size = new System.Drawing.Size(106, 13);
            fullyQualifiedNameLabel.TabIndex = 12;
            fullyQualifiedNameLabel.Text = "Fully Qualified Name:";
            // 
            // pathLabel
            // 
            pathLabel.AutoSize = true;
            pathLabel.Location = new System.Drawing.Point(6, 68);
            pathLabel.Name = "pathLabel";
            pathLabel.Size = new System.Drawing.Size(32, 13);
            pathLabel.TabIndex = 14;
            pathLabel.Text = "Path:";
            // 
            // referenceTypeLabel
            // 
            referenceTypeLabel.AutoSize = true;
            referenceTypeLabel.Location = new System.Drawing.Point(6, 94);
            referenceTypeLabel.Name = "referenceTypeLabel";
            referenceTypeLabel.Size = new System.Drawing.Size(87, 13);
            referenceTypeLabel.TabIndex = 16;
            referenceTypeLabel.Text = "Reference Type:";
            // 
            // requiredTargetFrameworkLabel
            // 
            requiredTargetFrameworkLabel.AutoSize = true;
            requiredTargetFrameworkLabel.Location = new System.Drawing.Point(6, 120);
            requiredTargetFrameworkLabel.Name = "requiredTargetFrameworkLabel";
            requiredTargetFrameworkLabel.Size = new System.Drawing.Size(142, 13);
            requiredTargetFrameworkLabel.TabIndex = 18;
            requiredTargetFrameworkLabel.Text = "Required Target Framework:";
            // 
            // label8
            // 
            label8.Location = new System.Drawing.Point(6, 143);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(142, 34);
            label8.TabIndex = 21;
            label8.Text = "Projects Containing This Reference";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageTfsBindingCleaner);
            this.tabControl.Controls.Add(this.tabPageSolutionReferenceAnalyzer);
            this.tabControl.Controls.Add(this.tabChangesetGrabber);
            this.tabControl.ImageList = this.imageListIcons;
            this.tabControl.Location = new System.Drawing.Point(2, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1127, 637);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageTfsBindingCleaner
            // 
            this.tabPageTfsBindingCleaner.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageTfsBindingCleaner.Controls.Add(this.groupBox2);
            this.tabPageTfsBindingCleaner.Controls.Add(this.groupBox1);
            this.tabPageTfsBindingCleaner.ImageIndex = 1;
            this.tabPageTfsBindingCleaner.Location = new System.Drawing.Point(4, 55);
            this.tabPageTfsBindingCleaner.Name = "tabPageTfsBindingCleaner";
            this.tabPageTfsBindingCleaner.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTfsBindingCleaner.Size = new System.Drawing.Size(1119, 578);
            this.tabPageTfsBindingCleaner.TabIndex = 0;
            this.tabPageTfsBindingCleaner.Text = "TFS Binding Cleaner";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TfsMigrationTextResults);
            this.groupBox2.Location = new System.Drawing.Point(11, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1100, 442);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // TfsMigrationTextResults
            // 
            this.TfsMigrationTextResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TfsMigrationTextResults.Location = new System.Drawing.Point(3, 16);
            this.TfsMigrationTextResults.Multiline = true;
            this.TfsMigrationTextResults.Name = "TfsMigrationTextResults";
            this.TfsMigrationTextResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TfsMigrationTextResults.Size = new System.Drawing.Size(1094, 423);
            this.TfsMigrationTextResults.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TfsMigrationButtonSelectBackupFolder);
            this.groupBox1.Controls.Add(this.TfsMigrationTextSolutionBackupFolder);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TfsMigrationButtonProcess);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnMigrationSelectSolutionFile);
            this.groupBox1.Controls.Add(this.TfsCleanerTextSolutionFile);
            this.groupBox1.Location = new System.Drawing.Point(11, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1102, 101);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select and Process Solution File";
            // 
            // TfsMigrationButtonSelectBackupFolder
            // 
            this.TfsMigrationButtonSelectBackupFolder.Location = new System.Drawing.Point(953, 43);
            this.TfsMigrationButtonSelectBackupFolder.Name = "TfsMigrationButtonSelectBackupFolder";
            this.TfsMigrationButtonSelectBackupFolder.Size = new System.Drawing.Size(143, 23);
            this.TfsMigrationButtonSelectBackupFolder.TabIndex = 6;
            this.TfsMigrationButtonSelectBackupFolder.Text = "Select";
            this.TfsMigrationButtonSelectBackupFolder.UseVisualStyleBackColor = true;
            this.TfsMigrationButtonSelectBackupFolder.Click += new System.EventHandler(this.TfsMigrationButtonSelectBackupFolder_Click);
            // 
            // TfsMigrationTextSolutionBackupFolder
            // 
            this.TfsMigrationTextSolutionBackupFolder.Location = new System.Drawing.Point(143, 45);
            this.TfsMigrationTextSolutionBackupFolder.Name = "TfsMigrationTextSolutionBackupFolder";
            this.TfsMigrationTextSolutionBackupFolder.Size = new System.Drawing.Size(804, 20);
            this.TfsMigrationTextSolutionBackupFolder.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Solution Backup Folder:";
            // 
            // TfsMigrationButtonProcess
            // 
            this.TfsMigrationButtonProcess.Location = new System.Drawing.Point(6, 71);
            this.TfsMigrationButtonProcess.Name = "TfsMigrationButtonProcess";
            this.TfsMigrationButtonProcess.Size = new System.Drawing.Size(323, 23);
            this.TfsMigrationButtonProcess.TabIndex = 3;
            this.TfsMigrationButtonProcess.Text = "Process";
            this.TfsMigrationButtonProcess.UseVisualStyleBackColor = true;
            this.TfsMigrationButtonProcess.Click += new System.EventHandler(this.TfsMigrationButtonProcess_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visual Studio Solution File:";
            // 
            // btnMigrationSelectSolutionFile
            // 
            this.btnMigrationSelectSolutionFile.Location = new System.Drawing.Point(953, 17);
            this.btnMigrationSelectSolutionFile.Name = "btnMigrationSelectSolutionFile";
            this.btnMigrationSelectSolutionFile.Size = new System.Drawing.Size(143, 23);
            this.btnMigrationSelectSolutionFile.TabIndex = 2;
            this.btnMigrationSelectSolutionFile.Text = "Select";
            this.btnMigrationSelectSolutionFile.UseVisualStyleBackColor = true;
            this.btnMigrationSelectSolutionFile.Click += new System.EventHandler(this.TfsMigrationButtonSelectSolutionFile_Click);
            // 
            // TfsCleanerTextSolutionFile
            // 
            this.TfsCleanerTextSolutionFile.Location = new System.Drawing.Point(143, 19);
            this.TfsCleanerTextSolutionFile.Name = "TfsCleanerTextSolutionFile";
            this.TfsCleanerTextSolutionFile.ReadOnly = true;
            this.TfsCleanerTextSolutionFile.Size = new System.Drawing.Size(804, 20);
            this.TfsCleanerTextSolutionFile.TabIndex = 1;
            // 
            // tabPageSolutionReferenceAnalyzer
            // 
            this.tabPageSolutionReferenceAnalyzer.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSolutionReferenceAnalyzer.Controls.Add(this.groupBox8);
            this.tabPageSolutionReferenceAnalyzer.Controls.Add(this.groupBox7);
            this.tabPageSolutionReferenceAnalyzer.Controls.Add(this.groupBox6);
            this.tabPageSolutionReferenceAnalyzer.Controls.Add(this.groupBox5);
            this.tabPageSolutionReferenceAnalyzer.ImageIndex = 3;
            this.tabPageSolutionReferenceAnalyzer.Location = new System.Drawing.Point(4, 55);
            this.tabPageSolutionReferenceAnalyzer.Name = "tabPageSolutionReferenceAnalyzer";
            this.tabPageSolutionReferenceAnalyzer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSolutionReferenceAnalyzer.Size = new System.Drawing.Size(1119, 578);
            this.tabPageSolutionReferenceAnalyzer.TabIndex = 4;
            this.tabPageSolutionReferenceAnalyzer.Text = "Visual Studio Solution Reference Analyzer";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.ReferenceAnalyzerTextSolutionFile);
            this.groupBox8.Controls.Add(this.ReferenceAnalyzerBtnSelectSolution);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Location = new System.Drawing.Point(6, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1105, 51);
            this.groupBox8.TabIndex = 23;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Select Solution File";
            // 
            // ReferenceAnalyzerTextSolutionFile
            // 
            this.ReferenceAnalyzerTextSolutionFile.Location = new System.Drawing.Point(151, 27);
            this.ReferenceAnalyzerTextSolutionFile.Name = "ReferenceAnalyzerTextSolutionFile";
            this.ReferenceAnalyzerTextSolutionFile.ReadOnly = true;
            this.ReferenceAnalyzerTextSolutionFile.Size = new System.Drawing.Size(799, 20);
            this.ReferenceAnalyzerTextSolutionFile.TabIndex = 8;
            // 
            // ReferenceAnalyzerBtnSelectSolution
            // 
            this.ReferenceAnalyzerBtnSelectSolution.Location = new System.Drawing.Point(956, 25);
            this.ReferenceAnalyzerBtnSelectSolution.Name = "ReferenceAnalyzerBtnSelectSolution";
            this.ReferenceAnalyzerBtnSelectSolution.Size = new System.Drawing.Size(143, 23);
            this.ReferenceAnalyzerBtnSelectSolution.TabIndex = 9;
            this.ReferenceAnalyzerBtnSelectSolution.Text = "Select";
            this.ReferenceAnalyzerBtnSelectSolution.UseVisualStyleBackColor = true;
            this.ReferenceAnalyzerBtnSelectSolution.Click += new System.EventHandler(this.ReferenceAnalyzerBtnSelectSolution_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Visual Studio Solution File:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ReferenceAnalyzerTextAnalysisResults);
            this.groupBox7.Location = new System.Drawing.Point(357, 332);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(756, 240);
            this.groupBox7.TabIndex = 22;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Analysis Results";
            // 
            // ReferenceAnalyzerTextAnalysisResults
            // 
            this.ReferenceAnalyzerTextAnalysisResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferenceAnalyzerTextAnalysisResults.Location = new System.Drawing.Point(3, 16);
            this.ReferenceAnalyzerTextAnalysisResults.Multiline = true;
            this.ReferenceAnalyzerTextAnalysisResults.Name = "ReferenceAnalyzerTextAnalysisResults";
            this.ReferenceAnalyzerTextAnalysisResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ReferenceAnalyzerTextAnalysisResults.Size = new System.Drawing.Size(750, 221);
            this.ReferenceAnalyzerTextAnalysisResults.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ReferenceAnalyzerButtonOpenReferencePath);
            this.groupBox6.Controls.Add(label8);
            this.groupBox6.Controls.Add(this.ReferenceAnalyzerListProjectsContainingReference);
            this.groupBox6.Controls.Add(assemblyNameLabel);
            this.groupBox6.Controls.Add(pathLabel);
            this.groupBox6.Controls.Add(this.ReferenceAnalyzerTextRequiredTargetFramework);
            this.groupBox6.Controls.Add(this.ReferenceAnalyzerTextAsemblyName);
            this.groupBox6.Controls.Add(requiredTargetFrameworkLabel);
            this.groupBox6.Controls.Add(fullyQualifiedNameLabel);
            this.groupBox6.Controls.Add(this.ReferenceAnalyzerTextReferenceType);
            this.groupBox6.Controls.Add(this.ReferenceAnalyzerTextFullyQualifiedName);
            this.groupBox6.Controls.Add(referenceTypeLabel);
            this.groupBox6.Controls.Add(this.ReferenceAnalyzerTextPath);
            this.groupBox6.Location = new System.Drawing.Point(357, 63);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(754, 263);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Reference Details";
            // 
            // ReferenceAnalyzerButtonOpenReferencePath
            // 
            this.ReferenceAnalyzerButtonOpenReferencePath.Enabled = false;
            this.ReferenceAnalyzerButtonOpenReferencePath.Location = new System.Drawing.Point(660, 63);
            this.ReferenceAnalyzerButtonOpenReferencePath.Name = "ReferenceAnalyzerButtonOpenReferencePath";
            this.ReferenceAnalyzerButtonOpenReferencePath.Size = new System.Drawing.Size(88, 23);
            this.ReferenceAnalyzerButtonOpenReferencePath.TabIndex = 10;
            this.ReferenceAnalyzerButtonOpenReferencePath.Text = "Open Path";
            this.ReferenceAnalyzerButtonOpenReferencePath.UseVisualStyleBackColor = true;
            this.ReferenceAnalyzerButtonOpenReferencePath.Click += new System.EventHandler(this.ReferenceAnalyzerButtonOpenReferencePath_Click);
            // 
            // ReferenceAnalyzerListProjectsContainingReference
            // 
            this.ReferenceAnalyzerListProjectsContainingReference.FormattingEnabled = true;
            this.ReferenceAnalyzerListProjectsContainingReference.Location = new System.Drawing.Point(154, 143);
            this.ReferenceAnalyzerListProjectsContainingReference.Name = "ReferenceAnalyzerListProjectsContainingReference";
            this.ReferenceAnalyzerListProjectsContainingReference.Size = new System.Drawing.Size(594, 108);
            this.ReferenceAnalyzerListProjectsContainingReference.TabIndex = 20;
            // 
            // ReferenceAnalyzerTextRequiredTargetFramework
            // 
            this.ReferenceAnalyzerTextRequiredTargetFramework.Enabled = false;
            this.ReferenceAnalyzerTextRequiredTargetFramework.Location = new System.Drawing.Point(154, 117);
            this.ReferenceAnalyzerTextRequiredTargetFramework.Name = "ReferenceAnalyzerTextRequiredTargetFramework";
            this.ReferenceAnalyzerTextRequiredTargetFramework.Size = new System.Drawing.Size(141, 20);
            this.ReferenceAnalyzerTextRequiredTargetFramework.TabIndex = 19;
            // 
            // ReferenceAnalyzerTextAsemblyName
            // 
            this.ReferenceAnalyzerTextAsemblyName.Enabled = false;
            this.ReferenceAnalyzerTextAsemblyName.Location = new System.Drawing.Point(154, 13);
            this.ReferenceAnalyzerTextAsemblyName.Name = "ReferenceAnalyzerTextAsemblyName";
            this.ReferenceAnalyzerTextAsemblyName.Size = new System.Drawing.Size(173, 20);
            this.ReferenceAnalyzerTextAsemblyName.TabIndex = 11;
            // 
            // ReferenceAnalyzerTextReferenceType
            // 
            this.ReferenceAnalyzerTextReferenceType.Enabled = false;
            this.ReferenceAnalyzerTextReferenceType.Location = new System.Drawing.Point(154, 91);
            this.ReferenceAnalyzerTextReferenceType.Name = "ReferenceAnalyzerTextReferenceType";
            this.ReferenceAnalyzerTextReferenceType.Size = new System.Drawing.Size(141, 20);
            this.ReferenceAnalyzerTextReferenceType.TabIndex = 17;
            // 
            // ReferenceAnalyzerTextFullyQualifiedName
            // 
            this.ReferenceAnalyzerTextFullyQualifiedName.Location = new System.Drawing.Point(154, 39);
            this.ReferenceAnalyzerTextFullyQualifiedName.Name = "ReferenceAnalyzerTextFullyQualifiedName";
            this.ReferenceAnalyzerTextFullyQualifiedName.Size = new System.Drawing.Size(594, 20);
            this.ReferenceAnalyzerTextFullyQualifiedName.TabIndex = 13;
            // 
            // ReferenceAnalyzerTextPath
            // 
            this.ReferenceAnalyzerTextPath.Location = new System.Drawing.Point(154, 65);
            this.ReferenceAnalyzerTextPath.Name = "ReferenceAnalyzerTextPath";
            this.ReferenceAnalyzerTextPath.Size = new System.Drawing.Size(500, 20);
            this.ReferenceAnalyzerTextPath.TabIndex = 15;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ReferenceAnalyzerListProjectReferences);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.ReferenceAnalyzerListFrameworkReferences);
            this.groupBox5.Controls.Add(this.ReferenceAnalyzerListLibraryReferences);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(3, 63);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(348, 520);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "References";
            // 
            // ReferenceAnalyzerListProjectReferences
            // 
            this.ReferenceAnalyzerListProjectReferences.DataSource = this.projectReferencesBindingSource;
            this.ReferenceAnalyzerListProjectReferences.DisplayMember = "AssemblyName";
            this.ReferenceAnalyzerListProjectReferences.FormattingEnabled = true;
            this.ReferenceAnalyzerListProjectReferences.Location = new System.Drawing.Point(9, 32);
            this.ReferenceAnalyzerListProjectReferences.Name = "ReferenceAnalyzerListProjectReferences";
            this.ReferenceAnalyzerListProjectReferences.Size = new System.Drawing.Size(331, 147);
            this.ReferenceAnalyzerListProjectReferences.TabIndex = 1;
            this.ReferenceAnalyzerListProjectReferences.SelectedIndexChanged += new System.EventHandler(this.ReferenceAnalyzerListProjectReferences_SelectedIndexChanged);
            this.ReferenceAnalyzerListProjectReferences.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ReferenceAnalyzerListProjectReferences_MouseDown);
            // 
            // projectReferencesBindingSource
            // 
            this.projectReferencesBindingSource.DataSource = typeof(DevToolsAndReferenceAnalyzer.SolutionReferenceAnalysisClasses.ReferenceDetails);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Project References";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Framework References";
            // 
            // ReferenceAnalyzerListFrameworkReferences
            // 
            this.ReferenceAnalyzerListFrameworkReferences.DataSource = this.frameworkReferencesBindingSource;
            this.ReferenceAnalyzerListFrameworkReferences.DisplayMember = "AssemblyName";
            this.ReferenceAnalyzerListFrameworkReferences.FormattingEnabled = true;
            this.ReferenceAnalyzerListFrameworkReferences.Location = new System.Drawing.Point(6, 201);
            this.ReferenceAnalyzerListFrameworkReferences.Name = "ReferenceAnalyzerListFrameworkReferences";
            this.ReferenceAnalyzerListFrameworkReferences.Size = new System.Drawing.Size(331, 147);
            this.ReferenceAnalyzerListFrameworkReferences.TabIndex = 2;
            this.ReferenceAnalyzerListFrameworkReferences.SelectedIndexChanged += new System.EventHandler(this.ReferenceAnalyzerListFrameworkReferences_SelectedIndexChanged);
            this.ReferenceAnalyzerListFrameworkReferences.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ReferenceAnalyzerListFrameworkReferences_MouseDown);
            // 
            // frameworkReferencesBindingSource
            // 
            this.frameworkReferencesBindingSource.DataSource = typeof(DevToolsAndReferenceAnalyzer.SolutionReferenceAnalysisClasses.ReferenceDetails);
            // 
            // ReferenceAnalyzerListLibraryReferences
            // 
            this.ReferenceAnalyzerListLibraryReferences.DataSource = this.libraryReferencesBindingSource;
            this.ReferenceAnalyzerListLibraryReferences.DisplayMember = "AssemblyName";
            this.ReferenceAnalyzerListLibraryReferences.FormattingEnabled = true;
            this.ReferenceAnalyzerListLibraryReferences.Location = new System.Drawing.Point(6, 367);
            this.ReferenceAnalyzerListLibraryReferences.Name = "ReferenceAnalyzerListLibraryReferences";
            this.ReferenceAnalyzerListLibraryReferences.Size = new System.Drawing.Size(334, 147);
            this.ReferenceAnalyzerListLibraryReferences.TabIndex = 3;
            this.ReferenceAnalyzerListLibraryReferences.SelectedIndexChanged += new System.EventHandler(this.ReferenceAnalyzerListLibraryReferences_SelectedIndexChanged);
            this.ReferenceAnalyzerListLibraryReferences.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ReferenceAnalyzerListLibraryReferences_MouseDown);
            // 
            // libraryReferencesBindingSource
            // 
            this.libraryReferencesBindingSource.DataSource = typeof(DevToolsAndReferenceAnalyzer.SolutionReferenceAnalysisClasses.ReferenceDetails);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Library References";
            // 
            // tabChangesetGrabber
            // 
            this.tabChangesetGrabber.BackColor = System.Drawing.SystemColors.Control;
            this.tabChangesetGrabber.Controls.Add(this.groupBox12);
            this.tabChangesetGrabber.Controls.Add(this.groupBox11);
            this.tabChangesetGrabber.Controls.Add(this.groupBox10);
            this.tabChangesetGrabber.Controls.Add(this.groupBox9);
            this.tabChangesetGrabber.ImageIndex = 4;
            this.tabChangesetGrabber.Location = new System.Drawing.Point(4, 55);
            this.tabChangesetGrabber.Name = "tabChangesetGrabber";
            this.tabChangesetGrabber.Padding = new System.Windows.Forms.Padding(3);
            this.tabChangesetGrabber.Size = new System.Drawing.Size(1119, 578);
            this.tabChangesetGrabber.TabIndex = 5;
            this.tabChangesetGrabber.Text = "TFS Changeset Grabber";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.ChangesetGrabberButtonOpenSaveToFolder);
            this.groupBox12.Controls.Add(this.ChangesetGrabberButtonLoadToFileSystem);
            this.groupBox12.Controls.Add(this.ChangesetGrabberCheckboxReplaceExistingFiles);
            this.groupBox12.Controls.Add(this.ChangesetGrabberCheckboxBackupExistingFiles);
            this.groupBox12.Controls.Add(this.label9);
            this.groupBox12.Controls.Add(this.ChangesetGrabberTextSaveToFolder);
            this.groupBox12.Location = new System.Drawing.Point(12, 525);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(1099, 47);
            this.groupBox12.TabIndex = 32;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Load Changeset to File System";
            // 
            // ChangesetGrabberButtonOpenSaveToFolder
            // 
            this.ChangesetGrabberButtonOpenSaveToFolder.Location = new System.Drawing.Point(873, 15);
            this.ChangesetGrabberButtonOpenSaveToFolder.Name = "ChangesetGrabberButtonOpenSaveToFolder";
            this.ChangesetGrabberButtonOpenSaveToFolder.Size = new System.Drawing.Size(165, 23);
            this.ChangesetGrabberButtonOpenSaveToFolder.TabIndex = 4;
            this.ChangesetGrabberButtonOpenSaveToFolder.Text = "Open Save To Folder";
            this.ChangesetGrabberButtonOpenSaveToFolder.UseVisualStyleBackColor = true;
            this.ChangesetGrabberButtonOpenSaveToFolder.Click += new System.EventHandler(this.ChangesetGrabberButtonOpenSaveToFolder_Click);
            // 
            // ChangesetGrabberButtonLoadToFileSystem
            // 
            this.ChangesetGrabberButtonLoadToFileSystem.Location = new System.Drawing.Point(702, 15);
            this.ChangesetGrabberButtonLoadToFileSystem.Name = "ChangesetGrabberButtonLoadToFileSystem";
            this.ChangesetGrabberButtonLoadToFileSystem.Size = new System.Drawing.Size(165, 23);
            this.ChangesetGrabberButtonLoadToFileSystem.TabIndex = 3;
            this.ChangesetGrabberButtonLoadToFileSystem.Text = "Load To File System";
            this.ChangesetGrabberButtonLoadToFileSystem.UseVisualStyleBackColor = true;
            this.ChangesetGrabberButtonLoadToFileSystem.Click += new System.EventHandler(this.ChangesetGrabberButtonLoadToFileSystem_Click);
            // 
            // ChangesetGrabberCheckboxReplaceExistingFiles
            // 
            this.ChangesetGrabberCheckboxReplaceExistingFiles.AutoSize = true;
            this.ChangesetGrabberCheckboxReplaceExistingFiles.Location = new System.Drawing.Point(6, 19);
            this.ChangesetGrabberCheckboxReplaceExistingFiles.Name = "ChangesetGrabberCheckboxReplaceExistingFiles";
            this.ChangesetGrabberCheckboxReplaceExistingFiles.Size = new System.Drawing.Size(135, 17);
            this.ChangesetGrabberCheckboxReplaceExistingFiles.TabIndex = 0;
            this.ChangesetGrabberCheckboxReplaceExistingFiles.Text = "Replace Existing Files?";
            this.ChangesetGrabberCheckboxReplaceExistingFiles.UseVisualStyleBackColor = true;
            // 
            // ChangesetGrabberCheckboxBackupExistingFiles
            // 
            this.ChangesetGrabberCheckboxBackupExistingFiles.AutoSize = true;
            this.ChangesetGrabberCheckboxBackupExistingFiles.Location = new System.Drawing.Point(147, 19);
            this.ChangesetGrabberCheckboxBackupExistingFiles.Name = "ChangesetGrabberCheckboxBackupExistingFiles";
            this.ChangesetGrabberCheckboxBackupExistingFiles.Size = new System.Drawing.Size(132, 17);
            this.ChangesetGrabberCheckboxBackupExistingFiles.TabIndex = 1;
            this.ChangesetGrabberCheckboxBackupExistingFiles.Text = "Backup Existing Files?";
            this.ChangesetGrabberCheckboxBackupExistingFiles.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(285, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Save to Folder:";
            // 
            // ChangesetGrabberTextSaveToFolder
            // 
            this.ChangesetGrabberTextSaveToFolder.Location = new System.Drawing.Point(370, 17);
            this.ChangesetGrabberTextSaveToFolder.Name = "ChangesetGrabberTextSaveToFolder";
            this.ChangesetGrabberTextSaveToFolder.Size = new System.Drawing.Size(326, 20);
            this.ChangesetGrabberTextSaveToFolder.TabIndex = 2;
            this.ChangesetGrabberTextSaveToFolder.Text = "c:\\temp\\F&ICafeDev-Model Changesets";
            this.ChangesetGrabberTextSaveToFolder.Leave += new System.EventHandler(this.ChangesetGrabberTextSaveToFolder_Leave);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.ChangesetGrabberDataGridChangesetFiles);
            this.groupBox11.Location = new System.Drawing.Point(6, 335);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(1105, 184);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Changeset Files";
            // 
            // ChangesetGrabberDataGridChangesetFiles
            // 
            this.ChangesetGrabberDataGridChangesetFiles.AutoGenerateColumns = false;
            this.ChangesetGrabberDataGridChangesetFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ChangesetGrabberDataGridChangesetFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChangesetGrabberDataGridChangesetFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.changeTypeDataGridViewTextBoxColumn,
            this.serverItemDataGridViewTextBoxColumn,
            this.itemTypeDataGridViewTextBoxColumn});
            this.ChangesetGrabberDataGridChangesetFiles.DataSource = this.changeItemDetailsBindingSource;
            this.ChangesetGrabberDataGridChangesetFiles.Location = new System.Drawing.Point(6, 19);
            this.ChangesetGrabberDataGridChangesetFiles.Name = "ChangesetGrabberDataGridChangesetFiles";
            this.ChangesetGrabberDataGridChangesetFiles.ReadOnly = true;
            this.ChangesetGrabberDataGridChangesetFiles.Size = new System.Drawing.Size(1093, 159);
            this.ChangesetGrabberDataGridChangesetFiles.TabIndex = 0;
            // 
            // changeTypeDataGridViewTextBoxColumn
            // 
            this.changeTypeDataGridViewTextBoxColumn.DataPropertyName = "ChangeType";
            this.changeTypeDataGridViewTextBoxColumn.HeaderText = "ChangeType";
            this.changeTypeDataGridViewTextBoxColumn.Name = "changeTypeDataGridViewTextBoxColumn";
            this.changeTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.changeTypeDataGridViewTextBoxColumn.Width = 93;
            // 
            // serverItemDataGridViewTextBoxColumn
            // 
            this.serverItemDataGridViewTextBoxColumn.DataPropertyName = "ServerItem";
            this.serverItemDataGridViewTextBoxColumn.HeaderText = "ServerItem";
            this.serverItemDataGridViewTextBoxColumn.Name = "serverItemDataGridViewTextBoxColumn";
            this.serverItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.serverItemDataGridViewTextBoxColumn.Width = 83;
            // 
            // itemTypeDataGridViewTextBoxColumn
            // 
            this.itemTypeDataGridViewTextBoxColumn.DataPropertyName = "ItemType";
            this.itemTypeDataGridViewTextBoxColumn.HeaderText = "ItemType";
            this.itemTypeDataGridViewTextBoxColumn.Name = "itemTypeDataGridViewTextBoxColumn";
            this.itemTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemTypeDataGridViewTextBoxColumn.Width = 76;
            // 
            // changeItemDetailsBindingSource
            // 
            this.changeItemDetailsBindingSource.DataSource = typeof(DevToolsAndReferenceAnalyzer.ChangesetGrabberClasses.ChangeItemDetails);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.ChangesetGrabberDataGridChangesets);
            this.groupBox10.Location = new System.Drawing.Point(3, 88);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(1108, 325);
            this.groupBox10.TabIndex = 29;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Changesets";
            // 
            // ChangesetGrabberDataGridChangesets
            // 
            this.ChangesetGrabberDataGridChangesets.AllowUserToAddRows = false;
            this.ChangesetGrabberDataGridChangesets.AllowUserToDeleteRows = false;
            this.ChangesetGrabberDataGridChangesets.AutoGenerateColumns = false;
            this.ChangesetGrabberDataGridChangesets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ChangesetGrabberDataGridChangesets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChangesetGrabberDataGridChangesets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.ChangesetGrabberDataGridChangesets.DataSource = this.changesetBindingSource;
            this.ChangesetGrabberDataGridChangesets.Location = new System.Drawing.Point(6, 19);
            this.ChangesetGrabberDataGridChangesets.Name = "ChangesetGrabberDataGridChangesets";
            this.ChangesetGrabberDataGridChangesets.ReadOnly = true;
            this.ChangesetGrabberDataGridChangesets.RowHeadersVisible = false;
            this.ChangesetGrabberDataGridChangesets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ChangesetGrabberDataGridChangesets.Size = new System.Drawing.Size(1096, 220);
            this.ChangesetGrabberDataGridChangesets.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ChangesetId";
            this.dataGridViewTextBoxColumn8.HeaderText = "ChangesetId";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 92;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Comment";
            this.dataGridViewTextBoxColumn4.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 76;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CreationDate";
            this.dataGridViewTextBoxColumn7.HeaderText = "CreationDate";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 94;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Owner";
            this.dataGridViewTextBoxColumn9.HeaderText = "Owner";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 63;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "OwnerDisplayName";
            this.dataGridViewTextBoxColumn10.HeaderText = "OwnerDisplayName";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 125;
            // 
            // changesetBindingSource
            // 
            this.changesetBindingSource.DataSource = typeof(Microsoft.TeamFoundation.VersionControl.Client.Changeset);
            this.changesetBindingSource.CurrentChanged += new System.EventHandler(this.changesetBindingSource_CurrentChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.ChangesetGrabberTextDomainAndUsername);
            this.groupBox9.Controls.Add(this.label14);
            this.groupBox9.Controls.Add(this.ChangesetGrabberTextPassword);
            this.groupBox9.Controls.Add(this.ChangesetGrabberTextTargetBranch);
            this.groupBox9.Controls.Add(this.ChangesetGrabberTextTfsUrl);
            this.groupBox9.Controls.Add(this.ChangesetGrabberTextSourceBranch);
            this.groupBox9.Controls.Add(this.label13);
            this.groupBox9.Controls.Add(this.label10);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Controls.Add(this.ChangesetGrabberButtonRetrieveChangesetList);
            this.groupBox9.Location = new System.Drawing.Point(3, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1108, 76);
            this.groupBox9.TabIndex = 28;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "TFS Connection and Branch Details";
            // 
            // ChangesetGrabberTextDomainAndUsername
            // 
            this.ChangesetGrabberTextDomainAndUsername.Location = new System.Drawing.Point(711, 19);
            this.ChangesetGrabberTextDomainAndUsername.Name = "ChangesetGrabberTextDomainAndUsername";
            this.ChangesetGrabberTextDomainAndUsername.Size = new System.Drawing.Size(147, 20);
            this.ChangesetGrabberTextDomainAndUsername.TabIndex = 1;
            this.ChangesetGrabberTextDomainAndUsername.TextChanged += new System.EventHandler(this.ChangesetGrabberTextDomainAndUsername_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(560, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(145, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Domain\\Username (optional):";
            // 
            // ChangesetGrabberTextPassword
            // 
            this.ChangesetGrabberTextPassword.Location = new System.Drawing.Point(926, 19);
            this.ChangesetGrabberTextPassword.Name = "ChangesetGrabberTextPassword";
            this.ChangesetGrabberTextPassword.Size = new System.Drawing.Size(127, 20);
            this.ChangesetGrabberTextPassword.TabIndex = 2;
            this.ChangesetGrabberTextPassword.UseSystemPasswordChar = true;
            // 
            // ChangesetGrabberTextTargetBranch
            // 
            this.ChangesetGrabberTextTargetBranch.Location = new System.Drawing.Point(573, 45);
            this.ChangesetGrabberTextTargetBranch.Name = "ChangesetGrabberTextTargetBranch";
            this.ChangesetGrabberTextTargetBranch.Size = new System.Drawing.Size(358, 20);
            this.ChangesetGrabberTextTargetBranch.TabIndex = 4;
            this.ChangesetGrabberTextTargetBranch.Leave += new System.EventHandler(this.ChangesetGrabberTextTargetBranch_Leave);
            // 
            // ChangesetGrabberTextTfsUrl
            // 
            this.ChangesetGrabberTextTfsUrl.Location = new System.Drawing.Point(51, 19);
            this.ChangesetGrabberTextTfsUrl.Name = "ChangesetGrabberTextTfsUrl";
            this.ChangesetGrabberTextTfsUrl.Size = new System.Drawing.Size(503, 20);
            this.ChangesetGrabberTextTfsUrl.TabIndex = 0;
            this.ChangesetGrabberTextTfsUrl.Leave += new System.EventHandler(this.ChangesetGrabberTextTfsUrl_Leave);
            // 
            // ChangesetGrabberTextSourceBranch
            // 
            this.ChangesetGrabberTextSourceBranch.Location = new System.Drawing.Point(93, 46);
            this.ChangesetGrabberTextSourceBranch.Name = "ChangesetGrabberTextSourceBranch";
            this.ChangesetGrabberTextSourceBranch.Size = new System.Drawing.Size(390, 20);
            this.ChangesetGrabberTextSourceBranch.TabIndex = 3;
            this.ChangesetGrabberTextSourceBranch.TextChanged += new System.EventHandler(this.ChangesetGrabberTextSourceBranch_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Tfs Url:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(489, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Parent Branch:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(864, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Password:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Source Branch:";
            // 
            // ChangesetGrabberButtonRetrieveChangesetList
            // 
            this.ChangesetGrabberButtonRetrieveChangesetList.Location = new System.Drawing.Point(937, 43);
            this.ChangesetGrabberButtonRetrieveChangesetList.Name = "ChangesetGrabberButtonRetrieveChangesetList";
            this.ChangesetGrabberButtonRetrieveChangesetList.Size = new System.Drawing.Size(165, 23);
            this.ChangesetGrabberButtonRetrieveChangesetList.TabIndex = 21;
            this.ChangesetGrabberButtonRetrieveChangesetList.Text = "Retreive Changeset List";
            this.ChangesetGrabberButtonRetrieveChangesetList.UseVisualStyleBackColor = true;
            this.ChangesetGrabberButtonRetrieveChangesetList.Click += new System.EventHandler(this.ChangesetGrabberButtonRetrieveChangesetList_Click);
            // 
            // imageListIcons
            // 
            this.imageListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcons.ImageStream")));
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIcons.Images.SetKeyName(0, "ApplicationIcon.png");
            this.imageListIcons.Images.SetKeyName(1, "CleanerIcon.png");
            this.imageListIcons.Images.SetKeyName(2, "AnalysisSettingsIcon.png");
            this.imageListIcons.Images.SetKeyName(3, "ReferenceAnalyerIcon.png");
            this.imageListIcons.Images.SetKeyName(4, "ChangesetLoaderIcon.png");
            // 
            // openSolutionFileDialog
            // 
            this.openSolutionFileDialog.Filter = "VS Solution files|*.sln";
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFormStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 641);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1129, 30);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblFormStatus
            // 
            this.lblFormStatus.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormStatus.Name = "lblFormStatus";
            this.lblFormStatus.Size = new System.Drawing.Size(0, 25);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 671);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "TFS Tools and Reference Analyzer";
            this.tabControl.ResumeLayout(false);
            this.tabPageTfsBindingCleaner.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageSolutionReferenceAnalyzer.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectReferencesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameworkReferencesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryReferencesBindingSource)).EndInit();
            this.tabChangesetGrabber.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChangesetGrabberDataGridChangesetFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeItemDetailsBindingSource)).EndInit();
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChangesetGrabberDataGridChangesets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changesetBindingSource)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectAnalysisSettingsBindingSource)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageTfsBindingCleaner;
        private System.Windows.Forms.Button btnMigrationSelectSolutionFile;
        private System.Windows.Forms.TextBox TfsCleanerTextSolutionFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openSolutionFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button TfsMigrationButtonProcess;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblFormStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TfsMigrationTextResults;
        private System.Windows.Forms.TextBox TfsMigrationTextSolutionBackupFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button TfsMigrationButtonSelectBackupFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.BindingSource projectAnalysisSettingsBindingSource;
        private System.Windows.Forms.TabPage tabPageSolutionReferenceAnalyzer;
        private System.Windows.Forms.ListBox ReferenceAnalyzerListProjectReferences;
        private System.Windows.Forms.ListBox ReferenceAnalyzerListLibraryReferences;
        private System.Windows.Forms.ListBox ReferenceAnalyzerListFrameworkReferences;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource projectReferencesBindingSource;
        private System.Windows.Forms.BindingSource frameworkReferencesBindingSource;
        private System.Windows.Forms.BindingSource libraryReferencesBindingSource;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox ReferenceAnalyzerTextRequiredTargetFramework;
        private System.Windows.Forms.TextBox ReferenceAnalyzerTextAsemblyName;
        private System.Windows.Forms.TextBox ReferenceAnalyzerTextReferenceType;
        private System.Windows.Forms.TextBox ReferenceAnalyzerTextFullyQualifiedName;
        private System.Windows.Forms.TextBox ReferenceAnalyzerTextPath;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ReferenceAnalyzerBtnSelectSolution;
        private System.Windows.Forms.TextBox ReferenceAnalyzerTextSolutionFile;
        private System.Windows.Forms.ListBox ReferenceAnalyzerListProjectsContainingReference;
        private System.Windows.Forms.ImageList imageListIcons;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox ReferenceAnalyzerTextAnalysisResults;
        private System.Windows.Forms.TabPage tabChangesetGrabber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ChangesetGrabberTextSaveToFolder;
        private System.Windows.Forms.TextBox ChangesetGrabberTextTargetBranch;
        private System.Windows.Forms.TextBox ChangesetGrabberTextSourceBranch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button ChangesetGrabberButtonRetrieveChangesetList;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox ChangesetGrabberTextTfsUrl;
        private System.Windows.Forms.TextBox ChangesetGrabberTextPassword;
        private System.Windows.Forms.TextBox ChangesetGrabberTextDomainAndUsername;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.CheckBox ChangesetGrabberCheckboxBackupExistingFiles;
        private System.Windows.Forms.CheckBox ChangesetGrabberCheckboxReplaceExistingFiles;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.DataGridView ChangesetGrabberDataGridChangesetFiles;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.DataGridView ChangesetGrabberDataGridChangesets;
        private System.Windows.Forms.BindingSource changesetBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.BindingSource changeItemDetailsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn changeTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button ChangesetGrabberButtonLoadToFileSystem;
        private System.Windows.Forms.Button ChangesetGrabberButtonOpenSaveToFolder;
        private System.Windows.Forms.Button ReferenceAnalyzerButtonOpenReferencePath;
    }
}