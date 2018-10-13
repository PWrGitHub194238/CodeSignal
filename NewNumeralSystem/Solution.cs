namespace NewNumeralSystem
{
    public class Solution
    {
        public static string[] NewNumeralSystem(char number)
        {
            int firstLetter = 65;
            int numberOfEquastions = (number - firstLetter) / 2;
            string[] array = new string[numberOfEquastions + 1];
            int lastLetter = firstLetter + number;
            int lastIdx = firstLetter + numberOfEquastions;
            for (int i = firstLetter; i <= lastIdx; i += 1)
            {
                array[i - firstLetter] = $"{(char)i} + {(char)(lastLetter - i)}";
            }
            return array;
        }
    }
}
