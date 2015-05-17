namespace PlantSignDesigner
{
    partial class PlantSignForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlantSignForm));
            this.btnPickPlantFolder = new System.Windows.Forms.Button();
            this.dlgSignFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.lblSignFolder = new System.Windows.Forms.Label();
            this.lstPlantFiles = new System.Windows.Forms.ListBox();
            this.lblPlantFiles = new System.Windows.Forms.Label();
            this.lblImageFiles = new System.Windows.Forms.Label();
            this.lstImageFiles = new System.Windows.Forms.ListBox();
            this.txtVarietyName = new System.Windows.Forms.TextBox();
            this.lblVarietyName = new System.Windows.Forms.Label();
            this.lblPlantFileName = new System.Windows.Forms.Label();
            this.txtPlantFileName = new System.Windows.Forms.TextBox();
            this.cboExtraFactFile = new System.Windows.Forms.ComboBox();
            this.lblExtraFactFile = new System.Windows.Forms.Label();
            this.btnGenerateContents = new System.Windows.Forms.Button();
            this.lblSignFileContents = new System.Windows.Forms.Label();
            this.txtPlantFileContents = new System.Windows.Forms.TextBox();
            this.btnSaveNewFile = new System.Windows.Forms.Button();
            this.lblEncodedImageName = new System.Windows.Forms.Label();
            this.txtEncodedImageName = new System.Windows.Forms.TextBox();
            this.lblTemplateFile = new System.Windows.Forms.Label();
            this.btnPickTemplateFile = new System.Windows.Forms.Button();
            this.dlgSelectTemplate = new System.Windows.Forms.OpenFileDialog();
            this.btnPreviewSign = new System.Windows.Forms.Button();
            this.docSign = new System.Drawing.Printing.PrintDocument();
            this.dlgSignPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.btnExplorePlantFolder = new System.Windows.Forms.Button();
            this.chkRemoveExtraWord = new System.Windows.Forms.CheckBox();
            this.btnEditExtraFacts = new System.Windows.Forms.Button();
            this.btnEditMainFacts = new System.Windows.Forms.Button();
            this.splitLeft = new System.Windows.Forms.SplitContainer();
            this.splitRight = new System.Windows.Forms.SplitContainer();
            this.plantFacts = new PlantSignDesigner.PlantFacts();
            this.splitVariety = new System.Windows.Forms.SplitContainer();
            this.txtVarietyName2 = new System.Windows.Forms.TextBox();
            this.btnCreateFactFiles = new System.Windows.Forms.Button();
            this.btnBulkImageOps = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeft)).BeginInit();
            this.splitLeft.Panel1.SuspendLayout();
            this.splitLeft.Panel2.SuspendLayout();
            this.splitLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.Panel1.SuspendLayout();
            this.splitRight.Panel2.SuspendLayout();
            this.splitRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitVariety)).BeginInit();
            this.splitVariety.Panel1.SuspendLayout();
            this.splitVariety.Panel2.SuspendLayout();
            this.splitVariety.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPickPlantFolder
            // 
            this.btnPickPlantFolder.Location = new System.Drawing.Point(12, 12);
            this.btnPickPlantFolder.Name = "btnPickPlantFolder";
            this.btnPickPlantFolder.Size = new System.Drawing.Size(120, 23);
            this.btnPickPlantFolder.TabIndex = 0;
            this.btnPickPlantFolder.Text = "Pick Plant Folder";
            this.btnPickPlantFolder.UseVisualStyleBackColor = true;
            this.btnPickPlantFolder.Click += new System.EventHandler(this.btnPickPlantFolder_Click);
            // 
            // dlgSignFolder
            // 
            this.dlgSignFolder.ShowNewFolderButton = false;
            // 
            // lblSignFolder
            // 
            this.lblSignFolder.AutoSize = true;
            this.lblSignFolder.Location = new System.Drawing.Point(264, 17);
            this.lblSignFolder.Name = "lblSignFolder";
            this.lblSignFolder.Size = new System.Drawing.Size(37, 13);
            this.lblSignFolder.TabIndex = 1;
            this.lblSignFolder.Text = "(none)";
            // 
            // lstPlantFiles
            // 
            this.lstPlantFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPlantFiles.FormattingEnabled = true;
            this.lstPlantFiles.IntegralHeight = false;
            this.lstPlantFiles.Location = new System.Drawing.Point(3, 20);
            this.lstPlantFiles.Name = "lstPlantFiles";
            this.lstPlantFiles.Size = new System.Drawing.Size(210, 317);
            this.lstPlantFiles.Sorted = true;
            this.lstPlantFiles.TabIndex = 3;
            this.lstPlantFiles.DoubleClick += new System.EventHandler(this.lstPlantFiles_DoubleClick);
            // 
            // lblPlantFiles
            // 
            this.lblPlantFiles.AutoSize = true;
            this.lblPlantFiles.Location = new System.Drawing.Point(0, 4);
            this.lblPlantFiles.Name = "lblPlantFiles";
            this.lblPlantFiles.Size = new System.Drawing.Size(58, 13);
            this.lblPlantFiles.TabIndex = 2;
            this.lblPlantFiles.Text = "Plant Files:";
            // 
            // lblImageFiles
            // 
            this.lblImageFiles.AutoSize = true;
            this.lblImageFiles.Location = new System.Drawing.Point(3, 0);
            this.lblImageFiles.Name = "lblImageFiles";
            this.lblImageFiles.Size = new System.Drawing.Size(63, 13);
            this.lblImageFiles.TabIndex = 4;
            this.lblImageFiles.Text = "Image Files:";
            // 
            // lstImageFiles
            // 
            this.lstImageFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstImageFiles.FormattingEnabled = true;
            this.lstImageFiles.IntegralHeight = false;
            this.lstImageFiles.Location = new System.Drawing.Point(3, 16);
            this.lstImageFiles.Name = "lstImageFiles";
            this.lstImageFiles.Size = new System.Drawing.Size(210, 238);
            this.lstImageFiles.Sorted = true;
            this.lstImageFiles.TabIndex = 5;
            this.lstImageFiles.DoubleClick += new System.EventHandler(this.lstImageFiles_DoubleClick);
            // 
            // txtVarietyName
            // 
            this.txtVarietyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVarietyName.Location = new System.Drawing.Point(0, 0);
            this.txtVarietyName.Name = "txtVarietyName";
            this.txtVarietyName.Size = new System.Drawing.Size(181, 20);
            this.txtVarietyName.TabIndex = 9;
            // 
            // lblVarietyName
            // 
            this.lblVarietyName.AutoSize = true;
            this.lblVarietyName.Location = new System.Drawing.Point(277, 121);
            this.lblVarietyName.Name = "lblVarietyName";
            this.lblVarietyName.Size = new System.Drawing.Size(73, 13);
            this.lblVarietyName.TabIndex = 8;
            this.lblVarietyName.Text = "Variety Name:";
            // 
            // lblPlantFileName
            // 
            this.lblPlantFileName.AutoSize = true;
            this.lblPlantFileName.Location = new System.Drawing.Point(269, 95);
            this.lblPlantFileName.Name = "lblPlantFileName";
            this.lblPlantFileName.Size = new System.Drawing.Size(84, 13);
            this.lblPlantFileName.TabIndex = 6;
            this.lblPlantFileName.Text = "Plant File Name:";
            // 
            // txtPlantFileName
            // 
            this.txtPlantFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlantFileName.Location = new System.Drawing.Point(356, 92);
            this.txtPlantFileName.Name = "txtPlantFileName";
            this.txtPlantFileName.Size = new System.Drawing.Size(349, 20);
            this.txtPlantFileName.TabIndex = 7;
            // 
            // cboExtraFactFile
            // 
            this.cboExtraFactFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboExtraFactFile.FormattingEnabled = true;
            this.cboExtraFactFile.Location = new System.Drawing.Point(356, 193);
            this.cboExtraFactFile.Name = "cboExtraFactFile";
            this.cboExtraFactFile.Size = new System.Drawing.Size(221, 21);
            this.cboExtraFactFile.TabIndex = 13;
            this.cboExtraFactFile.SelectedIndexChanged += new System.EventHandler(this.cboExtraFactFile_SelectedIndexChanged);
            this.cboExtraFactFile.TextUpdate += new System.EventHandler(this.cboExtraFactFile_TextUpdate);
            // 
            // lblExtraFactFile
            // 
            this.lblExtraFactFile.AutoSize = true;
            this.lblExtraFactFile.Location = new System.Drawing.Point(273, 196);
            this.lblExtraFactFile.Name = "lblExtraFactFile";
            this.lblExtraFactFile.Size = new System.Drawing.Size(77, 13);
            this.lblExtraFactFile.TabIndex = 12;
            this.lblExtraFactFile.Text = "Extra Fact File:";
            // 
            // btnGenerateContents
            // 
            this.btnGenerateContents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateContents.Location = new System.Drawing.Point(302, 219);
            this.btnGenerateContents.Name = "btnGenerateContents";
            this.btnGenerateContents.Size = new System.Drawing.Size(173, 23);
            this.btnGenerateContents.TabIndex = 16;
            this.btnGenerateContents.Text = "Generate Plant File Contents";
            this.btnGenerateContents.UseVisualStyleBackColor = true;
            this.btnGenerateContents.Click += new System.EventHandler(this.btnGenerateContents_Click);
            // 
            // lblSignFileContents
            // 
            this.lblSignFileContents.AutoSize = true;
            this.lblSignFileContents.Location = new System.Drawing.Point(16, 6);
            this.lblSignFileContents.Name = "lblSignFileContents";
            this.lblSignFileContents.Size = new System.Drawing.Size(98, 13);
            this.lblSignFileContents.TabIndex = 17;
            this.lblSignFileContents.Text = "Plant File Contents:";
            // 
            // txtPlantFileContents
            // 
            this.txtPlantFileContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlantFileContents.Location = new System.Drawing.Point(120, 3);
            this.txtPlantFileContents.Multiline = true;
            this.txtPlantFileContents.Name = "txtPlantFileContents";
            this.txtPlantFileContents.ReadOnly = true;
            this.txtPlantFileContents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPlantFileContents.Size = new System.Drawing.Size(352, 196);
            this.txtPlantFileContents.TabIndex = 18;
            this.txtPlantFileContents.TextChanged += new System.EventHandler(this.txtPlantFileContents_TextChanged);
            // 
            // btnSaveNewFile
            // 
            this.btnSaveNewFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveNewFile.Location = new System.Drawing.Point(597, 677);
            this.btnSaveNewFile.Name = "btnSaveNewFile";
            this.btnSaveNewFile.Size = new System.Drawing.Size(113, 23);
            this.btnSaveNewFile.TabIndex = 19;
            this.btnSaveNewFile.Text = "Save Plant File";
            this.btnSaveNewFile.UseVisualStyleBackColor = true;
            this.btnSaveNewFile.Click += new System.EventHandler(this.btnSaveNewFile_Click);
            // 
            // lblEncodedImageName
            // 
            this.lblEncodedImageName.AutoSize = true;
            this.lblEncodedImageName.Location = new System.Drawing.Point(234, 170);
            this.lblEncodedImageName.Name = "lblEncodedImageName";
            this.lblEncodedImageName.Size = new System.Drawing.Size(116, 13);
            this.lblEncodedImageName.TabIndex = 10;
            this.lblEncodedImageName.Text = "Encoded Image Name:";
            // 
            // txtEncodedImageName
            // 
            this.txtEncodedImageName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEncodedImageName.Location = new System.Drawing.Point(356, 167);
            this.txtEncodedImageName.Name = "txtEncodedImageName";
            this.txtEncodedImageName.Size = new System.Drawing.Size(221, 20);
            this.txtEncodedImageName.TabIndex = 11;
            // 
            // lblTemplateFile
            // 
            this.lblTemplateFile.AutoSize = true;
            this.lblTemplateFile.Location = new System.Drawing.Point(264, 46);
            this.lblTemplateFile.Name = "lblTemplateFile";
            this.lblTemplateFile.Size = new System.Drawing.Size(37, 13);
            this.lblTemplateFile.TabIndex = 21;
            this.lblTemplateFile.Text = "(none)";
            // 
            // btnPickTemplateFile
            // 
            this.btnPickTemplateFile.Location = new System.Drawing.Point(138, 41);
            this.btnPickTemplateFile.Name = "btnPickTemplateFile";
            this.btnPickTemplateFile.Size = new System.Drawing.Size(120, 23);
            this.btnPickTemplateFile.TabIndex = 20;
            this.btnPickTemplateFile.Text = "Pick Template File";
            this.btnPickTemplateFile.UseVisualStyleBackColor = true;
            this.btnPickTemplateFile.Click += new System.EventHandler(this.btnPickTemplateFile_Click);
            // 
            // dlgSelectTemplate
            // 
            this.dlgSelectTemplate.Filter = "Sign Templates|*.sgntpt";
            // 
            // btnPreviewSign
            // 
            this.btnPreviewSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreviewSign.Location = new System.Drawing.Point(356, 677);
            this.btnPreviewSign.Name = "btnPreviewSign";
            this.btnPreviewSign.Size = new System.Drawing.Size(115, 23);
            this.btnPreviewSign.TabIndex = 22;
            this.btnPreviewSign.Text = "Preview Sign";
            this.btnPreviewSign.UseVisualStyleBackColor = true;
            this.btnPreviewSign.Click += new System.EventHandler(this.btnPreviewSign_Click);
            // 
            // docSign
            // 
            this.docSign.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.docSign_PrintPage);
            // 
            // dlgSignPreview
            // 
            this.dlgSignPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.dlgSignPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.dlgSignPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.dlgSignPreview.Enabled = true;
            this.dlgSignPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("dlgSignPreview.Icon")));
            this.dlgSignPreview.Name = "dlgSignPreview";
            this.dlgSignPreview.Visible = false;
            // 
            // btnExplorePlantFolder
            // 
            this.btnExplorePlantFolder.Location = new System.Drawing.Point(138, 12);
            this.btnExplorePlantFolder.Name = "btnExplorePlantFolder";
            this.btnExplorePlantFolder.Size = new System.Drawing.Size(120, 23);
            this.btnExplorePlantFolder.TabIndex = 23;
            this.btnExplorePlantFolder.Text = "Explore Plant Folder";
            this.btnExplorePlantFolder.UseVisualStyleBackColor = true;
            this.btnExplorePlantFolder.Click += new System.EventHandler(this.btnExplorePlantFolder_Click);
            // 
            // chkRemoveExtraWord
            // 
            this.chkRemoveExtraWord.AutoSize = true;
            this.chkRemoveExtraWord.Location = new System.Drawing.Point(356, 144);
            this.chkRemoveExtraWord.Name = "chkRemoveExtraWord";
            this.chkRemoveExtraWord.Size = new System.Drawing.Size(257, 17);
            this.chkRemoveExtraWord.TabIndex = 24;
            this.chkRemoveExtraWord.Text = "Remove Extra Fact When Creating Variety Name";
            this.chkRemoveExtraWord.UseVisualStyleBackColor = true;
            // 
            // btnEditExtraFacts
            // 
            this.btnEditExtraFacts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditExtraFacts.Location = new System.Drawing.Point(583, 191);
            this.btnEditExtraFacts.Name = "btnEditExtraFacts";
            this.btnEditExtraFacts.Size = new System.Drawing.Size(127, 23);
            this.btnEditExtraFacts.TabIndex = 26;
            this.btnEditExtraFacts.Text = "Edit Extra Fact File";
            this.btnEditExtraFacts.UseVisualStyleBackColor = true;
            this.btnEditExtraFacts.Click += new System.EventHandler(this.btnEditExtraFacts_Click);
            // 
            // btnEditMainFacts
            // 
            this.btnEditMainFacts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditMainFacts.Location = new System.Drawing.Point(583, 165);
            this.btnEditMainFacts.Name = "btnEditMainFacts";
            this.btnEditMainFacts.Size = new System.Drawing.Size(127, 23);
            this.btnEditMainFacts.TabIndex = 27;
            this.btnEditMainFacts.Text = "Edit Folder Fact File";
            this.btnEditMainFacts.UseVisualStyleBackColor = true;
            this.btnEditMainFacts.Click += new System.EventHandler(this.btnEditMainFacts_Click);
            // 
            // splitLeft
            // 
            this.splitLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitLeft.Location = new System.Drawing.Point(12, 99);
            this.splitLeft.Name = "splitLeft";
            this.splitLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitLeft.Panel1
            // 
            this.splitLeft.Panel1.Controls.Add(this.lblPlantFiles);
            this.splitLeft.Panel1.Controls.Add(this.lstPlantFiles);
            // 
            // splitLeft.Panel2
            // 
            this.splitLeft.Panel2.Controls.Add(this.lblImageFiles);
            this.splitLeft.Panel2.Controls.Add(this.lstImageFiles);
            this.splitLeft.Size = new System.Drawing.Size(216, 601);
            this.splitLeft.SplitterDistance = 340;
            this.splitLeft.TabIndex = 28;
            // 
            // splitRight
            // 
            this.splitRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitRight.Location = new System.Drawing.Point(236, 220);
            this.splitRight.Name = "splitRight";
            this.splitRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitRight.Panel1
            // 
            this.splitRight.Panel1.Controls.Add(this.plantFacts);
            this.splitRight.Panel1.Controls.Add(this.btnGenerateContents);
            // 
            // splitRight.Panel2
            // 
            this.splitRight.Panel2.Controls.Add(this.txtPlantFileContents);
            this.splitRight.Panel2.Controls.Add(this.lblSignFileContents);
            this.splitRight.Size = new System.Drawing.Size(475, 451);
            this.splitRight.SplitterDistance = 245;
            this.splitRight.TabIndex = 29;
            // 
            // plantFacts
            // 
            this.plantFacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plantFacts.BottomBulletsLabel = "Bottom Bullets:";
            this.plantFacts.BottomBulletsRoot = null;
            this.plantFacts.BottomBulletsVisible = false;
            this.plantFacts.Location = new System.Drawing.Point(26, 2);
            this.plantFacts.Margin = new System.Windows.Forms.Padding(0);
            this.plantFacts.Name = "plantFacts";
            this.plantFacts.Size = new System.Drawing.Size(447, 216);
            this.plantFacts.TabIndex = 25;
            this.plantFacts.TopBulletsLabel = "Bullet Points:";
            this.plantFacts.TopBulletsRoot = "varietytip";
            // 
            // splitVariety
            // 
            this.splitVariety.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitVariety.Location = new System.Drawing.Point(356, 118);
            this.splitVariety.Name = "splitVariety";
            // 
            // splitVariety.Panel1
            // 
            this.splitVariety.Panel1.Controls.Add(this.txtVarietyName);
            // 
            // splitVariety.Panel2
            // 
            this.splitVariety.Panel2.Controls.Add(this.txtVarietyName2);
            this.splitVariety.Size = new System.Drawing.Size(352, 20);
            this.splitVariety.SplitterDistance = 184;
            this.splitVariety.TabIndex = 30;
            // 
            // txtVarietyName2
            // 
            this.txtVarietyName2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVarietyName2.Location = new System.Drawing.Point(-1, 0);
            this.txtVarietyName2.Name = "txtVarietyName2";
            this.txtVarietyName2.Size = new System.Drawing.Size(162, 20);
            this.txtVarietyName2.TabIndex = 0;
            // 
            // btnCreateFactFiles
            // 
            this.btnCreateFactFiles.Location = new System.Drawing.Point(12, 41);
            this.btnCreateFactFiles.Name = "btnCreateFactFiles";
            this.btnCreateFactFiles.Size = new System.Drawing.Size(120, 23);
            this.btnCreateFactFiles.TabIndex = 31;
            this.btnCreateFactFiles.Text = "Create Fact Files";
            this.btnCreateFactFiles.UseVisualStyleBackColor = true;
            this.btnCreateFactFiles.Click += new System.EventHandler(this.btnCreateFactFiles_Click);
            // 
            // btnBulkImageOps
            // 
            this.btnBulkImageOps.Location = new System.Drawing.Point(12, 70);
            this.btnBulkImageOps.Name = "btnBulkImageOps";
            this.btnBulkImageOps.Size = new System.Drawing.Size(246, 23);
            this.btnBulkImageOps.TabIndex = 32;
            this.btnBulkImageOps.Text = "Bulk Image File Operations";
            this.btnBulkImageOps.UseVisualStyleBackColor = true;
            this.btnBulkImageOps.Click += new System.EventHandler(this.btnBulkImageOps_Click);
            // 
            // PlantSignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 712);
            this.Controls.Add(this.btnBulkImageOps);
            this.Controls.Add(this.btnCreateFactFiles);
            this.Controls.Add(this.splitVariety);
            this.Controls.Add(this.splitRight);
            this.Controls.Add(this.splitLeft);
            this.Controls.Add(this.btnEditMainFacts);
            this.Controls.Add(this.btnEditExtraFacts);
            this.Controls.Add(this.chkRemoveExtraWord);
            this.Controls.Add(this.btnExplorePlantFolder);
            this.Controls.Add(this.btnPreviewSign);
            this.Controls.Add(this.lblTemplateFile);
            this.Controls.Add(this.btnPickTemplateFile);
            this.Controls.Add(this.lblEncodedImageName);
            this.Controls.Add(this.txtEncodedImageName);
            this.Controls.Add(this.btnSaveNewFile);
            this.Controls.Add(this.lblExtraFactFile);
            this.Controls.Add(this.cboExtraFactFile);
            this.Controls.Add(this.lblPlantFileName);
            this.Controls.Add(this.txtPlantFileName);
            this.Controls.Add(this.lblVarietyName);
            this.Controls.Add(this.lblSignFolder);
            this.Controls.Add(this.btnPickPlantFolder);
            this.Name = "PlantSignForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plant Sign Designer";
            this.splitLeft.Panel1.ResumeLayout(false);
            this.splitLeft.Panel1.PerformLayout();
            this.splitLeft.Panel2.ResumeLayout(false);
            this.splitLeft.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeft)).EndInit();
            this.splitLeft.ResumeLayout(false);
            this.splitRight.Panel1.ResumeLayout(false);
            this.splitRight.Panel2.ResumeLayout(false);
            this.splitRight.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            this.splitVariety.Panel1.ResumeLayout(false);
            this.splitVariety.Panel1.PerformLayout();
            this.splitVariety.Panel2.ResumeLayout(false);
            this.splitVariety.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitVariety)).EndInit();
            this.splitVariety.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPickPlantFolder;
        private System.Windows.Forms.FolderBrowserDialog dlgSignFolder;
        private System.Windows.Forms.Label lblSignFolder;
        private System.Windows.Forms.ListBox lstPlantFiles;
        private System.Windows.Forms.Label lblPlantFiles;
        private System.Windows.Forms.Label lblImageFiles;
        private System.Windows.Forms.ListBox lstImageFiles;
        private System.Windows.Forms.TextBox txtVarietyName;
        private System.Windows.Forms.Label lblVarietyName;
        private System.Windows.Forms.Label lblPlantFileName;
        private System.Windows.Forms.TextBox txtPlantFileName;
        private System.Windows.Forms.ComboBox cboExtraFactFile;
        private System.Windows.Forms.Label lblExtraFactFile;
        private System.Windows.Forms.Button btnGenerateContents;
        private System.Windows.Forms.Label lblSignFileContents;
        private System.Windows.Forms.TextBox txtPlantFileContents;
        private System.Windows.Forms.Button btnSaveNewFile;
        private System.Windows.Forms.Label lblEncodedImageName;
        private System.Windows.Forms.TextBox txtEncodedImageName;
        private System.Windows.Forms.Label lblTemplateFile;
        private System.Windows.Forms.Button btnPickTemplateFile;
        private System.Windows.Forms.OpenFileDialog dlgSelectTemplate;
        private System.Windows.Forms.Button btnPreviewSign;
        private System.Drawing.Printing.PrintDocument docSign;
        private System.Windows.Forms.PrintPreviewDialog dlgSignPreview;
        private System.Windows.Forms.Button btnExplorePlantFolder;
        private System.Windows.Forms.CheckBox chkRemoveExtraWord;
        private PlantFacts plantFacts;
        private System.Windows.Forms.Button btnEditExtraFacts;
        private System.Windows.Forms.Button btnEditMainFacts;
        private System.Windows.Forms.SplitContainer splitLeft;
        private System.Windows.Forms.SplitContainer splitRight;
        private System.Windows.Forms.SplitContainer splitVariety;
        private System.Windows.Forms.TextBox txtVarietyName2;
        private System.Windows.Forms.Button btnCreateFactFiles;
        private System.Windows.Forms.Button btnBulkImageOps;
    }
}