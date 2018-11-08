
using System.Linq;

namespace IsLucky2
{
    public class Solution
    {
        public static bool isLucky2(int n)
        {
            string s = n.ToString();
            return s.Where((c, idx) => idx < s.Length / 2).Sum(c => c - '0').CompareTo(
                s.Where((c, idx) => idx >= (s.Length + 1) / 2).Sum(c => c - '0')) == 0;
        }
    }
}
