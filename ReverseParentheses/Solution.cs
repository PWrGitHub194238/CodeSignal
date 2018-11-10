
using System.Collections.Generic;
using System.Text;

namespace ReverseParentheses
{
    public class Solution
    {
        private const char STARTING_BRACKET = '(';
        private const char ENDING_BRACKET = ')';

        public static string ReverseParentheses(string s)
        {
            // Queue contains chunks of string s (either substrings that have no brackets at all 
            // or substrings that are need to be further processed.
            Queue<string> substringQueue = new Queue<string>();

            // Entire string between any pair of brackets needs to be reversed.
            // We will do that by storing it's content char-by-char and build a string
            // by simply pulling out chars until stack is empty.
            Stack<char> reversedSubstring = null;

            StringBuilder reverseStringBuilder;
            StringBuilder nonBracketStringBuilder;

            // If there is a string with any pair of brackets, we need to resolve those pairs one by one
            // starting from the most outer one and start all other again.
            bool needNextScan = s.Contains(STARTING_BRACKET);

            // Keeps track whenever we capture entire string inside the most outer pair of brackets.
            int bracketLevel = 0;

            // We starts with input string s in the queue.
            // We want to keep tracking the position of the string s beginning.
            int itemsToPull = 1;

            // Feed our queue with a string to be processed.
            substringQueue.Enqueue(s);

            // Keep pooling out from the queue until:
            // - there is no element that needs to be processed (those which contains brackets),
            // - the first element in the queue is the beginning of the input s string.
            do
            {
                // Get next chunk of the s string to be processed
                char[] sSubstringCharArray = substringQueue.Dequeue().ToCharArray();
                int sSubstringCharArrayLength = sSubstringCharArray.Length;
                nonBracketStringBuilder = new StringBuilder();
                itemsToPull -= 1;

                for (int i = 0; i < sSubstringCharArrayLength; i += 1)
                {
                    char c = sSubstringCharArray[i];
                    switch (c)
                    {
                        case STARTING_BRACKET:
                            if (bracketLevel == 0)
                            {
                                // We are outside of brackets, if there was a regular string 
                                // before that point, add it to the queue since it don't need further processing.
                                if (nonBracketStringBuilder.Length > 0)
                                {
                                    substringQueue.Enqueue(nonBracketStringBuilder.ToString());
                                    nonBracketStringBuilder = new StringBuilder();
                                }
                                reversedSubstring = new Stack<char>();
                            }
                            else
                            {
                                // Otherwise we are between brackets, so every char will be reversed
                                // including brackets ('(' -> ')').
                                reversedSubstring.Push(ENDING_BRACKET);
                            }
                            bracketLevel += 1;
                            break;
                        case ENDING_BRACKET:
                            bracketLevel -= 1;
                            if (bracketLevel == 0)
                            {
                                // We left a content of the most uoter bracket piar and now we have to reverse collected chars.
                                reverseStringBuilder = new StringBuilder();
                                IEnumerator<char> enumerator = reversedSubstring.GetEnumerator();
                                // Build a reversed string by poping from stack.
                                while (enumerator.MoveNext())
                                {
                                    reverseStringBuilder.Append(enumerator.Current);
                                }
                                // and add result into queue.
                                string reversedString = reverseStringBuilder.ToString();
                                substringQueue.Enqueue(reversedString);

                                // Meanwhile we have deleted the most outer pair of brackets.
                                // If resulted string has some inner pair of brackets,
                                // we will need to process it again.
                                if (reversedString.Contains(STARTING_BRACKET))
                                {
                                    needNextScan = true;
                                }
                            }
                            else
                            {
                                // Otherwise we are between brackets, so every char will be reversed
                                // including brackets (')' -> '(').
                                reversedSubstring.Push(STARTING_BRACKET);
                            }
                            break;
                        default:
                            // On any other char, just add it to be remembered.
                            if (bracketLevel == 0)
                            {
                                // Either as it is...
                                nonBracketStringBuilder.Append(c);
                            }
                            else
                            {
                                // ... or to be reversed once we left a pair of brackets in which we are now.
                                reversedSubstring.Push(c);
                            }
                            break;
                    }
                }

                // If any char was left behind add it as well.
                if (nonBracketStringBuilder.Length > 0)
                {
                    substringQueue.Enqueue(nonBracketStringBuilder.ToString());
                    nonBracketStringBuilder = new StringBuilder();
                }
                // Rescan the entire queue if needed (there are still some items that require processing).
                if (itemsToPull == 0 && needNextScan)
                {
                    needNextScan = false;
                    itemsToPull += substringQueue.Count;
                }
            } while (itemsToPull > 0);

            // Build a result string from it's chunks in the queue.
            reverseStringBuilder = new StringBuilder();
            IEnumerator<string> queueEnumerator = substringQueue.GetEnumerator();
            while (queueEnumerator.MoveNext())
            {
                reverseStringBuilder.Append(queueEnumerator.Current);
            }

            return reverseStringBuilder.ToString();
        }
    }
}
