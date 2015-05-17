using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SignLibrary
{
    public class SingleSign
    {
        private Graphics _Graphics;
        private Font _Font;
        private string _FontName;
        private float _FontSize;
        private FontStyle _FontStyle;
        private Brush _Brush;
        private PointF _TextPos;
        private float _LeftColumnEdge;
        private float _ColumnWidth;
        private float _SpaceAfter;

        public void Print(string templateFile, string templateFolder, MacroValues macros, string dataFolder, PrintPageEventArgs e)
        {
            Init(e);
            PrintOneTemplate(templateFile, templateFolder, macros, dataFolder);
        }

        private void PrintOneTemplate(string templateFile, string templateFolder, MacroValues macros, string dataFolder)
        {
            string templatePath = Path.Combine(templateFolder, templateFile);
            XmlDocument templateDoc = new XmlDocument();
            templateDoc.Load(templatePath);
            foreach (XmlNode templateNode in templateDoc.DocumentElement.ChildNodes)
            {
                XmlElement cmdElm = templateNode as XmlElement;
                if (cmdElm != null)
                {
                    string cmdName = cmdElm.Name.ToLowerInvariant();
                    switch (cmdName)
                    {
                        case "font":
                            _FontSize = GetRequiredFloatAttrib(cmdElm, "size", macros);
                            _FontName = GetRequiredStringAttrib(cmdElm, "name", macros);
                            CreateFont();
                            break;
                        case "text":
                            PrintText(cmdElm, macros);
                            break;
                        case "image":
                            PrintImage(cmdElm, macros, dataFolder);
                            break;
                        case "line":
                            PrintLine(cmdElm, macros);
                            break;
                        case "style":
                            string styleName = GetRequiredStringAttrib(cmdElm, "name", macros);
                            CreateFontStyle(cmdElm, styleName);
                            CreateFont();
                            break;
                        case "color":
                            string color = GetRequiredStringAttrib(cmdElm, "name", macros);
                            CreateBrush(cmdElm, color);
                            CreateFont();
                            break;
                        case "columnwidth":
                            ColumnWidth(cmdElm, macros);
                            break;
                        case "spaceafter":
                            SpaceAfter(cmdElm, macros);
                            break;
                        case "movedown":
                            MoveDown(cmdElm, macros);
                            break;
                        case "moveright":
                            MoveRight(cmdElm, macros);
                            break;
                        case "textpos":
                            SetTextPos(cmdElm, macros);
                            break;
                        case "macrodef":
                            // Handled by LoadMacroDefinitions().
                            break;
                        case "include":
                            string includePath = TranslateMacroReferences(cmdElm.InnerText, macros);
                            if (string.IsNullOrEmpty(includePath))
                                throw CreateTemplateException(cmdElm, "Missing include file name");
                            PrintOneTemplate(Path.GetFileName(includePath), templateFolder, macros, dataFolder);
                            break;
                        default:
                            throw new ArgumentException("Unrecognized command in sign template: <" + cmdName + ">");
                    }
                }
            }
        }

        private void Init(PrintPageEventArgs e)
        {
            _Graphics = e.Graphics;
            _Graphics.PageUnit = GraphicsUnit.Inch;
            _LeftColumnEdge = 0.0f;
            _TextPos = new PointF(_LeftColumnEdge, 0.0f);
            CreateFontStyle(null, "regular");
            CreateBrush(null, "black");
            _FontName = "arial";
            _FontSize = 12.0f;
            CreateFont();
            _ColumnWidth = 0.0f;
            _SpaceAfter = 0.0f;
        }

        private void CreateBrush(XmlElement cmdElm, string colorName)
        {
            Color color = Color.Black;
            switch (colorName.ToLowerInvariant())
            {
                case "black": color = Color.Black; break;
                case "gray": color = Color.Gray; break;
                case "darkgray": color = Color.DarkGray; break;
                case "lightgray": color = Color.LightGray; break;
                case "red": color = Color.Red; break;
                case "darkred": color = Color.DarkRed; break;
                case "green": color = Color.Green; break;
                case "darkgreen": color = Color.DarkGreen; break;
                case "blue": color = Color.Blue; break;
                case "darkblue": color = Color.DarkBlue; break;
                default: throw CreateTemplateException(cmdElm, "Invalid color name in sign template \"" + colorName + "\"");
            }
            _Brush = new SolidBrush(color);
        }

        private void CreateFontStyle(XmlElement cmdElm, string styleName)
        {
            _FontStyle = FontStyle.Regular;
            switch (styleName.ToLowerInvariant())
            {
                case "regular": _FontStyle = FontStyle.Regular; break;
                case "italic": _FontStyle = FontStyle.Italic; break;
                case "bold": _FontStyle = FontStyle.Bold; break;
                case "bolditalic": _FontStyle = FontStyle.Italic | FontStyle.Bold; break;
                case "underline": _FontStyle = FontStyle.Underline; break;
                case "boldunderline": _FontStyle = FontStyle.Bold | FontStyle.Underline; break;
                default: throw CreateTemplateException(cmdElm, "Invalid style name \"" + styleName + "\"");
            }
        }

        private void CreateFont()
        {
            _Font = new Font(_FontName, _FontSize, _FontStyle);
            SizeF singleLineSize = _Graphics.MeasureString("X", _Font, 1000, StringFormat.GenericTypographic);
        }

        private void SetTextPos(PointF posInches)
        {
            _TextPos = posInches;
            _LeftColumnEdge = _TextPos.X;
        }

        private void SetTextPos(XmlElement cmdElm, MacroValues macros)
        {
            PointF textPos;
            if (TryGetPosition(cmdElm, macros, out textPos))
                SetTextPos(textPos);
            else
                throw CreateTemplateException(cmdElm, "Position attributes are required");
        }

        private void PrintText(XmlElement cmdElm, MacroValues macros)
        {
            PointF textPos;
            if (TryGetPosition(cmdElm, macros, out textPos))
            {
                SetTextPos(textPos);
            }
            string toPrint = GetRequiredStringAttrib(cmdElm, "value", macros);
            toPrint = TranslateMacroReferences(toPrint, macros);
            toPrint = NormalizeText(toPrint);
            if (!string.IsNullOrEmpty(toPrint))
            {
                string prefix;
                if (TryGetAttrib(cmdElm, "prefix", macros, out prefix))
                {
                    prefix = TranslateMacroReferences(prefix, macros);
                }
                else
                {
                    prefix = null;
                }
                float spaceAfter;
                if (!TryGetAttrib(cmdElm, "spaceafter", macros, out spaceAfter))
                    spaceAfter = _SpaceAfter;
                float width;
                if (!TryGetAttrib(cmdElm, "width", macros, out width))
                    width = _ColumnWidth;
                if (width > 0.0f)
                {
                    string discard;
                    bool center = TryGetAttrib(cmdElm, "center", macros, out discard);
                    PrintString(toPrint, prefix, width, center, spaceAfter);
                }
                else
                {
                    PrintString(toPrint, prefix, spaceAfter);
                }
            }
        }
        
        private void PrintString(string content, string prefix, float spaceAfter)
        {
            if (prefix != null)
            {
                SizeF prefixSize = PrintPrefix(prefix);
                _TextPos.X += prefixSize.Width;
            }
            SizeF contentSize = _Graphics.MeasureString(content, _Font, 1000,
                new StringFormat(StringFormatFlags.MeasureTrailingSpaces));
            _Graphics.DrawString(content, _Font, _Brush, _TextPos);
            if (spaceAfter > 0.0f)
                _TextPos.Y += (contentSize.Height + spaceAfter);
            else
                _TextPos.X += contentSize.Width;
        }

        private void PrintString(string content, string prefix, float width, bool center, float spaceAfter)
        {
            SizeF contentSize = _Graphics.MeasureString(content, _Font, new SizeF(width, 1000.0f),
                new StringFormat(StringFormatFlags.MeasureTrailingSpaces));
            RectangleF area;
            if (center)
            {
                float padding = width - contentSize.Width;
                area = new RectangleF(_TextPos.X + padding / 2.0f, _TextPos.Y, 1000.0f, 1000.0f);
            }
            else
            {
                area = new RectangleF(_TextPos, new SizeF(width, 1000.0f));
                if (prefix != null)
                {
                    SizeF prefixSize = PrintPrefix(prefix);
                    area.X += prefixSize.Width;
                    area.Width -= prefixSize.Width;
                    contentSize = _Graphics.MeasureString(content, _Font, new SizeF(area.Width, 1000.0f),
                        new StringFormat(StringFormatFlags.MeasureTrailingSpaces));
                }
            }
            _Graphics.DrawString(content, _Font, _Brush, area);
            _TextPos.Y += (contentSize.Height + spaceAfter);
        }

        private SizeF PrintPrefix(string prefix)
        {
            SizeF prefixSize = _Graphics.MeasureString(prefix, _Font, 1000, new StringFormat(StringFormatFlags.MeasureTrailingSpaces));
            _Graphics.DrawString(prefix, _Font, _Brush, _TextPos);
            return prefixSize;
        }

        private void PrintImage(XmlElement cmdElm, MacroValues macros, string dataFolder)
        {
            PointF imagePos;
            RectangleF imageRect;
            float imageWidth;
            float imageHeight;
            if (!TryGetPosition(cmdElm, macros, out imagePos))
                throw CreateTemplateException(cmdElm, "Image position is required");
            if (!TryGetAttrib(cmdElm, "width", macros, out imageWidth))
                throw CreateTemplateException(cmdElm, "Image width is required");
            if (!TryGetAttrib(cmdElm, "height", macros, out imageHeight))
                imageHeight = 0.0f;
            string fileName = GetRequiredStringAttrib(cmdElm, "file", macros);
            fileName = TranslateMacroReferences(fileName, macros);
            string imagePath = Path.Combine(dataFolder, fileName);
            using (Image image = Image.FromFile(imagePath))
            {
                float aspectRatio = (float)image.Height / (float)image.Width;
                if (imageHeight > 0.0f)
                {
                    float scaledWidth = imageHeight / aspectRatio;
                    imageRect = new RectangleF(imagePos.X + (imageWidth - scaledWidth) / 2.0f, imagePos.Y, scaledWidth, imageHeight);
                }
                else
                {
                    imageRect = new RectangleF(imagePos, new SizeF(imageWidth, imageWidth * aspectRatio));
                }
                _Graphics.DrawImage(image, imageRect);
            }
        }

        private void PrintLine(XmlElement cmdElm, MacroValues macros)
        {
            PointF pos1;
            PointF pos2;
            if (!TryGetPosition(cmdElm, "x1", "y1", macros, out pos1))
                throw CreateTemplateException(cmdElm, "Missing (x1,y1) line endpoint");
            if (!TryGetPosition(cmdElm, "x2", "y2", macros, out pos2))
                throw CreateTemplateException(cmdElm, "Missing (x2,y2) line endpoint");
            float width = GetRequiredFloatAttrib(cmdElm, "width", macros);
            Pen pen = new Pen(_Brush, width);
            _Graphics.DrawLine(pen, pos1, pos2);
        }

        private void ColumnWidth(XmlElement cmdElm, MacroValues macros)
        {
            _ColumnWidth = GetRequiredFloatAttrib(cmdElm, "size", macros);
        }

        private void SpaceAfter(XmlElement cmdElm, MacroValues macros)
        {
            _SpaceAfter = GetRequiredFloatAttrib(cmdElm, "size", macros);
        }

        private void MoveDown(XmlElement cmdElm, MacroValues macros)
        {
            _TextPos.Y += GetRequiredFloatAttrib(cmdElm, "size", macros);
        }

        private void MoveRight(XmlElement cmdElm, MacroValues macros)
        {
            _TextPos.X += GetRequiredFloatAttrib(cmdElm, "size", macros);
        }

        public static string NormalizeText(string value)
        {
            value = value.Trim().Replace('\r', ' ').Replace('\n', ' ');
            value = value.Replace("\x201D", "\"");
            while (value.Contains("  "))
            {
                value = value.Replace(" ", "");
            }
            return value;
        }

        private static string TranslateMacroReferences(string input, MacroValues macros)
        {
            if (input == null)
                return null;
            string result = input;
            for (int startingOffset = 0; ; )
            {
                int openBraceOffset = result.IndexOf('{', startingOffset);
                if (openBraceOffset < 0)
                    break;
                int closeBraceOffset = result.IndexOf('}', openBraceOffset + 1);
                if (closeBraceOffset > 0)
                {
                    string macroName = result.Substring(openBraceOffset + 1, closeBraceOffset - openBraceOffset - 1);
                    string macroValue;
                    if (!macros.TryGetValue(macroName, out macroValue))
                        macroValue = "";
                    result = result.Substring(0, openBraceOffset) + macroValue + result.Substring(closeBraceOffset + 1);
                    startingOffset = openBraceOffset;
                }
                else
                {
                    startingOffset++;
                }
            }
            return result;
        }

        public static void LoadMacroDefinitions(string templateFile, string templateFolder, MacroDefinitions macroDefs)
        {
            string templatePath = Path.Combine(templateFolder, templateFile);
            XmlDocument templateDoc = new XmlDocument();
            templateDoc.Load(templatePath);
            foreach (XmlNode templateNode in templateDoc.DocumentElement.ChildNodes)
            {
                XmlElement cmdElm = templateNode as XmlElement;
                if (cmdElm != null)
                {
                    string cmdName = cmdElm.Name.ToLowerInvariant();
                    switch (cmdName)
                    {
                        case "macrodef":
                            string macroName;
                            if (!TryGetAttrib(cmdElm, "name", out macroName))
                                throw CreateTemplateAttributeException(cmdElm, "name", "Missing [name] attribute");
                            string macroValue;
                            if (!TryGetAttrib(cmdElm, "value", out macroValue))
                                throw CreateTemplateAttributeException(cmdElm, "value", "Missing [value] attribute");
                            macroDefs.Add(new MacroDefinition(macroName, macroValue));
                            break;
                        case "include":
                            string includePath = cmdElm.InnerText;
                            if (string.IsNullOrEmpty(includePath))
                                throw CreateTemplateException(cmdElm, "Missing include file name");
                            LoadMacroDefinitions(Path.GetFileName(includePath), templateFolder, macroDefs);
                            break;
                    }
                }
            }
        }

        private static bool TryGetAttrib(XmlElement cmdElm, string attrName, out string value)
        {
            string rawValue = cmdElm.GetAttribute(attrName);
            value = rawValue;
            return !string.IsNullOrEmpty(rawValue);
        }

        private static bool TryGetAttrib(XmlElement cmdElm, string attrName, MacroValues macros, out string value)
        {
            string rawValue = cmdElm.GetAttribute(attrName);
            if (string.IsNullOrEmpty(rawValue))
            {
                value = rawValue;
                return false;
            }
            value = TranslateMacroReferences(rawValue, macros);
            return true;
        }

        private static bool TryGetAttrib(XmlElement cmdElm, string attrName, MacroValues macros, out float floatValue)
        {
            string stringValue;
            if (!TryGetAttrib(cmdElm, attrName, macros, out stringValue))
            {
                floatValue = 0.0f;
                return false;
            }
            if (!float.TryParse(stringValue, out floatValue))
                throw CreateTemplateAttributeException(cmdElm, attrName, "Not a valid decimal number");
            return true;
        }

        private static float GetRequiredFloatAttrib(XmlElement cmdElm, string attrName, MacroValues macros)
        {
            float result;
            if (!TryGetAttrib(cmdElm, attrName, macros, out result))
                throw CreateTemplateAttributeException(cmdElm, attrName, "Missing attribute");
            return result;
        }

        private static string GetRequiredStringAttrib(XmlElement cmdElm, string attrName, MacroValues macros)
        {
            string result;
            if (!TryGetAttrib(cmdElm, attrName, macros, out result))
                throw CreateTemplateAttributeException(cmdElm, attrName, "Missing attribute");
            return TranslateMacroReferences(result, macros);
        }

        private static bool TryGetPosition(XmlElement cmdElm, MacroValues macros, out PointF position)
        {
            return TryGetPosition(cmdElm, "x", "y", macros, out position);
        }

        private static bool TryGetPosition(XmlElement cmdElm, string xAttr, string yAttr, MacroValues macros, out PointF position)
        {
            float x;
            float y;
            bool hasX;
            bool hasY;
            hasX = TryGetAttrib(cmdElm, xAttr, macros, out x);
            hasY = TryGetAttrib(cmdElm, yAttr, macros, out y);
            if ( hasX != hasY)
                throw CreateTemplateException(cmdElm, "\"" + xAttr +"\" and \"" + yAttr +
                    "\" attributes must either both must be specified or neither");
            if (hasX & hasY)
            {
                position = new PointF(x, y);
                return true;
            }
            else
            {
                position = new PointF();
                return false;
            }
        }

        public static void AddStandardMacroValues(MacroValues macros)
        {
            macros["inch"] = "\"";
            macros["cent"] = "\xA2";
            macros["squarebullet"] = "\x25A0";
            macros["largesquarebullet"] = "\x25A0";
            macros["smallsquarebullet"] = "\x25AA";
            macros["roundbullet"] = "\x25CF";
        }

        public static XmlDocument CreateEmptySignDataDoc()
        {
            XmlDocument dataDoc = new XmlDocument();
            dataDoc.PreserveWhitespace = false;
            return dataDoc;
        }

        public static void AddDataFileMacros(MacroValues macros, string dataFolder, XmlDocument dataDoc)
        {
            foreach (XmlNode incNode in dataDoc.DocumentElement.SelectNodes("include"))
            {
                XmlElement incElm = (XmlElement)incNode;
                string includeFileName = incElm.InnerText;
                XmlDocument includeDoc = SingleSign.CreateEmptySignDataDoc();
                includeDoc.Load(Path.Combine(dataFolder, includeFileName));
                AddDataFileMacros(macros, dataFolder, includeDoc);
            }
            foreach (XmlNode dataNode in dataDoc.DocumentElement.SelectNodes("data"))
            {
                XmlElement dataElm = (XmlElement)dataNode;
                string id = dataElm.GetAttribute("id");
                if (id == null)
                    throw new MissingFieldException("Missing [id] in data file");
                macros[id] = dataElm.InnerText;
            }
        }



        private static Exception CreateTemplateAttributeException(XmlElement cmdElm, string attrName, string message)
        {
            return new ArgumentException("Error in \"" + attrName + "\" attribute in <" + cmdElm.Name + 
                "> element in sign template: " + message);
        }

        private static Exception CreateTemplateException(XmlElement cmdElm, string message)
        {
            return new ArgumentException("Error in <" + cmdElm.Name +
                "> element in sign template: " + message);
        }

        public static void ShowException(Exception ex)
        {
            MessageBox.Show(ex.Message);
            if (ex.InnerException != null)
            {
                if (ex.InnerException is System.IO.FileNotFoundException)
                    MessageBox.Show("File not found: " + ex.InnerException.Message);
                else
                    MessageBox.Show(ex.InnerException.Message);
            }
        }
    }
}
