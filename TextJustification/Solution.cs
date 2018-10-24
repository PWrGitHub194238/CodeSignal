
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextJustification
{
    public class Solution
    {
        public static string[] textJustification(string[] words, int l)
        {
            IList<string> justiftyStringList = new List<string>();

            int wordIdx = 0;
            int wordsArrayLength = words.Length;
            IList<string> newLine = new List<string>();
            string nextWord;
            int nextWordLength;
            int lineLength = 0;
            StringBuilder justifiedline;

            while (wordIdx < wordsArrayLength)
            {
                nextWord = words[wordIdx];
                nextWordLength = nextWord.Length;
                if (lineLength + nextWordLength <= l)
                {
                    newLine.Add($"{nextWord} ");
                    lineLength += nextWordLength + 1;
                    wordIdx += 1;
                }
                else
                {
                    // we
                    if (newLine.Count > 1)
                    {
                        // last word cannot have spacing
                        var spaceCountingArray = new int[newLine.Count];
                        int i;
                        // add spaceing
                        do
                        {
                            for (i = 0; i < spaceCountingArray.Length - 1; i++)
                            {
                                if (lineLength - 1 == l)
                                {
                                    break;
                                }
                                spaceCountingArray[i] += 1;
                                lineLength += 1;
                            }
                        } while (lineLength - 1 < l); // keep adding spaces until we fill all space

                        // inject spaceing
                        i = 0;
                        justifiedline = new StringBuilder();
                        foreach (var word in newLine)
                        {
                            justifiedline.Append(word);
                            justifiedline.Append(new string(' ', spaceCountingArray[i]));
                            i += 1;
                        }

                        // add line with trimmed end (one space extra)
                        justiftyStringList.Add(justifiedline.ToString().TrimEnd());
                    }
                    else
                    {
                        var item = newLine.First().ToString().TrimEnd();
                        justiftyStringList.Add(item + new string(' ', l - item.Length));
                    }
                    newLine = new List<string>();
                    lineLength = 0;
                }
            }



            justifiedline = new StringBuilder();
            foreach (var word in newLine)
            {
                justifiedline.Append(word);
            }

            var s = justifiedline.ToString().TrimEnd();

            // add line with trimmed end (one space extra)
            justiftyStringList.Add(s.ToString() + new string(' ', l - s.Length));


            return justiftyStringList.ToArray();
        }
    }
}
