using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using PlantLibrary;

namespace PlantSignDesigner
{
    public partial class BulkImageForm : Form
    {
        private string _PlantFolder;
        private IEnumerable<string> _ImageFiles;

        public BulkImageForm()
        {
            InitializeComponent();
        }

        public void ShowImages(IEnumerable<string> imageFiles, string plantFolder)
        {
            _PlantFolder = plantFolder;
            _ImageFiles = imageFiles;
            LoadImageFileList();
            LoadExtraFactList();
            this.ShowDialog();
        }

        private void LoadImageFileList()
        {
            lvwImageFiles.Items.Clear();
            foreach (string imageFile in _ImageFiles)
            {
                string lastGrower = string.Empty;
                ImageInfo imageInfo = new ImageInfo();
                string[] subItems = new string[6];
                subItems[0] = imageFile;
                subItems[1] = string.Empty;
                subItems[2] = string.Empty;
                subItems[3] = string.Empty;
                subItems[4] = string.Empty;
                subItems[5] = string.Empty;
                int factFileIndex = cboExtraFactFile.SelectedIndex;
                ImageNameParser.ExtractPlantFileAttributes(_PlantFolder, imageFile, false, cboExtraFactFile,
                    out imageInfo.OutputNameWithoutType, out imageInfo.NameWords, out imageInfo.EncodedImageName, ref lastGrower);
                cboExtraFactFile.SelectedIndex = factFileIndex;
                imageInfo.PlantFile = imageInfo.OutputNameWithoutType + ".sgndat";
                imageInfo.PlantPath = Path.Combine(_PlantFolder, imageInfo.PlantFile);
                subItems[5] = string.Join(" ", imageInfo.NameWords);
                if (File.Exists(imageInfo.PlantPath))
                {
                    imageInfo.PlantPathExists = true;
                    subItems[1] = imageInfo.PlantFile;
                    XmlDocument plantDoc = new XmlDocument();
                    plantDoc.Load(imageInfo.PlantPath);
                    XmlElement varietyElm = plantDoc.DocumentElement.SelectSingleNode("data[@id='variety']") as XmlElement;
                    if (varietyElm != null)
                        subItems[3] = varietyElm.InnerText;
                    foreach (XmlElement includeElm in plantDoc.DocumentElement.SelectNodes("include"))
                    {
                        string includeFile = includeElm.InnerText;
                        if (includeFile.ToLower() != "facts.sgninc")
                        {
                            subItems[2] = includeFile;
                        }
                    }
                    int varietyTips = 0;
                    foreach (XmlElement dataElm in plantDoc.DocumentElement.SelectNodes("data"))
                    {
                        if (dataElm.GetAttribute("id").StartsWith("varietytip"))
                            varietyTips++;
                    }
                    subItems[4] = varietyTips.ToString();
                }
                ListViewItem item = new ListViewItem(subItems);
                item.Tag = imageInfo;
                lvwImageFiles.Items.Add(item);
            }
        }

        private void LoadExtraFactList()
        {
            cboExtraFactFile.Items.Clear();
            cboExtraFactFile.Items.Add(string.Empty);
            foreach (string filePath in Directory.GetFiles(_PlantFolder, "*.sgninc"))
            {
                string extraPath = Path.GetFileName(filePath);
                if (extraPath.ToLower() != "facts.sgninc")
                    cboExtraFactFile.Items.Add(extraPath);
            }
        }

        private void btnCreatePlantFiles_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to create plant files for all the checked images?",
                "Continue", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            foreach (ListViewItem item in lvwImageFiles.CheckedItems)
            {
                ImageInfo imageInfo = (ImageInfo)item.Tag;
                if (imageInfo.PlantPathExists)
                {
                    if (MessageBox.Show("Plant file \""+ imageInfo.PlantFile + "\" already exists. Do you want to create a new one?",
                        "Continue", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        continue;
                }
                List<string> nameWords = new List<string>(imageInfo.NameWords);
                if (chkRemoveExtraWord.Checked)
                {
                    int factFileIndex = cboExtraFactFile.SelectedIndex;
                    string matchingExtraFactWord = ImageNameParser.ChooseMatchingExtraFact(nameWords, cboExtraFactFile);
                    cboExtraFactFile.SelectedIndex = factFileIndex;
                    if (matchingExtraFactWord != null)
                    {
                        nameWords.Remove(matchingExtraFactWord);
                    }
                }

                StringBuilder content = new StringBuilder();
                content.AppendLine("<container>");
                content.AppendLine("  <data id=\"variety\">" + string.Join(" ", nameWords) + "</data>");
                content.AppendLine("  <data id=\"pic\">" + imageInfo.EncodedImageName + "</data>");
                content.AppendLine("  <include>Facts.sgninc</include>");
                content.AppendLine("</container>");
                using (TextWriter writer = new StreamWriter(imageInfo.PlantPath))
                {
                    writer.Write(content.ToString());
                }
            }
            LoadImageFileList();
        }

        private void btnSetExtraFactFiles_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update extra fact files for all the checked images?",
                "Continue", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            foreach (ListViewItem item in lvwImageFiles.CheckedItems)
            {
                ImageInfo imageInfo = (ImageInfo)item.Tag;
                if (imageInfo.PlantPathExists)
                {
                    XmlDocument plantDoc = new XmlDocument();
                    plantDoc.Load(imageInfo.PlantPath);
                    foreach (XmlElement includeElm in plantDoc.DocumentElement.SelectNodes("include"))
                    {
                        string includeFile = includeElm.InnerText;
                        if (includeFile.ToLower() != "facts.sgninc")
                        {
                            XmlNode parent = includeElm.ParentNode;
                            parent.RemoveChild(includeElm);
                        }
                    }
                    if (!string.IsNullOrEmpty(cboExtraFactFile.Text))
                    {
                        XmlElement includeElm = plantDoc.CreateElement("include");
                        includeElm.InnerText = cboExtraFactFile.Text;
                        plantDoc.DocumentElement.AppendChild(includeElm);
                    }
                    plantDoc.Save(imageInfo.PlantPath);
                }
            }
            LoadImageFileList();
        }
    }

    class ImageInfo
    {
        public string ImageFile = string.Empty;
        public string OutputNameWithoutType = string.Empty;
        public string PlantFile = string.Empty;
        public string PlantPath = string.Empty;
        public bool PlantPathExists = false;
        public List<string> NameWords = new List<string>();
        public string EncodedImageName = string.Empty;
    }
}
