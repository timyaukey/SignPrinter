using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Drawing.Printing;
using System.Printing;
using System.Windows.Forms;
using System.Xml;

using SignLibrary;

namespace SignPrinter
{
    public partial class MainForm : Form
    {
        private SignIterator _SignIterator;
        private bool _PrinterSelected = false;
        private string _TemplatePath = null;
        private string[] _DataPaths = null;
        
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Sign Printer " + Application.ProductVersion;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dlgSelectTemplate.InitialDirectory = Environment.CurrentDirectory;
            dlgSelectData.InitialDirectory = Environment.CurrentDirectory;
        }

        private void btnSelectPrinter_Click(object sender, EventArgs e)
        {
            if (dlgSelectPrinter.ShowDialog() == DialogResult.OK)
            {
                docSign.PrinterSettings = dlgSelectPrinter.PrinterSettings;
                lblPrinter.Text = dlgSelectPrinter.PrinterSettings.PrinterName;
                _PrinterSelected = true;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (OkayToPrint())
            {
                _SignIterator = new SignIterator(_TemplatePath, _DataPaths, GetUserMacros());
                dlgSignPreview.Document = docSign;
                dlgSignPreview.ShowDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_PrinterSelected)
            {
                if (OkayToPrint())
                {
                    _SignIterator = new SignIterator(_TemplatePath, _DataPaths, GetUserMacros());
                    docSign.Print();
                }
            }
            else
            {
                MessageBox.Show("Select a printer first.");
            }
        }

        private bool OkayToPrint()
        {
            if (_TemplatePath == null)
            {
                MessageBox.Show("Select a valid sign template file first.");
                return false;
            }
            if (_DataPaths == null || _DataPaths.Length == 0)
            {
                MessageBox.Show("Select one or more data files first.");
                return false;
            }
            return true;
        }

        private void docSign_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                _SignIterator.Print(e);
            }
            catch (Exception ex)
            {
                SingleSign.ShowException(ex);
            }
        }

        private void btnSelectTemplate_Click(object sender, EventArgs e)
        {
            if (dlgSelectTemplate.ShowDialog() == DialogResult.OK)
            {
                _TemplatePath = dlgSelectTemplate.FileName;
                dlgSelectTemplate.InitialDirectory = Path.GetDirectoryName(_TemplatePath);
                lblTemplateFile.Text = _TemplatePath;
                LoadMacroDefs();
            }
        }

        private void btnSelectData_Click(object sender, EventArgs e)
        {
            if (dlgSelectData.ShowDialog() == DialogResult.OK)
            {
                _DataPaths = dlgSelectData.FileNames;
                lstDataPaths.Items.Clear();
                foreach (string file in _DataPaths)
                {
                    lstDataPaths.Items.Add(file);
                }
                if (_DataPaths.Length > 0)
                {
                    dlgSelectData.InitialDirectory = Path.GetDirectoryName(_DataPaths[0]);
                }
            }
        }

        private void LoadMacroDefs()
        {
            string templateFolder = Path.GetDirectoryName(_TemplatePath);
            string templateFile = Path.GetFileName(_TemplatePath);
            MacroDefinitions macroDefs = new MacroDefinitions();
            SingleSign.LoadMacroDefinitions(templateFile, templateFolder, macroDefs);
            DisplayMacroDef(macroDefs, 0, txtMacro1Name, txtMacro1Value);
            DisplayMacroDef(macroDefs, 1, txtMacro2Name, txtMacro2Value);
            DisplayMacroDef(macroDefs, 2, txtMacro3Name, txtMacro3Value);
        }

        private void DisplayMacroDef(MacroDefinitions macroDefs, int index, TextBox macroNameControl, TextBox macroValueControl)
        {
            macroNameControl.Text = string.Empty;
            macroValueControl.Text = string.Empty;
            if (index < macroDefs.Count)
            {
                macroNameControl.Text = macroDefs[index].Name;
                macroValueControl.Text = macroDefs[index].Value;
            }
        }

        private IDictionary<string, string> GetUserMacros()
        {
            IDictionary<string, string> userMacros = new Dictionary<string, string>();
            AddUserMacro(userMacros, txtMacro1Name, txtMacro1Value);
            AddUserMacro(userMacros, txtMacro2Name, txtMacro2Value);
            AddUserMacro(userMacros, txtMacro3Name, txtMacro3Value);
            return userMacros;
        }

        private void AddUserMacro(IDictionary<string, string> userMacros, TextBox macroName, TextBox macroValue)
        {
            if (!string.IsNullOrEmpty(macroName.Text))
                userMacros[macroName.Text] = macroValue.Text;
        }
    }
}
