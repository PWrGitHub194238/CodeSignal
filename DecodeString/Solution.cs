using System;
using System.Collections.Generic;
using System.Text;

namespace DecodeString
{
    public class Solution
    {
        public static string decodeString(string s)
        {
            string decodedString = string.Empty;

            Stack<char> parsingStack = new Stack<char>();
            Stack<int> multiplierStack = new Stack<int>();
            StringBuilder localMultiplierBuilder = new StringBuilder();
            int multiplier = 1;

            char currentChar;
            char[] inputCharArray = s.ToCharArray();
            int inputCharIdx = 0;
            int inputCharMaxIdx = inputCharArray.Length;
            LinkedList<char> localString;

            while (inputCharIdx < inputCharMaxIdx)
            {
                currentChar = inputCharArray[inputCharIdx];

                if (char.IsLetter(currentChar))
                {
                    parsingStack.Push(currentChar);
                }
                else if (char.IsDigit(currentChar))
                {
                    localMultiplierBuilder.Append(currentChar - 48);
                }
                else if (currentChar == '[')
                {
                    parsingStack.Push(currentChar);
                    multiplierStack.Push(int.Parse(localMultiplierBuilder.ToString()));
                    localMultiplierBuilder.Clear();
                }
                else if (currentChar == ']')
                {
                    localString = new LinkedList<char>();
                    currentChar = parsingStack.Pop();
                    while (currentChar != '[')
                    {
                        localString.AddFirst(currentChar);
                        currentChar = parsingStack.Pop();
                    }

                    multiplier = multiplierStack.Pop();
                    for (int i = 0; i < multiplier; i++)
                    {
                        foreach (var inputChar in localString)
                        {
                            parsingStack.Push(inputChar);
                        }
                    }
                }

                inputCharIdx += 1;
            }
            char[] reversedDecodedArray = parsingStack.ToArray();
            Array.Reverse(reversedDecodedArray);
            return new string(reversedDecodedArray);
        }
    }
}