
using System.Collections;
using System.Collections.Generic;

namespace DecodeString
{
    public class Solution
    {
        public static string decodeString(string s)
        {
            string decodedString = string.Empty;

            Stack<char> parsingStack = new Stack<char>();
            Stack<int> multiplierStack = new Stack<int>();
            Stack<int> localMultiplierStack = new Stack<int>();
            int multiplier = 1;
            string lms = "";

            char currentChar;
            char[] inputCharArray = s.ToCharArray();
            int inputCharIdx = 0;
            int inputCharMaxIdx = inputCharArray.Length;
            string localString;

            while(inputCharIdx < inputCharMaxIdx)
            {
                currentChar = inputCharArray[inputCharIdx];

                if (char.IsLetter(currentChar))
                {
                    parsingStack.Push(currentChar);
                } else if (char.IsDigit(currentChar))
                {
                    localMultiplierStack.Push(currentChar - 48);
                } else if (currentChar == '[')
                {
                    parsingStack.Push(currentChar);

                    while (localMultiplierStack.Count > 0)
                    {
                        lms = localMultiplierStack.Pop() + lms;
                    }
                    multiplierStack.Push(int.Parse(lms));
                    lms = "";

                } else if (currentChar == ']')
                {
                    localString = string.Empty;
                    while (parsingStack.Peek() != '[')
                    {
                        localString = parsingStack.Pop() + localString;
                    }
                    parsingStack.Pop();

                    multiplier = multiplierStack.Pop();
                    for (int i = 0; i < multiplier; i++)
                    {
                        foreach (var inputChar in localString.ToCharArray())
                        {
                            parsingStack.Push(inputChar);
                        }
                    }
                }

                inputCharIdx += 1;
            }

            while (parsingStack.Count > 0) {
                decodedString = parsingStack.Pop() + decodedString;
            }
            return decodedString;
        }
    }
}
