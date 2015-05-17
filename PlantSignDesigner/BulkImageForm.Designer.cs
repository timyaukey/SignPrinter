namespace PlantSignDesigner
{
    partial class BulkImageForm
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
            this.lvwImageFiles = new System.Windows.Forms.ListView();
            this.colImageFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlantFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExtraFact = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVariety = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVarietyBullets = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNameWords = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboExtraFactFile = new System.Windows.Forms.ComboBox();
            this.lblExtraFactFile = new System.Windows.Forms.Label();
            this.chkRemoveExtraWord = new System.Windows.Forms.CheckBox();
            this.btnCreatePlantFiles = new System.Windows.Forms.Button();
            this.btnSetExtraFactFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwImageFiles
            // 
            this.lvwImageFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwImageFiles.CheckBoxes = true;
            this.lvwImageFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colImageFile,
            this.colPlantFile,
            this.colExtraFact,
            this.colVariety,
            this.colVarietyBullets,
            this.colNameWords});
            this.lvwImageFiles.FullRowSelect = true;
            this.lvwImageFiles.GridLines = true;
            this.lvwImageFiles.Location = new System.Drawing.Point(12, 12);
            this.lvwImageFiles.Name = "lvwImageFiles";
            this.lvwImageFiles.Size = new System.Drawing.Size(954, 429);
            this.lvwImageFiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwImageFiles.TabIndex = 0;
            this.lvwImageFiles.UseCompatibleStateImageBehavior = false;
            this.lvwImageFiles.View = System.Windows.Forms.View.Details;
            // 
            // colImageFile
            // 
            this.colImageFile.Text = "ImageFile";
            this.colImageFile.Width = 205;
            // 
            // colPlantFile
            // 
            this.colPlantFile.Text = "Plant File";
            this.colPlantFile.Width = 230;
            // 
            // colExtraFact
            // 
            this.colExtraFact.Text = "Extra Fact File";
            this.colExtraFact.Width = 140;
            // 
            // colVariety
            // 
            this.colVariety.Text = "Variety Name";
            this.colVariety.Width = 148;
            // 
            // colVarietyBullets
            // 
            this.colVarietyBullets.Text = "Variety Bullets";
            this.colVarietyBullets.Width = 84;
            // 
            // colNameWords
            // 
            this.colNameWords.Text = "Name Words";
            this.colNameWords.Width = 114;
            // 
            // cboExtraFactFile
            // 
            this.cboExtraFactFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboExtraFactFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExtraFactFile.FormattingEnabled = true;
            this.cboExtraFactFile.Location = new System.Drawing.Point(92, 447);
            this.cboExtraFactFile.Name = "cboExtraFactFile";
            this.cboExtraFactFile.Size = new System.Drawing.Size(188, 21);
            this.cboExtraFactFile.TabIndex = 1;
            // 
            // lblExtraFactFile
            // 
            this.lblExtraFactFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExtraFactFile.AutoSize = true;
            this.lblExtraFactFile.Location = new System.Drawing.Point(9, 450);
            this.lblExtraFactFile.Name = "lblExtraFactFile";
            this.lblExtraFactFile.Size = new System.Drawing.Size(77, 13);
            this.lblExtraFactFile.TabIndex = 2;
            this.lblExtraFactFile.Text = "Extra Fact File:";
            // 
            // chkRemoveExtraWord
            // 
            this.chkRemoveExtraWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRemoveExtraWord.AutoSize = true;
            this.chkRemoveExtraWord.Location = new System.Drawing.Point(298, 449);
            this.chkRemoveExtraWord.Name = "chkRemoveExtraWord";
            this.chkRemoveExtraWord.Size = new System.Drawing.Size(257, 17);
            this.chkRemoveExtraWord.TabIndex = 25;
            this.chkRemoveExtraWord.Text = "Remove Extra Fact When Creating Variety Name";
            this.chkRemoveExtraWord.UseVisualStyleBackColor = true;
            // 
            // btnCreatePlantFiles
            // 
            this.btnCreatePlantFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreatePlantFiles.Location = new System.Drawing.Point(706, 445);
            this.btnCreatePlantFiles.Name = "btnCreatePlantFiles";
            this.btnCreatePlantFiles.Size = new System.Drawing.Size(119, 23);
            this.btnCreatePlantFiles.TabIndex = 26;
            this.btnCreatePlantFiles.Text = "Create Plant Files";
            this.btnCreatePlantFiles.UseVisualStyleBackColor = true;
            this.btnCreatePlantFiles.Click += new System.EventHandler(this.btnCreatePlantFiles_Click);
            // 
            // btnSetExtraFactFiles
            // 
            this.btnSetExtraFactFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetExtraFactFiles.Location = new System.Drawing.Point(831, 445);
            this.btnSetExtraFactFiles.Name = "btnSetExtraFactFiles";
            this.btnSetExtraFactFiles.Size = new System.Drawing.Size(135, 23);
            this.btnSetExtraFactFiles.TabIndex = 27;
            this.btnSetExtraFactFiles.Text = "Set Extra Fact Files";
            this.btnSetExtraFactFiles.UseVisualStyleBackColor = true;
            this.btnSetExtraFactFiles.Click += new System.EventHandler(this.btnSetExtraFactFiles_Click);
            // 
            // BulkImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 486);
            this.Controls.Add(this.btnSetExtraFactFiles);
            this.Controls.Add(this.btnCreatePlantFiles);
            this.Controls.Add(this.chkRemoveExtraWord);
            this.Controls.Add(this.lblExtraFactFile);
            this.Controls.Add(this.cboExtraFactFile);
            this.Controls.Add(this.lvwImageFiles);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BulkImageForm";
            this.ShowInTaskbar = false;
            this.Text = "Bulk Image Operations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwImageFiles;
        private System.Windows.Forms.ColumnHeader colImageFile;
        private System.Windows.Forms.ColumnHeader colExtraFact;
        private System.Windows.Forms.ColumnHeader colVariety;
        private System.Windows.Forms.ColumnHeader colPlantFile;
        private System.Windows.Forms.ComboBox cboExtraFactFile;
        private System.Windows.Forms.Label lblExtraFactFile;
        private System.Windows.Forms.CheckBox chkRemoveExtraWord;
        private System.Windows.Forms.ColumnHeader colVarietyBullets;
        private System.Windows.Forms.Button btnCreatePlantFiles;
        private System.Windows.Forms.Button btnSetExtraFactFiles;
        private System.Windows.Forms.ColumnHeader colNameWords;
    }
}