using System;
using System.Collections.Generic;
using System.Linq;

namespace WordBoggle
{
    public class Solution
    {
        public static string[] wordBoggle(char[][] board, string[] words)
        {
            if (board.Length == 0) return new string[] { };
            if (words.Length == 0) return words;
            if (words.Length > 1)
            {
                Array.Sort(words);
                IList<string> tmp = new List<string>();

                for (int i = 1; i < words.Length; i++)
                {
                    if (!words[i - 1].Equals(words[i]))
                    {
                        tmp.Add(words[i - 1]);
                    }
                }

                if (!words[words.Length - 2].Equals(words.Length - 1))
                {
                    tmp.Add(words[words.Length - 1]);
                }

                words = tmp.ToArray();
            }

            IList<string> assemblyableWordList = new List<string>();
            int boardHeight = board.Length;
            int boardWidth = board[0].Length;

            IList<(int x, int y)>[] charToPositionMappingArray = new IList<(int x, int y)>['Z' - 'A' + 1];
            bool[][] gotThere = new bool[boardHeight][];

            for (int i = 0; i < charToPositionMappingArray.Length; i++)
            {
                charToPositionMappingArray[i] = new List<(int x, int y)>();
            }
            for (int x = 0; x < board.Length; x++)
            {
                gotThere[x] = new bool[boardWidth];
                for (int y = 0; y < board[x].Length; y++)
                {
                    charToPositionMappingArray[board[x][y] - 65].Add((x, y));
                }
            }

            foreach (var word in words)
            {
                char[] wordChars = word.ToCharArray();
                Stack<(int x, int y, char c, int inWordIdx)> reachableCharStack = new Stack<(int x, int y, char c, int inWordIdx)>();
                Stack<(int x, int y, char c, int inWordIdx)> path = new Stack<(int x, int y, char c, int inWordIdx)>();
                (int x, int y, char c, int inWordIdx) currentCharInfo, backTrackInfo;

                // dla każdej możliwej ścieżki dla słowa
                foreach (var (x, y) in charToPositionMappingArray[wordChars[0] - 65])
                {
                    reachableCharStack.Push((x, y, wordChars[0], 0));
                }

                if (reachableCharStack.Count > 0)
                {
                    if (word.Length == 1)
                    {
                        assemblyableWordList.Add(word);
                    }
                    else
                    {
                        int nextCharIdx = 1;
                        char nextChar = wordChars[nextCharIdx];
                        bool nextCharFound;

                        do
                        {
                            currentCharInfo = reachableCharStack.Pop();
                            
                            if (path.Count > 0)
                            {
                                while (path.Count > 0 && path.Peek().inWordIdx >= currentCharInfo.inWordIdx)
                                {
                                    backTrackInfo = path.Pop();
                                    gotThere[backTrackInfo.x][backTrackInfo.y] = false;
                                } 
                            }

                            if (currentCharInfo.inWordIdx == word.Length - 1)
                            {
                                assemblyableWordList.Add(word);
                            }
                            else
                            {
                                path.Push(currentCharInfo);
                                gotThere[currentCharInfo.x][currentCharInfo.y] = true;
                                nextCharIdx = currentCharInfo.inWordIdx + 1;
                                nextChar = wordChars[nextCharIdx];

                                nextCharFound = false;
                                // Add every possible move to the next letter
                                for (int x = Math.Max(0, currentCharInfo.x - 1); x < Math.Min(currentCharInfo.x + 1 + 1, boardHeight); x++)
                                {
                                    for (int y = Math.Max(0, currentCharInfo.y - 1); y < Math.Min(currentCharInfo.y + 1 + 1, boardWidth); y++)
                                    {
                                        if (gotThere[x][y] == false && board[x][y] == nextChar)
                                        {
                                            nextCharFound = true;
                                            reachableCharStack.Push((x, y, nextChar, nextCharIdx));
                                        }
                                    }
                                }

                                if (!nextCharFound)
                                {
                                    gotThere[currentCharInfo.x][currentCharInfo.y] = false;
                                    nextChar = wordChars[nextCharIdx - 1];
                                    path.Pop();
                                }
                            }
                        } while (reachableCharStack.Count > 0 && currentCharInfo.inWordIdx < word.Length - 1);

                        while (path.Count > 0)
                        {
                            currentCharInfo = path.Pop();
                            gotThere[currentCharInfo.x][currentCharInfo.y] = false;
                        }

                        while (reachableCharStack.Count > 0)
                        {
                            currentCharInfo = reachableCharStack.Pop();
                            gotThere[currentCharInfo.x][currentCharInfo.y] = false;
                        }
                    }
                }
            }

            return assemblyableWordList.ToArray();
        }
    }
}
