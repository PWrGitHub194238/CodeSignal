
using System.Collections.Generic;
using System.Text;

namespace ReverseParentheses
{
    public class Solution
    {
        public static string reverseParentheses(string s)
        {
            int bracketLevel = 0;
            StringBuilder sb, sb1;
            Queue<string> substringQueue = new Queue<string>();
            Stack<char> reversedSubstring = null;
            int oldLength = 1;
            int newQueueSize = 1;
            int queueIdx = 1;
            bool needNextScan = s.Contains('(');
            substringQueue.Enqueue(s);

            do
            {
                oldLength = substringQueue.Count;
                var charArray = substringQueue.Dequeue().ToCharArray();
                queueIdx -= 1;
                newQueueSize -= 1;
                sb1 = new StringBuilder();
                for (int i = 0; i < charArray.Length; i++)
                {
                    var c = charArray[i];
                    switch (c)
                    {
                        case '(':
                            if (bracketLevel == 0)
                            {
                                if (sb1.Length > 0)
                                {
                                    substringQueue.Enqueue(sb1.ToString());
                                    newQueueSize += 1;
                                    sb1 = new StringBuilder();
                                }
                                reversedSubstring = new Stack<char>();
                            }
                            else
                            {
                                reversedSubstring.Push(')');
                            }
                            bracketLevel += 1;
                            break;
                        case ')':
                            bracketLevel -= 1;
                            if (bracketLevel == 0)
                            {
                                sb = new StringBuilder();
                                var enumerator = reversedSubstring.GetEnumerator();
                                while (enumerator.MoveNext())
                                {
                                    sb.Append(enumerator.Current);
                                }
                                needNextScan = true;
                                substringQueue.Enqueue(sb.ToString());
                                newQueueSize += 1;
                            }
                            else
                            {
                                reversedSubstring.Push('(');
                            }
                            break;
                        default:
                            if (bracketLevel == 0)
                            {
                                sb1.Append(c);
                            }
                            else
                            {
                                reversedSubstring.Push(c);
                            }
                            break;
                    }
                }
                if (sb1.Length > 0)
                {
                    substringQueue.Enqueue(sb1.ToString());
                    newQueueSize += 1;
                    sb1 = new StringBuilder();
                }
                if (queueIdx == 0 && needNextScan)
                {
                    needNextScan = false;
                    queueIdx += newQueueSize;
                }
            } while (queueIdx > 0);

            sb = new StringBuilder();

            var enumer = substringQueue.GetEnumerator();

            while (enumer.MoveNext())
            {
                sb.Append(enumer.Current);
            }

            return sb.ToString();
        }
    }
}
