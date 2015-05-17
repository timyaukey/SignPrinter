using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PlantLibrary
{
    /// <summary>
    /// Parse information from an image file name.
    /// </summary>
    public static class ImageNameParser
    {
        /// <summary>
        /// Extract information needed to create a blank plant file from an image file name.
        /// </summary>
        /// <param name="plantFolder">Full path to the folder the image file lives in.</param>
        /// <param name="imageFile">Name (without path) of the image file.</param>
        /// <param name="removeExtraWord">If true then look for each word in the image file name in
        /// the list of extra fact file names, and if it finds one remove it from "nameWords".
        /// Removes the first matching extra fact file name.</param>
        /// <param name="cboExtraFactFile">A ComboBox with all the extra fact file names, plus an additional blank entry.</param>
        /// <param name="outputNameWithoutType">The input file name with file type and grower postfix removed, like "RocketRed".</param>
        /// <param name="nameWords">A List<string> of all the capitalized names in the image file name.</string></param>
        /// <param name="encodedImageName">The input file name with any trailing grower code converted to {grower}.</param>
        /// <param name="lastGrower">If a grower code is found at the end of the image file name, return it here.</param>
        public static void ExtractPlantFileAttributes(
            string plantFolder, string imageFile, bool removeExtraWord, ComboBox cboExtraFactFile,
            out string outputNameWithoutType, out List<string> nameWords,
            out string encodedImageName, ref string lastGrower)
        {
            string fileTypeWithPeriod = Path.GetExtension(imageFile);

            if (ParseFileName(imageFile, out outputNameWithoutType, ref lastGrower))
            {
                encodedImageName = outputNameWithoutType + "{grower}" + fileTypeWithPeriod;
            }
            else
            {
                encodedImageName = outputNameWithoutType + fileTypeWithPeriod;
            }
            string plantFolderName = GetPlantFolderName(plantFolder);
            nameWords = GetCapitalizedWords(outputNameWithoutType);
            if (nameWords.Contains(plantFolderName))
            {
                nameWords.Remove(plantFolderName);
            }
            string matchingExtraFactWord = ChooseMatchingExtraFact(nameWords, cboExtraFactFile);
            if (matchingExtraFactWord != null && removeExtraWord)
            {
                nameWords.Remove(matchingExtraFactWord);
            }
        }

        /// <summary>
        /// Extract and return the name portion of the image file name, by removing the file type
        /// and grower code.
        /// </summary>
        /// <param name="inputName">Input image file name.</param>
        /// <param name="outputNameWithoutType">The resulting name.</param>
        /// <param name="lastGrower">If a grower code is found, it is returned here.</param>
        /// <returns></returns>
        public static bool ParseFileName(string inputName, out string outputNameWithoutType, ref string lastGrower)
        {
            string inputNameWithoutType = Path.GetFileNameWithoutExtension(inputName);
            if (CheckFileNameEnding(inputNameWithoutType, "PE", out outputNameWithoutType, ref lastGrower))
                return true;
            if (CheckFileNameEnding(inputNameWithoutType, "EG", out outputNameWithoutType, ref lastGrower))
                return true;
            if (CheckFileNameEnding(inputNameWithoutType, "FB", out outputNameWithoutType, ref lastGrower))
                return true;
            outputNameWithoutType = inputNameWithoutType;
            return false;
        }

        private static bool CheckFileNameEnding(string inputNameWithoutType, string ending,
            out string outputNameWithoutType, ref string lastGrower)
        {
            if (inputNameWithoutType.EndsWith(ending))
            {
                outputNameWithoutType = inputNameWithoutType.Substring(0, inputNameWithoutType.Length - ending.Length);
                lastGrower = ending;
                return true;
            }
            else
            {
                outputNameWithoutType = inputNameWithoutType;
                return false;
            }
        }

        /// <summary>
        /// Return the final name in the plant folder path.
        /// </summary>
        /// <param name="plantFolder"></param>
        /// <returns></returns>
        public static string GetPlantFolderName(string plantFolder)
        {
            int lastSlashOffset = plantFolder.LastIndexOf('\\');
            if (lastSlashOffset > 0)
                return plantFolder.Substring(lastSlashOffset + 1);
            else
                return string.Empty;
        }

        /// <summary>
        /// Return a List<string> of the capitalized words in the input,
        /// which is typically a file name.
        /// For example, "RocketRed" returns "Rocket" and "Red".
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The word list.</returns>
        public static List<string> GetCapitalizedWords(string input)
        {
            List<string> words = new List<string>();
            int startOffset = 0;
            for (int endOffset = startOffset; ; )
            {
                endOffset++;
                if (endOffset >= input.Length)
                {
                    words.Add(input.Substring(startOffset));
                    break;
                }
                if (char.IsUpper(input[endOffset]))
                {
                    if (!char.IsUpper(input[endOffset - 1]))
                    {
                        words.Add(input.Substring(startOffset, endOffset - startOffset));
                        startOffset = endOffset;
                    }
                }
            }
            return words;
        }

        /// <summary>
        /// Look for each element in "nameWords" in the items in a ComboBox.
        /// The first match is returned through the function result, and that
        /// choice selected in the ComboBox. If nothing is matched then the
        /// ComboBox is set so nothing is selected.
        /// </summary>
        /// <param name="nameWords">The list of strings to search for, which are
        /// usually words returned by GetCapitalizedWords().</param>
        /// <param name="extraFactFile">The ComboBox to search.</param>
        /// <returns>The matched string, or null.</returns>
        public static string ChooseMatchingExtraFact(List<string> nameWords, ComboBox extraFactFile)
        {
            extraFactFile.SelectedIndex = -1;
            extraFactFile.Text = string.Empty;
            foreach (string nameWord in nameWords)
            {
                int factIndex = 0;
                foreach (string factFile in extraFactFile.Items)
                {
                    if (nameWord + ".sgninc" == factFile)
                    {
                        extraFactFile.SelectedIndex = factIndex;
                        return nameWord;
                    }
                    factIndex++;
                }
            }
            return null;
        }
    }
}
