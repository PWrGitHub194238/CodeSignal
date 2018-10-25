
using System.Collections.Generic;
using System.Linq;

namespace TreeBottom
{
    public class Solution
    {
        public static int[] treeBottom(string tree)
        {
            int treeLevel = 0;
            int maxTreeLevel = 0;
            int nodeIdx = 0;

            tree = tree.Replace(" ", "");
            tree = tree.Replace("()", "");
            char[] array = tree.ToCharArray();
            IList<(int nodeIdx, int nodeLevel)> nodeList = new List<(int nodeIdx, int nodeLevel)>();

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == '(')
                {
                    if (char.IsDigit(array[i - 1]))
                    {
                        nodeList.Add((nodeIdx, treeLevel));
                        nodeIdx = 0;
                    }
                    treeLevel += 1;
                    if (treeLevel > maxTreeLevel)
                    {
                        maxTreeLevel = treeLevel;
                    }
                }
                else if (char.IsDigit(array[i]))
                {
                    nodeIdx = 10 * nodeIdx + (array[i] - 48);
                }
                else if (array[i] == ')')
                {
                    if (char.IsDigit(array[i - 1]))
                    {
                        nodeList.Add((nodeIdx, treeLevel));
                        nodeIdx = 0;
                    }
                    treeLevel -= 1;
                }
            }
            return nodeList.Where(node => node.nodeLevel == maxTreeLevel).Select(node => node.nodeIdx).ToArray();
        }
    }
}
