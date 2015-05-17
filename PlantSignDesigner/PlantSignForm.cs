using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using PlantLibrary;
using SignLibrary;

namespace PlantSignDesigner
{
    public partial class PlantSignForm : Form
    {
        private string _PlantFolder;
        private string _TemplatePath;
        private const string _ImageUsedPrefix = "--";
        private string _LastGrower = "PE";
        private bool _PlantHasChanged = false;
        private bool _PlantIsNew = false;
        private bool _CreateNewExtraFacts = false;
        private bool _ExtraFactsFileExists = false;

        public PlantSignForm()
        {
            InitializeComponent();
            this.Text = "Plant Sign Designer " + Application.ProductVersion;
            dlgSignFolder.SelectedPath = Environment.CurrentDirectory;
            dlgSelectTemplate.InitialDirectory = Environment.CurrentDirectory;
            ConfigEditFolderFacts();
            ConfigEditExtraFacts();
        }

        private void Clear()
        {
            txtPlantFileName.Clear();
            txtVarietyName.Clear();
            txtVarietyName2.Clear();
            txtEncodedImageName.Clear();
            cboExtraFactFile.SelectedIndex = -1;
            cboExtraFactFile.Text = string.Empty;
            plantFacts.Clear();
            txtPlantFileContents.Clear();
            _PlantHasChanged = false;
            _PlantIsNew = false;
        }

        private void btnPickPlantFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgSignFolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (DeclineToDiscardChanges())
                    return;
                _PlantFolder = dlgSignFolder.SelectedPath;
                lblSignFolder.Text = _PlantFolder;

                ShowPlantFolderContents();
                Clear();
                ShowExtraFactFiles();
                ConfigEditFolderFacts();
            }
        }

        private void ShowPlantFolderContents()
        {
            List<string> signBareNames = new List<string>();
            lstPlantFiles.Items.Clear();
            foreach (string filePath in Directory.GetFiles(_PlantFolder, "*.sgndat"))
            {
                string signFileName = Path.GetFileName(filePath);
                signBareNames.Add(Path.GetFileNameWithoutExtension(signFileName));
                lstPlantFiles.Items.Add(signFileName);
            }

            lstImageFiles.Items.Clear();
            foreach (string filePath in Directory.GetFiles(_PlantFolder, "*.jpg"))
            {
                string imageFileName = Path.GetFileName(filePath);
                string outputNameWithoutType;
                ImageNameParser.ParseFileName(imageFileName, out outputNameWithoutType, ref _LastGrower);
                if (signBareNames.Contains(outputNameWithoutType))
                    imageFileName = _ImageUsedPrefix + imageFileName;
                lstImageFiles.Items.Add(imageFileName);
            }

            _PlantHasChanged = false;
            _PlantIsNew = false;
        }

        private void ShowExtraFactFiles()
        {
            cboExtraFactFile.Items.Clear();
            cboExtraFactFile.Text = string.Empty;
            cboExtraFactFile.Items.Add(string.Empty);
            foreach (string filePath in Directory.GetFiles(_PlantFolder, "*.sgninc"))
            {
                string extraPath = Path.GetFileName(filePath);
                if (extraPath.ToLower() != "facts.sgninc")
                    cboExtraFactFile.Items.Add(extraPath);
            }
        }

        private void ConfigEditFolderFacts()
        {
            if (string.IsNullOrEmpty(_PlantFolder))
            {
                btnEditMainFacts.Enabled = false;
                return;
            }
            btnEditMainFacts.Enabled = File.Exists(Path.Combine(_PlantFolder, "facts.sgninc"));
        }

        private void ConfigEditExtraFacts()
        {
            _ExtraFactsFileExists = false;
            if (!cboExtraFactFile.Text.ToLower().EndsWith(".sgninc")||
                !btnEditMainFacts.Enabled)
            {
                btnEditExtraFacts.Enabled = false;
                _CreateNewExtraFacts = false;
                return;
            }
            btnEditExtraFacts.Enabled = true;
            if (File.Exists(Path.Combine(_PlantFolder, cboExtraFactFile.Text)))
            {
                _CreateNewExtraFacts = false;
                _ExtraFactsFileExists = true;
                btnEditExtraFacts.Text = "Edit Extra Facts File";
            }
            else
            {
                _CreateNewExtraFacts = true;
                btnEditExtraFacts.Text = "Create Extra Facts File";
            }
        }

        private void lstPlantFiles_DoubleClick(object sender, EventArgs e)
        {
            if (DeclineToDiscardChanges())
                return;
            Clear();
            string plantFile = (string)lstPlantFiles.SelectedItem;
            XmlDocument plantDoc = SingleSign.CreateEmptySignDataDoc();
            string plantPath = Path.Combine(_PlantFolder, plantFile);
            string plantXML = File.ReadAllText(plantPath);
            txtPlantFileContents.Text = plantXML;
            _PlantHasChanged = false;
            try
            {
                plantDoc.Load(plantPath);
                txtPlantFileName.Text = plantFile;

                XmlNode node;

                node = plantDoc.DocumentElement.SelectSingleNode("data[@id='variety']");
                if (node != null)
                    txtVarietyName.Text = node.InnerText;

                node = plantDoc.DocumentElement.SelectSingleNode("data[@id='variety2']");
                if (node != null)
                    txtVarietyName2.Text = node.InnerText;

                node = plantDoc.DocumentElement.SelectSingleNode("data[@id='pic']");
                if (node != null)
                {
                    txtEncodedImageName.Text = node.InnerText;
                }

                cboExtraFactFile.SelectedIndex = -1;
                cboExtraFactFile.Text = string.Empty;
                foreach (XmlNode includeNode in plantDoc.DocumentElement.SelectNodes("include"))
                {
                    string includeFile = includeNode.InnerText;
                    if (includeFile.ToLower() != "facts.sgninc")
                    {
                        int factFileIndex = 0;
                        foreach (string factFile in cboExtraFactFile.Items)
                        {
                            if (factFile == includeFile)
                            {
                                cboExtraFactFile.SelectedIndex = factFileIndex;
                                break;
                            }
                            factFileIndex++;
                        }
                    }
                }

                plantFacts.LoadXML(plantDoc);

                _PlantIsNew = false;
                _PlantHasChanged = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception reading sign data file: " + ex.Message);
            }
        }

        private bool DeclineToDiscardChanges()
        {
            if (!_PlantHasChanged)
                return false;
            DialogResult result = MessageBox.Show("You have unsaved sign changes. If you continue you will lose them. Do you want to continue?",
                    "Replace File", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.OK)
                return false;
            return true;
        }

        private void lstImageFiles_DoubleClick(object sender, EventArgs e)
        {
            if (DeclineToDiscardChanges())
                return;
            Clear();
            string imageFile = (string)lstImageFiles.SelectedItem;
            if (imageFile.StartsWith(_ImageUsedPrefix))
            {
                imageFile = imageFile.Substring(_ImageUsedPrefix.Length);
                MessageBox.Show("NOTE: There is already a *.SGNDAT file with the same name as this image!");
            }
            string outputNameWithoutType;
            List<string> nameWords;
            string encodedImageName;
            ImageNameParser.ExtractPlantFileAttributes(_PlantFolder, imageFile, chkRemoveExtraWord.Checked, cboExtraFactFile,
                out outputNameWithoutType, out nameWords, out encodedImageName, ref _LastGrower);
            txtEncodedImageName.Text = encodedImageName;
            txtPlantFileName.Text = outputNameWithoutType + ".sgndat";
            txtVarietyName.Text = string.Join(" ", nameWords);
            GenerateContents();
            _PlantIsNew = true;
        }

        private void btnGenerateContents_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboExtraFactFile.Text) && !_ExtraFactsFileExists)
            {
                MessageBox.Show("Extra facts file does not exist. Probably you never clicked the \"Edit\"/\"Create\" " +
                    "button after typing in the extra facts file name, " +
                    "or you clicked \"Cancel\" instead of \"Save\" after entering the extra facts information.");
                return;
            }
            GenerateContents();
        }

        private void GenerateContents()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("<container>");
            if (!string.IsNullOrEmpty(txtVarietyName.Text.Trim()))
            {
                output.AppendLine("  <data id=\"variety\">" + txtVarietyName.Text.Trim() + "</data>");
            }
            if (!string.IsNullOrEmpty(txtVarietyName2.Text.Trim()))
            {
                output.AppendLine("  <data id=\"variety2\">" + txtVarietyName2.Text.Trim() + "</data>");
            }
            output.AppendLine("  <data id=\"pic\">" + txtEncodedImageName.Text + "</data>");
            output.AppendLine("  <include>Facts.sgninc</include>");
            if (!string.IsNullOrEmpty(cboExtraFactFile.Text))
            {
                output.AppendLine("  <include>" + cboExtraFactFile.Text + "</include>");
            }
            output.Append(plantFacts.CreateXML());
            output.AppendLine("</container>");
            txtPlantFileContents.Text = output.ToString();
            _PlantHasChanged = true;
        }

        private void btnPickTemplateFile_Click(object sender, EventArgs e)
        {
            if (dlgSelectTemplate.ShowDialog() == DialogResult.OK)
            {
                _TemplatePath = dlgSelectTemplate.FileName;
                dlgSelectTemplate.InitialDirectory = Path.GetDirectoryName(_TemplatePath);
                lblTemplateFile.Text = _TemplatePath;
            }
        }

        private void btnPreviewSign_Click(object sender, EventArgs e)
        {
            if (_PlantFolder == null)
            {
                SayPickPlantFolder();
                return;
            }
            if (_TemplatePath == null)
            {
                MessageBox.Show("Pick a sign template first");
                return;
            }
            if (string.IsNullOrEmpty(txtPlantFileContents.Text))
            {
                MessageBox.Show("Plant file contents may not be empty");
                return;
            }
            InsureMainFactsExist();
            dlgSignPreview.Document = docSign;
            dlgSignPreview.ShowDialog();
        }

        private void docSign_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                string dataFolder = _PlantFolder;
                string templateFile = Path.GetFileName(_TemplatePath);
                string templateFolder = Path.GetDirectoryName(_TemplatePath);
                MacroDefinitions macroDefs = new MacroDefinitions();
                SingleSign.LoadMacroDefinitions(templateFile, templateFolder, macroDefs);
                MacroValues macros = new MacroValues();
                SingleSign.AddStandardMacroValues(macros);
                foreach (MacroDefinition macroDef in macroDefs)
                {
                    macros[macroDef.Name] = macroDef.Value;
                }
                XmlDocument dataDoc = SingleSign.CreateEmptySignDataDoc();
                dataDoc.LoadXml(txtPlantFileContents.Text);
                SingleSign.AddDataFileMacros(macros, dataFolder, dataDoc);
                SingleSign singleSign = new SingleSign();
                singleSign.Print(templateFile, templateFolder, macros, dataFolder, e);
                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                SingleSign.ShowException(ex);
            }
        }

        private void btnSaveNewFile_Click(object sender, EventArgs e)
        {
            if (_PlantFolder == null)
            {
                SayPickPlantFolder();
                return;
            }
            string outputSignFile = Path.Combine(_PlantFolder, txtPlantFileName.Text);
            InsureMainFactsExist();
            //MessageBox.Show(outputSignFile);
            if (File.Exists(outputSignFile) & _PlantIsNew)
            {
                DialogResult buttonResult;
                buttonResult = MessageBox.Show(
                    "Output sign file [" + txtPlantFileName.Text + "] already exists. Do you want to replace it?",
                    "Replace File", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (buttonResult != DialogResult.OK)
                    return;
                buttonResult = MessageBox.Show(
                    "You double-clicked on an image file for which a sign already exists. " + 
                    "If you save you will lose the old sign, replacing it with the brand new one you just created. " +
                    "This is probably not what you intended. Do you want to replace the old sign file?",
                    "Replace File", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (buttonResult != DialogResult.OK)
                    return;
            }
            //MessageBox.Show("Will save sign file...");
            using (TextWriter writer = new StreamWriter(outputSignFile))
            {
                writer.Write(txtPlantFileContents.Text);
            }
            ShowPlantFolderContents();
        }

        private string GetSignFolderName()
        {
            return ImageNameParser.GetPlantFolderName(_PlantFolder);
        }

        private void InsureMainFactsExist()
        {
            string factsPath = Path.Combine(_PlantFolder, "Facts.sgninc");
            if (!File.Exists(factsPath))
            {
                using (TextWriter writer = new StreamWriter(factsPath))
                {
                    writer.WriteLine("<container>");
                    writer.WriteLine("  <data id=\"title\">" + GetSignFolderName() + "</data>");
                    writer.WriteLine("</container>");
                }
                ConfigEditFolderFacts();
            }
        }

        private void InsureSpecializedFactsExist()
        {
            List<string> colors = new List<string> { "red", "blue", "green", "yellow", "gold", "pink", "orange",
                "cardinal", "white", "violet", "purple", "cream", "blush", "scarlet", "tangerine",
                "crystal", "mix", "rose", "coral", "lemon", "silver", "apricot", "cranberry",
                "lilac", "salmon", "sapphire", "flame", "fire", "lavender", "black", "wine", "cherry",
                "fuchsia", "burgundy", "vanilla" };
            bool fileCreated = false;
            Dictionary<string, WordUsage> words = new Dictionary<string, WordUsage>();
            string signFolderName = GetSignFolderName();
            foreach (string dirFile in Directory.GetFiles(_PlantFolder, "*.jpg"))
            {
                string bareName = Path.GetFileNameWithoutExtension(dirFile);
                foreach (string wordText in ImageNameParser.GetCapitalizedWords(bareName))
                {
                    if (wordText.Length > 2 && wordText != signFolderName)
                    {
                        if (!colors.Contains(wordText.ToLower()))
                        {
                            WordUsage usage;
                            if (words.TryGetValue(wordText, out usage))
                                usage.UseCount++;
                            else
                                words[wordText] = new WordUsage(wordText);
                        }
                    }
                }
            }
            foreach (WordUsage usage in words.Values)
            {
                if (usage.UseCount > 1)
                {
                    string factPath = Path.Combine(_PlantFolder, usage.Text + ".sgninc");
                    if (!File.Exists(factPath))
                    {
                        if (MessageBox.Show("Create extra fact file for \"" + usage.Text + "\"?",
                            "Create", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            using (TextWriter writer = new StreamWriter(factPath))
                            {
                                writer.WriteLine("<container>");
                                if (MessageBox.Show("Show \"" + usage.Text + "\" as separate subtitle line?",
                                    "Subtitle", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    writer.WriteLine("  <data id=\"subtitle\">" + usage.Text + "</data>");
                                }
                                writer.WriteLine("</container>");
                            }
                            fileCreated = true;
                        }
                    }
                }
            }
            if (fileCreated)
                ShowExtraFactFiles();
        }

        private class WordUsage
        {
            public readonly string Text;
            public int UseCount;

            public WordUsage(string text)
            {
                Text = text;
                UseCount = 1;
            }

            public override string ToString()
            {
                return Text + " " + UseCount.ToString();
            }
        }

        private void btnExplorePlantFolder_Click(object sender, EventArgs e)
        {
            if (_PlantFolder == null)
            {
                SayPickPlantFolder();
                return;
            }
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            info.UseShellExecute = true;
            info.FileName = _PlantFolder;
            System.Diagnostics.Process.Start(info);
        }

        private void txtPlantFileContents_TextChanged(object sender, EventArgs e)
        {
            _PlantHasChanged = true;
        }

        // When user types something into combo box.
        private void cboExtraFactFile_TextUpdate(object sender, EventArgs e)
        {
            ConfigEditExtraFacts();
        }

        // When user selects from drop down list.
        private void cboExtraFactFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigEditExtraFacts();
        }

        private void btnEditMainFacts_Click(object sender, EventArgs e)
        {
            using (FactsFileForm form = new FactsFileForm())
            {
                form.Configure(Path.Combine(_PlantFolder, "facts.sgninc"),
                    "Bullets at top of list for all plants in folder:",
                    "Bullets at bottom of list for all plants in folder:",
                    "topfoldertip", "bottomfoldertip", false);
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    MessageBox.Show("File saved.");
                }
            }
        }

        private void btnEditExtraFacts_Click(object sender, EventArgs e)
        {
            using (FactsFileForm form = new FactsFileForm())
            {
                form.Configure(Path.Combine(_PlantFolder, cboExtraFactFile.Text),
                    "Bullets between folder wide bullets at top and variety specific bullets in middle:",
                    "Bullets between folder wide bullets at bottom and variety specific bullets in middle:",
                    "topextratip", "bottomextratip", _CreateNewExtraFacts);
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string fileName = cboExtraFactFile.Text;
                    ShowExtraFactFiles();
                    cboExtraFactFile.Text = fileName;
                    MessageBox.Show("File saved.");
                }
            }
        }

        private void btnCreateFactFiles_Click(object sender, EventArgs e)
        {
            if (_PlantFolder == null)
            {
                SayPickPlantFolder();
                return;
            }
            InsureMainFactsExist();
            InsureSpecializedFactsExist();
            MessageBox.Show("Fact files created.");
        }

        private void btnBulkImageOps_Click(object sender, EventArgs e)
        {
            if (_PlantFolder == null)
            {
                SayPickPlantFolder();
                return;
            }
            List<string> imageFiles = new List<string>();
            foreach (string imageFile in lstImageFiles.Items)
            {
                string normalizedName = imageFile;
                if (imageFile.StartsWith(_ImageUsedPrefix))
                    normalizedName = imageFile.Substring(_ImageUsedPrefix.Length);
                imageFiles.Add(normalizedName);
            }
            using (BulkImageForm frm = new BulkImageForm())
            {
                frm.ShowImages(imageFiles, _PlantFolder);
            }
            ShowPlantFolderContents();
            Clear();
        }

        private static void SayPickPlantFolder()
        {
            MessageBox.Show("Pick a plant folder first");
        }
    }
}
