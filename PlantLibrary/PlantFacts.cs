using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using SignLibrary;

namespace PlantSignDesigner
{
    public partial class PlantFacts : UserControl
    {
        private string _TopBulletsRoot;
        private string _BottomBulletsRoot;

        public PlantFacts()
        {
            InitializeComponent();
        }

        public bool BottomBulletsVisible
        {
            get
            {
                return txtBottomBullets.Visible;
            }
            set
            {
                splitBullets.Panel2Collapsed = !value;
            }
        }

        public void Clear()
        {
            txtTitle1.Clear();
            txtTitle2.Clear();
            chkTitleSmall.Checked = false;
            txtSubtitle1.Clear();
            txtSubtitle2.Clear();
            txtTopBullets.Clear();
            txtBottomBullets.Clear();
        }

        public string TopBulletsLabel
        {
            get { return lblTopBullets.Text; }
            set { lblTopBullets.Text = value; }
        }

        public string BottomBulletsLabel
        {
            get { return lblBottomBullets.Text; }
            set { lblBottomBullets.Text = value; }
        }

        public string TopBulletsRoot
        {
            get { return _TopBulletsRoot; }
            set { _TopBulletsRoot = value; }
        }

        public string BottomBulletsRoot
        {
            get { return _BottomBulletsRoot; }
            set { _BottomBulletsRoot = value; }
        }

        public void LoadXML(XmlDocument doc)
        {
            Clear();
            StringBuilder bullets;
            LoadTextBox(doc, txtTitle1, "title");
            LoadTextBox(doc, txtTitle2, "title2");
            bool titleSmall = LoadTextBox(doc, txtTitle1, "titlesmall");
            bool title2Small = LoadTextBox(doc, txtTitle2, "title2small");
            chkTitleSmall.Checked = titleSmall || title2Small;
            LoadTextBox(doc, txtSubtitle1, "subtitle");
            LoadTextBox(doc, txtSubtitle2, "subtitle2");
            bullets = ExtractMatchingBullets(doc, _TopBulletsRoot);
            txtTopBullets.Text = bullets.ToString();
            if (BottomBulletsVisible)
            {
                bullets = ExtractMatchingBullets(doc, _BottomBulletsRoot);
                txtBottomBullets.Text = bullets.ToString();
            }
        }

        private bool LoadTextBox(XmlDocument doc, TextBox textBox, string id)
        {
            XmlNode node = doc.DocumentElement.SelectSingleNode("data[@id='" + id + "']");
            if (node == null)
                return false;
            textBox.Text = node.InnerText.Trim();
            return true;
        }

        private static StringBuilder ExtractMatchingBullets(XmlDocument signDoc, string bulletsRoot)
        {
            StringBuilder bullets = new StringBuilder();
            foreach (XmlNode bulletNode in signDoc.DocumentElement.SelectNodes("data"))
            {
                XmlElement bulletElm = (XmlElement)bulletNode;
                if (bulletElm.GetAttribute("id").StartsWith(bulletsRoot))
                {
                    if (!string.IsNullOrEmpty(bulletElm.InnerText.Trim()))
                    {
                        bullets.AppendLine(bulletElm.InnerText.Trim());
                    }
                }
            }
            return bullets;
        }

        public string CreateXML()
        {
            StringBuilder output = new StringBuilder();
            AddElement(output, txtTitle1.Text, chkTitleSmall.Checked ? "titlesmall" : "title");
            AddElement(output, txtTitle2.Text, chkTitleSmall.Checked ? "title2small" : "title2");
            AddElement(output, txtSubtitle1.Text, "subtitle");
            AddElement(output, txtSubtitle2.Text, "subtitle2");
            AddBulletPoints(output, txtTopBullets.Text, _TopBulletsRoot);
            if (BottomBulletsVisible)
                AddBulletPoints(output, txtBottomBullets.Text, _BottomBulletsRoot);
            return output.ToString();
        }

        private void AddElement(StringBuilder output, string value, string id)
        {
            if (!string.IsNullOrEmpty(value.Trim()))
            {
                output.AppendLine("  <data id=\"" + id + "\">" +
                    System.Security.SecurityElement.Escape(value.Trim()) + "</data>");
            }
        }

        private void AddBulletPoints(StringBuilder output, string input, string bulletsRoot)
        {
            int lineNumber = 1;
            using (TextReader reader = new StringReader(input))
            {
                for (; ; )
                {
                    string line = reader.ReadLine();
                    if (line == null)
                        break;
                    line = line.Trim();
                    line = line.Replace("\"", "{inch}");
                    while (line.Contains("  "))
                    {
                        line = line.Replace("  ", " ");
                    }
                    line = SingleSign.NormalizeText(line);
                    if (!string.IsNullOrEmpty(line))
                    {
                        System.Security.SecurityElement.Escape(line);
                        output.AppendLine("  <data id=\"" + bulletsRoot + lineNumber.ToString() + "\">" + line + "</data>");
                        lineNumber++;
                    }
                }
            }
        }
    }
}
