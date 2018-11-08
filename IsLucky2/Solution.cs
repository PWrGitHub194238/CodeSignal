using System.Linq;

namespace IsLucky2
{
    public class Solution
    {
        public static bool IsLucky2(int n)
        {
            string intString = n.ToString();
            int halfLength = intString.Length / 2;
            int firstHalfSum = intString.Substring(0, halfLength).Sum(c => c);
            int secondHalfSum = intString.Substring(halfLength).Sum(c => c);
            return firstHalfSum.CompareTo(secondHalfSum) == 0;
        }
    }
}
