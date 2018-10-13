using System.Collections.Generic;
using System.Linq;

namespace NewNumeralSystem
{
    public class Solution
    {
        public static string[] NewNumeralSystem(char number)
        {
            IList<string> list = new List<string>();

            int maxIdx = (number - 65) / 2 + 1;
            for (int i = 0; i < maxIdx; i += 1)
            {
                list.Add($"{(char)(65 + i)} + {(char)(number - i)}");
            }

            return list.ToArray();
        }
    }
}
