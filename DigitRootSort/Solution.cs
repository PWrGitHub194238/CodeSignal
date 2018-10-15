using System;
using System.Collections.Generic;

namespace DigitRootSort
{
    public class Solution
    {
        public static int[] digitRootSort(int[] a)
        {
            int inputArrayLength = a.Length;
            int[] digitRootArray = new int[inputArrayLength];
            int number, digitRoot;

            for (int i = 0; i < inputArrayLength; i++)
            {
                digitRoot = 0;
                number = a[i];
                while (number > 0)
                {
                    digitRoot += (number % 10);
                    number /= 10;
                }
                digitRootArray[i] = digitRoot;
            }

            Array.Sort(digitRootArray, a, Comparer<int>.Create((k1, k2) => k1.CompareTo(k2)));

            int prevItem, currentItem = digitRootArray[0], beginIdx = 0, endIdx = 0;

            //2 4 4 7 8
            for (int i = 1; i < inputArrayLength; i++)
            {
                prevItem = currentItem;
                currentItem = digitRootArray[i];

                if (prevItem != currentItem)
                {
                    if (endIdx > beginIdx)
                    {
                        Array.Sort(a, beginIdx, endIdx + 1 - beginIdx, Comparer<int>.Create((k1, k2) => k1.CompareTo(k2)));
                    }
                    beginIdx = i;

                }
                else
                {
                    endIdx = i;
                }
            }

            if (endIdx > beginIdx)
            {
                Array.Sort(a, beginIdx, endIdx + 1 - beginIdx, Comparer<int>.Create((k1, k2) => k1.CompareTo(k2)));
            }
            return a;
        }
    }
}
