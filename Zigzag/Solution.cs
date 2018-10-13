using System;

namespace Zigzag
{
    public class Solution
    {
        public static int zigzag(int[] a)
        {
            int arrayLength = a.Length;
            bool[] isZigzagElement = new bool[arrayLength];
            int maxZigZagSubArrayLength;

            switch (arrayLength)
            {
                case 0:
                case 1:
                    maxZigZagSubArrayLength = arrayLength;
                    break;
                default:
                    isZigzagElement[0] = (a[0].CompareTo(a[1]) != 0);
                    isZigzagElement[arrayLength - 1] = (a[arrayLength - 1].CompareTo(a[arrayLength - 2]) != 0);

                    arrayLength -= 1;
                    for (int i = 1; i < arrayLength; i++)
                    {
                        isZigzagElement[i] = ((a[i - 1].CompareTo(a[i]) < 0) && (a[i].CompareTo(a[i + 1]) > 0))
                            || ((a[i - 1].CompareTo(a[i]) > 0) && (a[i].CompareTo(a[i + 1]) < 0));
                    }

                    int zigZagSubArrayLength = 0;
                    maxZigZagSubArrayLength = zigZagSubArrayLength;
                    int subArrayEndIdx = 0;
                    arrayLength += 1;

                    for (int i = 1; i < arrayLength; i += 1)
                    {
                        if (isZigzagElement[i])
                        {
                            zigZagSubArrayLength += 1;
                            if (zigZagSubArrayLength > maxZigZagSubArrayLength)
                            {
                                maxZigZagSubArrayLength = zigZagSubArrayLength;
                                subArrayEndIdx = i;
                            }
                        } else
                        {
                            zigZagSubArrayLength = 0;
                       }                       
                    }

                    if (maxZigZagSubArrayLength == 0 && isZigzagElement[0] == true)
                    {
                        maxZigZagSubArrayLength = 1;
                    }

                    int subArrayBeginIdx = subArrayEndIdx - (maxZigZagSubArrayLength > 0 ? maxZigZagSubArrayLength - 1 : 0);
                    if (subArrayBeginIdx == 1 || (subArrayBeginIdx > 0 && isZigzagElement[subArrayBeginIdx - 1] == false))
                    {
                        subArrayBeginIdx = 0;
                        maxZigZagSubArrayLength += 1;
                    }

                    if (subArrayEndIdx + 1 < arrayLength && isZigzagElement[subArrayEndIdx + 1] == false)
                    {
                        maxZigZagSubArrayLength += 1;
                    }

                    break;
            }

            return maxZigZagSubArrayLength;
        }
    }
}