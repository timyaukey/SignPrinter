using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Xml;

using SignLibrary;

namespace SignPrinter
{
    public class SignIterator
    {
        private string _TemplatePath;
        private string[] _DataPaths;
        private IDictionary<string, string> _UserMacros;
        private int _SignIndex;
        private int _SignCount;

        public SignIterator(string templatePath, string[] dataPaths, IDictionary<string, string> userMacros)
        {
            _TemplatePath = templatePath;
            _DataPaths = dataPaths;
            _SignIndex = 0;
            _SignCount = _DataPaths.Length;
            _UserMacros = userMacros;
        }

        public void Print(PrintPageEventArgs e)
        {
            string dataPath = _DataPaths[_SignIndex];
            _SignIndex++;
            try
            {
                string dataFile = Path.GetFileName(dataPath);
                string dataFolder = Path.GetDirectoryName(dataPath);
                MacroValues macros = new MacroValues();
                SingleSign.AddStandardMacroValues(macros);
                AddUserMacros(macros);
                XmlDocument dataDoc = SingleSign.CreateEmptySignDataDoc();
                dataDoc.Load(Path.Combine(dataFolder, dataFile));
                SingleSign.AddDataFileMacros(macros, dataFolder, dataDoc);
                string templateFile = Path.GetFileName(_TemplatePath);
                string templateFolder = Path.GetDirectoryName(_TemplatePath);
                SingleSign singleSign = new SingleSign();
                singleSign.Print(templateFile, templateFolder, macros, dataFolder, e);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in sign data file " + dataPath, ex);
            }
            e.HasMorePages = (_SignIndex < _SignCount);
        }

        private void AddUserMacros(IDictionary<string, string> macros)
        {
            foreach (string macroName in _UserMacros.Keys)
            {
                macros[macroName] = _UserMacros[macroName];
            }
        }
    }
}
