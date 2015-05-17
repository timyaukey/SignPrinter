namespace PlantSignDesigner
{
    partial class FactsFileForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFactsFileLabel = new System.Windows.Forms.Label();
            this.lblFactsFileName = new System.Windows.Forms.Label();
            this.plantFacts = new PlantSignDesigner.PlantFacts();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(302, 404);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(383, 404);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblFactsFileLabel
            // 
            this.lblFactsFileLabel.AutoSize = true;
            this.lblFactsFileLabel.Location = new System.Drawing.Point(12, 9);
            this.lblFactsFileLabel.Name = "lblFactsFileLabel";
            this.lblFactsFileLabel.Size = new System.Drawing.Size(86, 13);
            this.lblFactsFileLabel.TabIndex = 3;
            this.lblFactsFileLabel.Text = "Facts File Name:";
            // 
            // lblFactsFileName
            // 
            this.lblFactsFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFactsFileName.Location = new System.Drawing.Point(104, 9);
            this.lblFactsFileName.Name = "lblFactsFileName";
            this.lblFactsFileName.Size = new System.Drawing.Size(354, 18);
            this.lblFactsFileName.TabIndex = 4;
            this.lblFactsFileName.Text = "(none)";
            // 
            // plantFacts
            // 
            this.plantFacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plantFacts.BottomBulletsLabel = "Bottom Bullets:";
            this.plantFacts.BottomBulletsRoot = null;
            this.plantFacts.BottomBulletsVisible = true;
            this.plantFacts.Location = new System.Drawing.Point(9, 27);
            this.plantFacts.Margin = new System.Windows.Forms.Padding(0);
            this.plantFacts.Name = "plantFacts";
            this.plantFacts.Size = new System.Drawing.Size(452, 364);
            this.plantFacts.TabIndex = 0;
            this.plantFacts.TopBulletsLabel = "Top Bullets:";
            this.plantFacts.TopBulletsRoot = null;
            // 
            // FactsFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 439);
            this.Controls.Add(this.lblFactsFileName);
            this.Controls.Add(this.lblFactsFileLabel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.plantFacts);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FactsFileForm";
            this.Text = "Facts File";
            this.Load += new System.EventHandler(this.FactsFileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PlantFacts plantFacts;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFactsFileLabel;
        private System.Windows.Forms.Label lblFactsFileName;
    }
}