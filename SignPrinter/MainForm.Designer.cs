namespace SignPrinter
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.docSign = new System.Drawing.Printing.PrintDocument();
            this.dlgSignPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.btnPreview = new System.Windows.Forms.Button();
            this.dlgSelectPrinter = new System.Windows.Forms.PrintDialog();
            this.btnSelectPrinter = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.btnSelectDataFiles = new System.Windows.Forms.Button();
            this.btnSelectTemplate = new System.Windows.Forms.Button();
            this.lstDataPaths = new System.Windows.Forms.ListBox();
            this.lblTemplateFile = new System.Windows.Forms.Label();
            this.dlgSelectTemplate = new System.Windows.Forms.OpenFileDialog();
            this.dlgSelectData = new System.Windows.Forms.OpenFileDialog();
            this.lblMacro3Name = new System.Windows.Forms.Label();
            this.txtMacro3Name = new System.Windows.Forms.TextBox();
            this.txtMacro3Value = new System.Windows.Forms.TextBox();
            this.lblMacro3Value = new System.Windows.Forms.Label();
            this.txtMacro2Value = new System.Windows.Forms.TextBox();
            this.lblMacro2Value = new System.Windows.Forms.Label();
            this.txtMacro2Name = new System.Windows.Forms.TextBox();
            this.lblMacro2Name = new System.Windows.Forms.Label();
            this.txtMacro1Value = new System.Windows.Forms.TextBox();
            this.lblMacro1Value = new System.Windows.Forms.Label();
            this.txtMacro1Name = new System.Windows.Forms.TextBox();
            this.lblMacro1Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(12, 128);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(119, 23);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Preview Signs";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // dlgSelectPrinter
            // 
            this.dlgSelectPrinter.UseEXDialog = true;
            // 
            // btnSelectPrinter
            // 
            this.btnSelectPrinter.Location = new System.Drawing.Point(12, 12);
            this.btnSelectPrinter.Name = "btnSelectPrinter";
            this.btnSelectPrinter.Size = new System.Drawing.Size(119, 23);
            this.btnSelectPrinter.TabIndex = 1;
            this.btnSelectPrinter.Text = "Select Printer";
            this.btnSelectPrinter.UseVisualStyleBackColor = true;
            this.btnSelectPrinter.Click += new System.EventHandler(this.btnSelectPrinter_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 99);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(119, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print Signs";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Location = new System.Drawing.Point(137, 17);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(97, 13);
            this.lblPrinter.TabIndex = 3;
            this.lblPrinter.Text = "(none selected yet)";
            // 
            // btnSelectDataFiles
            // 
            this.btnSelectDataFiles.Location = new System.Drawing.Point(12, 70);
            this.btnSelectDataFiles.Name = "btnSelectDataFiles";
            this.btnSelectDataFiles.Size = new System.Drawing.Size(119, 23);
            this.btnSelectDataFiles.TabIndex = 4;
            this.btnSelectDataFiles.Text = "Select Plant Files";
            this.btnSelectDataFiles.UseVisualStyleBackColor = true;
            this.btnSelectDataFiles.Click += new System.EventHandler(this.btnSelectData_Click);
            // 
            // btnSelectTemplate
            // 
            this.btnSelectTemplate.Location = new System.Drawing.Point(12, 41);
            this.btnSelectTemplate.Name = "btnSelectTemplate";
            this.btnSelectTemplate.Size = new System.Drawing.Size(119, 23);
            this.btnSelectTemplate.TabIndex = 5;
            this.btnSelectTemplate.Text = "Select Template File";
            this.btnSelectTemplate.UseVisualStyleBackColor = true;
            this.btnSelectTemplate.Click += new System.EventHandler(this.btnSelectTemplate_Click);
            // 
            // lstDataPaths
            // 
            this.lstDataPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDataPaths.FormattingEnabled = true;
            this.lstDataPaths.IntegralHeight = false;
            this.lstDataPaths.Location = new System.Drawing.Point(140, 70);
            this.lstDataPaths.Name = "lstDataPaths";
            this.lstDataPaths.Size = new System.Drawing.Size(380, 236);
            this.lstDataPaths.TabIndex = 6;
            // 
            // lblTemplateFile
            // 
            this.lblTemplateFile.AutoSize = true;
            this.lblTemplateFile.Location = new System.Drawing.Point(137, 46);
            this.lblTemplateFile.Name = "lblTemplateFile";
            this.lblTemplateFile.Size = new System.Drawing.Size(97, 13);
            this.lblTemplateFile.TabIndex = 7;
            this.lblTemplateFile.Text = "(none selected yet)";
            // 
            // dlgSelectTemplate
            // 
            this.dlgSelectTemplate.Filter = "Sign Templates|*.sgntpt";
            // 
            // dlgSelectData
            // 
            this.dlgSelectData.Filter = "Sign Files|*.sgndat";
            this.dlgSelectData.Multiselect = true;
            // 
            // lblMacro3Name
            // 
            this.lblMacro3Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMacro3Name.AutoSize = true;
            this.lblMacro3Name.Location = new System.Drawing.Point(54, 367);
            this.lblMacro3Name.Name = "lblMacro3Name";
            this.lblMacro3Name.Size = new System.Drawing.Size(80, 13);
            this.lblMacro3Name.TabIndex = 8;
            this.lblMacro3Name.Text = "Macro 3 Name:";
            // 
            // txtMacro3Name
            // 
            this.txtMacro3Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMacro3Name.Location = new System.Drawing.Point(140, 364);
            this.txtMacro3Name.Name = "txtMacro3Name";
            this.txtMacro3Name.Size = new System.Drawing.Size(115, 20);
            this.txtMacro3Name.TabIndex = 9;
            // 
            // txtMacro3Value
            // 
            this.txtMacro3Value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMacro3Value.Location = new System.Drawing.Point(373, 364);
            this.txtMacro3Value.Name = "txtMacro3Value";
            this.txtMacro3Value.Size = new System.Drawing.Size(147, 20);
            this.txtMacro3Value.TabIndex = 11;
            // 
            // lblMacro3Value
            // 
            this.lblMacro3Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMacro3Value.AutoSize = true;
            this.lblMacro3Value.Location = new System.Drawing.Point(288, 367);
            this.lblMacro3Value.Name = "lblMacro3Value";
            this.lblMacro3Value.Size = new System.Drawing.Size(79, 13);
            this.lblMacro3Value.TabIndex = 10;
            this.lblMacro3Value.Text = "Macro 3 Value:";
            // 
            // txtMacro2Value
            // 
            this.txtMacro2Value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMacro2Value.Location = new System.Drawing.Point(373, 338);
            this.txtMacro2Value.Name = "txtMacro2Value";
            this.txtMacro2Value.Size = new System.Drawing.Size(147, 20);
            this.txtMacro2Value.TabIndex = 15;
            // 
            // lblMacro2Value
            // 
            this.lblMacro2Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMacro2Value.AutoSize = true;
            this.lblMacro2Value.Location = new System.Drawing.Point(288, 341);
            this.lblMacro2Value.Name = "lblMacro2Value";
            this.lblMacro2Value.Size = new System.Drawing.Size(79, 13);
            this.lblMacro2Value.TabIndex = 14;
            this.lblMacro2Value.Text = "Macro 2 Value:";
            // 
            // txtMacro2Name
            // 
            this.txtMacro2Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMacro2Name.Location = new System.Drawing.Point(140, 338);
            this.txtMacro2Name.Name = "txtMacro2Name";
            this.txtMacro2Name.Size = new System.Drawing.Size(115, 20);
            this.txtMacro2Name.TabIndex = 13;
            // 
            // lblMacro2Name
            // 
            this.lblMacro2Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMacro2Name.AutoSize = true;
            this.lblMacro2Name.Location = new System.Drawing.Point(54, 341);
            this.lblMacro2Name.Name = "lblMacro2Name";
            this.lblMacro2Name.Size = new System.Drawing.Size(80, 13);
            this.lblMacro2Name.TabIndex = 12;
            this.lblMacro2Name.Text = "Macro 2 Name:";
            // 
            // txtMacro1Value
            // 
            this.txtMacro1Value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMacro1Value.Location = new System.Drawing.Point(373, 312);
            this.txtMacro1Value.Name = "txtMacro1Value";
            this.txtMacro1Value.Size = new System.Drawing.Size(147, 20);
            this.txtMacro1Value.TabIndex = 19;
            // 
            // lblMacro1Value
            // 
            this.lblMacro1Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMacro1Value.AutoSize = true;
            this.lblMacro1Value.Location = new System.Drawing.Point(288, 315);
            this.lblMacro1Value.Name = "lblMacro1Value";
            this.lblMacro1Value.Size = new System.Drawing.Size(79, 13);
            this.lblMacro1Value.TabIndex = 18;
            this.lblMacro1Value.Text = "Macro 1 Value:";
            // 
            // txtMacro1Name
            // 
            this.txtMacro1Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMacro1Name.Location = new System.Drawing.Point(140, 312);
            this.txtMacro1Name.Name = "txtMacro1Name";
            this.txtMacro1Name.Size = new System.Drawing.Size(115, 20);
            this.txtMacro1Name.TabIndex = 17;
            // 
            // lblMacro1Name
            // 
            this.lblMacro1Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMacro1Name.AutoSize = true;
            this.lblMacro1Name.Location = new System.Drawing.Point(54, 315);
            this.lblMacro1Name.Name = "lblMacro1Name";
            this.lblMacro1Name.Size = new System.Drawing.Size(80, 13);
            this.lblMacro1Name.TabIndex = 16;
            this.lblMacro1Name.Text = "Macro 1 Name:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 396);
            this.Controls.Add(this.txtMacro1Value);
            this.Controls.Add(this.lblMacro1Value);
            this.Controls.Add(this.txtMacro1Name);
            this.Controls.Add(this.lblMacro1Name);
            this.Controls.Add(this.txtMacro2Value);
            this.Controls.Add(this.lblMacro2Value);
            this.Controls.Add(this.txtMacro2Name);
            this.Controls.Add(this.lblMacro2Name);
            this.Controls.Add(this.txtMacro3Value);
            this.Controls.Add(this.lblMacro3Value);
            this.Controls.Add(this.txtMacro3Name);
            this.Controls.Add(this.lblMacro3Name);
            this.Controls.Add(this.lblTemplateFile);
            this.Controls.Add(this.lstDataPaths);
            this.Controls.Add(this.btnSelectTemplate);
            this.Controls.Add(this.btnSelectDataFiles);
            this.Controls.Add(this.lblPrinter);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSelectPrinter);
            this.Controls.Add(this.btnPreview);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Signs";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Drawing.Printing.PrintDocument docSign;
        private System.Windows.Forms.PrintPreviewDialog dlgSignPreview;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.PrintDialog dlgSelectPrinter;
        private System.Windows.Forms.Button btnSelectPrinter;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.Button btnSelectDataFiles;
        private System.Windows.Forms.Button btnSelectTemplate;
        private System.Windows.Forms.ListBox lstDataPaths;
        private System.Windows.Forms.Label lblTemplateFile;
        private System.Windows.Forms.OpenFileDialog dlgSelectTemplate;
        private System.Windows.Forms.OpenFileDialog dlgSelectData;
        private System.Windows.Forms.Label lblMacro3Name;
        private System.Windows.Forms.TextBox txtMacro3Name;
        private System.Windows.Forms.TextBox txtMacro3Value;
        private System.Windows.Forms.Label lblMacro3Value;
        private System.Windows.Forms.TextBox txtMacro2Value;
        private System.Windows.Forms.Label lblMacro2Value;
        private System.Windows.Forms.TextBox txtMacro2Name;
        private System.Windows.Forms.Label lblMacro2Name;
        private System.Windows.Forms.TextBox txtMacro1Value;
        private System.Windows.Forms.Label lblMacro1Value;
        private System.Windows.Forms.TextBox txtMacro1Name;
        private System.Windows.Forms.Label lblMacro1Name;
    }
}

