using System;

namespace CommonCharacterCount
{
    public class Solution
    {
        public static int CommonCharacterCount(string s1, string s2)
        {
            int commonCharacters = 0;
            int charArrayLength = 'z' + 1;
            int[] s1CharCountArray = new int[charArrayLength];
            int[] s2CharCountArray = new int[charArrayLength];

            char[] s1CharArray = s1.ToCharArray();
            char[] s2CharArray = s2.ToCharArray();

            foreach (var c in s1CharArray)
            {
                s1CharCountArray[c] += 1;
            }

            foreach (var c in s2CharArray)
            {
                s2CharCountArray[c] += 1;
            }

            for (int c = 'a'; c < charArrayLength; c += 1)
            {
                commonCharacters += Math.Min(s1CharCountArray[c], s2CharCountArray[c]);
            }

            return commonCharacters;
        }
    }
}
