using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextJustification
{
    public class Solution
    {
        public static string[] TextJustification(string[] words, int l)
        {
            IList<string> justiftyStringList = new List<string>();

            int wordIdx = 0;
            int wordsArrayLength = words.Length;

            (IList<string> newLine, int lineLength) = ResetLineTrackingObjects();

            while (wordIdx < wordsArrayLength)
            {
                if (IsLineLengthNotExtendsJustificationLengthWithAnotherWord(justificationLength: l, currentLineLength: lineLength, rawWordsArray: words, wordToAddIdx: wordIdx))
                {
                    (newLine, lineLength, wordIdx) = AddWordToLine(currentLine: newLine, currentLineLength: lineLength, rawWordsArray: words, wordToAddIdx: wordIdx);
                }
                else
                {
                    // we
                    if (newLine.Count > 1)
                    {
                        // inject spaceing
                        justiftyStringList.Add(GetJustyfiedTextLineWithTrimEnd(
                            wordsInLineList: newLine, spaceingArray: GetJustificationSpaceingArray(
                                wordsInLineCount: newLine.Count, currentLineLength: lineLength - 1, justyficationLength: l)));
                    }
                    else
                    {
                        justiftyStringList.Add(GetJustyfiedTextEndingLine(wordsInLineList: newLine, justyficationLength: l));
                    }

                    (newLine, lineLength) = ResetLineTrackingObjects();
                }
            }

            justiftyStringList.Add(GetJustyfiedTextEndingLine(wordsInLineList: newLine, justyficationLength: l));

            return justiftyStringList.ToArray();
        }

        private static bool IsLineLengthNotExtendsJustificationLengthWithAnotherWord(int justificationLength, int currentLineLength, string[] rawWordsArray, int wordToAddIdx)
        {
            return currentLineLength + rawWordsArray[wordToAddIdx].Length <= justificationLength;
        }

        private static (IList<string> newLine, int lineLength, int wordIdx) AddWordToLine(IList<string> currentLine, int currentLineLength, string[] rawWordsArray, int wordToAddIdx)
        {
            string wordToAdd = rawWordsArray[wordToAddIdx];
            currentLine.Add($"{wordToAdd} ");
            return (currentLine, currentLineLength + wordToAdd.Length + 1, wordToAddIdx + 1);
        }

        private static (IList<string> newLine, int lineLength) ResetLineTrackingObjects()
        {
            return (new List<string>(), 0);
        }

        /// <summary>
        /// For each word but the last one calculate how many spaces are needed 
        /// in order to make words + spaces length equal justyficationLength.
        /// </summary>
        /// <param name="wordsInLineCount">How many words we have in line,</param>
        /// <param name="currentLineLength">current length of a line (each word's length consists of 
        /// actual word's length + ordinary space after each word except for last one),</param>
        /// <param name="justyficationLength">length of fully justified text,</param>
        /// <returns>array with information how many spaces should we inject after each word to make line justified.</returns>
        private static int[] GetJustificationSpaceingArray(int wordsInLineCount, int currentLineLength, int justyficationLength)
        {
            int wordInLineToSpaceJustifyCount = wordsInLineCount - 1;
            int[] spaceingArray = new int[wordInLineToSpaceJustifyCount + 1];

            do
            {
                for (int wordIdx = 0; wordIdx < wordInLineToSpaceJustifyCount; wordIdx += 1)
                {
                    if (currentLineLength == justyficationLength)
                    {
                        break;
                    }
                    spaceingArray[wordIdx] += 1;
                    currentLineLength += 1;
                }
            } while (currentLineLength < justyficationLength);
            return spaceingArray;
        }

        private static string GetJustyfiedTextLineWithTrimEnd(IList<string> wordsInLineList, int[] spaceingArray)
        {
            int wordIdx = 0;
            StringBuilder justifiedLineBuilder = new StringBuilder();
            foreach (var word in wordsInLineList)
            {
                justifiedLineBuilder.Append(word);
                justifiedLineBuilder.Append(new string(' ', spaceingArray[wordIdx]));
                wordIdx += 1;
            }

            return justifiedLineBuilder.ToString().TrimEnd();
        }

        private static string GetJustyfiedTextEndingLine(IList<string> wordsInLineList, int justyficationLength)
        {
            StringBuilder justifiedLineBuilder = new StringBuilder();
            string justifiedLine = GetTextLineWithTrimEnd(wordsInLineList: wordsInLineList);


            justifiedLineBuilder.Append(justifiedLine);
            justifiedLineBuilder.Append(new string(' ', justyficationLength - justifiedLine.Length));
            return justifiedLineBuilder.ToString();
        }

        private static string GetTextLineWithTrimEnd(IList<string> wordsInLineList)
        {
            StringBuilder justifiedLineBuilder = new StringBuilder();
            foreach (var word in wordsInLineList)
            {
                justifiedLineBuilder.Append(word);
            }

            return justifiedLineBuilder.ToString().TrimEnd();
        }
    }
}
