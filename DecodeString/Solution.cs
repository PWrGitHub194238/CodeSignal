using System;
using System.Collections.Generic;
using System.Text;

namespace DecodeString
{
    public class Solution
    {
        private static readonly char BEGIN_SECTION = '[';
        private static readonly char END_SECTION = ']';

        public static string DecodeString(string s)
        {
            Stack<char> parsingStack = new Stack<char>();
            Stack<int> multiplierStack = new Stack<int>();
            StringBuilder localMultiplierBuilder = new StringBuilder();

            char[] inputCharArray = s.ToCharArray();
            int inputCharIdx = 0;
            int inputCharMaxIdx = inputCharArray.Length;

            while (inputCharIdx < inputCharMaxIdx)
            {
                parsingStack = EvaluateChar(parsingStack, inputCharArray[inputCharIdx],
                    localMultiplierBuilder, multiplierStack);
                inputCharIdx += 1;
            }

            return StackToString(parsingStack);
        }

        private static Stack<char> EvaluateChar(Stack<char> parsingStack, char currentChar, 
            StringBuilder localMultiplierBuilder, Stack<int> multiplierStack)
        {
            if (char.IsLetter(currentChar)) // If letter, just move to the next letter.
            {
                parsingStack.Push(currentChar);
            }
            else if (char.IsDigit(currentChar)) // Store digits for future number to be build from them
            {
                localMultiplierBuilder.Append(CharToDigit(currentChar));
            }
            else if (IsBeginSection(currentChar))   // Create a multiplier for the following bracketed section from gathered digits.
            {
                parsingStack.Push(currentChar);
                multiplierStack = AddMultiplierToStackFromBuilderAndReset(multiplierStack, localMultiplierBuilder);
            }
            else if (IsEndSection(currentChar)) // Get all characters from the last section which this encontered bracked ends and multiply it by the recent multiplier.
            {
                parsingStack = EvaluateBracket(parsingStack, multiplierStack.Pop(),
                    GetLastestBracketContent(parsingStack).GetEnumerator());
            }
            return parsingStack;
        }

        private static int CharToDigit(char currentChar)
        {
            return currentChar - 48;
        }

        private static bool IsBeginSection(char currentChar)
        {
            return currentChar.Equals(BEGIN_SECTION);
        }

        private static bool IsEndSection(char currentChar)
        {
            return currentChar.Equals(END_SECTION);
        }

        private static Stack<int> AddMultiplierToStackFromBuilderAndReset(Stack<int> multiplierStack, StringBuilder localMultiplierBuilder)
        {
            multiplierStack.Push(int.Parse(localMultiplierBuilder.ToString()));
            localMultiplierBuilder.Clear();
            return multiplierStack;
        }

        private static string StackToString(Stack<char> parsingStack)
        {
            char[] reversedDecodedArray = parsingStack.ToArray();
            Array.Reverse(reversedDecodedArray);
            return new string(reversedDecodedArray);
        }

        private static LinkedList<char> GetLastestBracketContent(Stack<char> parsingStack)
        {
            LinkedList<char> inBracketString = new LinkedList<char>();
            char currentChar = parsingStack.Pop();
            while (currentChar != BEGIN_SECTION)
            {
                inBracketString.AddFirst(currentChar);
                currentChar = parsingStack.Pop();
            }
            return inBracketString;
        }

        private static Stack<char> EvaluateBracket(Stack<char> parsingStack, int multiplier, IEnumerator<char> enumerator)
        {
            for (int i = 0; i < multiplier; i++)
            {
                enumerator.Reset();
                while (enumerator.MoveNext())
                {
                    parsingStack.Push(enumerator.Current);
                }
            }
            return parsingStack;
        }
    }
}