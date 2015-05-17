using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PlantSignDesigner
{
    public partial class FactsFileForm : Form
    {
        private bool _CreateNewFile;

        public FactsFileForm()
        {
            InitializeComponent();
        }

        public void Configure(string filePath, string topBulletsLabel, string bottomBulletsLabel,
            string topBulletsRoot, string bottomBulletsRoot, bool createNewFile)
        {
            lblFactsFileName.Text = filePath;
            plantFacts.TopBulletsLabel = topBulletsLabel;
            plantFacts.BottomBulletsLabel = bottomBulletsLabel;
            plantFacts.TopBulletsRoot = topBulletsRoot;
            plantFacts.BottomBulletsRoot = bottomBulletsRoot;
            _CreateNewFile = createNewFile;
        }

        private void FactsFileForm_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                if (_CreateNewFile)
                    doc.LoadXml("<container/>");
                else
                    doc.Load(lblFactsFileName.Text);
                plantFacts.LoadXML(doc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception reading facts file: " + ex.Message);
                this.DialogResult = DialogResult.Cancel;
                this.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string xml =
                "<container>" + Environment.NewLine +
                plantFacts.CreateXML() +
                "</container>";
            using (TextWriter writer = new StreamWriter(lblFactsFileName.Text))
            {
                writer.Write(xml);
            }
            this.DialogResult = DialogResult.OK;
            this.Visible = false;
        }
    }
}
