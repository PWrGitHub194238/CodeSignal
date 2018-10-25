
using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeBottom
{
    public class Solution
    {
        public const char CHILD_NODE_START_MARKUP = '(';
        public const char CHILD_NODE_END_MARKUP = ')';

        public static int[] TreeBottom(string tree)
        {
            int treeLevel = 0;
            int maxTreeLevel = 0;
            int nodeIdx = 0;

            char[] treeStringArray = PrepareTreeString(treeString: tree);
            int treeStringArrayLength = treeStringArray.Length;
            char currentChar;

            // Track level of each parsed node.
            IList<(int nodeIdx, int nodeLevel)> nodeList = new List<(int nodeIdx, int nodeLevel)>();

            // First sign in a tree string is a '(' and the last one: ')'.
            // We don't need the first one.
            for (int i = 1; i < treeStringArrayLength; i++)
            {
                currentChar = treeStringArray[i];
                if (currentChar.Equals(CHILD_NODE_START_MARKUP))
                {
                    (nodeList, nodeIdx) = AddParentNodeToList(nodeList: nodeList, treeString: treeStringArray, currentCharIdx: i,
                        parentNodeIdx: nodeIdx, parentNodeLevel: treeLevel);

                    treeLevel += 1;
                    maxTreeLevel = Math.Max(maxTreeLevel, treeLevel);
                }
                else if (char.IsDigit(currentChar))
                {
                    nodeIdx = AddNextDigit(paratialNodeIdx: nodeIdx, digit: currentChar);
                }
                else if (currentChar.Equals(CHILD_NODE_END_MARKUP))
                {
                    (nodeList, nodeIdx) = AddParentNodeToList(nodeList: nodeList, treeString: treeStringArray, currentCharIdx: i,
                        parentNodeIdx: nodeIdx, parentNodeLevel: treeLevel);
                    treeLevel -= 1;
                }
            }
            return nodeList.Where(node => node.nodeLevel == maxTreeLevel).Select(node => node.nodeIdx).ToArray();
        }

        private static int AddNextDigit(int paratialNodeIdx, char digit)
        {
            return 10 * paratialNodeIdx + (digit - 48);
        }

        private static (IList<(int nodeIdx, int nodeLevel)> nodeList, int nodeIdx) AddParentNodeToList(IList<(int nodeIdx, int nodeLevel)> nodeList, char[] treeString, int currentCharIdx, int parentNodeIdx, int parentNodeLevel)
        {
            if (char.IsDigit(treeString[currentCharIdx - 1]))
            {
                nodeList.Add((parentNodeIdx, parentNodeLevel));
                return (nodeList, 0);
            }
            return (nodeList, parentNodeIdx);
        }

        /// <summary>
        /// Renoves unnecessary markup from the string.
        /// </summary>
        /// <param name="treeString">String in a given tree recursive notation,</param>
        /// <returns>simplified tree notation to be parsed.</returns>
        private static char[] PrepareTreeString(string treeString)
        {
            return treeString
                .Replace(" ", "")   // we don't need any extra characters but '(', ')' and digits
                .Replace("()", "")  // wo do not need null child for node markup ('(n()())' => '(n)' means that 'n' node is a lief in a tree)
                .ToCharArray();
        }
    }
}
