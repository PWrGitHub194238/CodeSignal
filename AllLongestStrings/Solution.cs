
using System.Collections.Generic;
using System.Linq;

namespace AllLongestStrings
{
    public class Solution
    {
        public static string[] AllLongestStrings(string[] inputArray)
        {
            int stringMaxLength = -1;
            IList<string> longestWordsList = new List<string>();

            foreach (var str in inputArray)
            {
                if (str.Length > stringMaxLength)
                {
                    stringMaxLength = str.Length;
                }
            }

            foreach (var str in inputArray)
            {
                if (str.Length == stringMaxLength)
                {
                    longestWordsList.Add(str);
                }
            }
            return longestWordsList.ToArray();
        }
    }
}
