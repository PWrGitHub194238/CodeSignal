using System;

namespace DigitRootSort
{
    public class Solution
    {
        public static int[] DigitRootSort(int[] a)
        {
            int inputArrayLength = a.Length;
            int[] digitRootArray = CalculateDigitRootArray(inputArray: a);

            return DighitRootSort(inputArray: a, digitRootArray: digitRootArray);
        }

        private static int[] CalculateDigitRootArray(int[] inputArray)
        {
            int inputArrayLength = inputArray.Length;
            int[] digitRootArray = new int[inputArrayLength];

            for (int i = 0; i < inputArrayLength; i++)
            {
                digitRootArray[i] = CalculateDigitRoot(number: inputArray[i]);
            }
            return digitRootArray;
        }

        private static int CalculateDigitRoot(int number)
        {
            int digitRoot = 0;
            while (number > 0)
            {
                digitRoot += (number % 10);
                number /= 10;
            }
            return digitRoot;
        }

        private static int[] DighitRootSort(int[] inputArray, int[] digitRootArray)
        {
            // Sort inputArray by keys in digitRootArray
            // We do not care about sorting digitRootArray as a side effect.
            Array.Sort(digitRootArray, inputArray);

            return SortSameRootDigitsInIncOrder(inputArray: inputArray, digitRootArray: digitRootArray);
        }

        private static int[] SortSameRootDigitsInIncOrder(int[] inputArray, int[] digitRootArray)
        {
            int prevItem;
            int currentItem = digitRootArray[0];
            int beginIdx = 0;
            int endIdx = 0;

            int inputArrayLength = inputArray.Length;
            for (int i = 1; i < inputArrayLength; i++)
            {
                prevItem = currentItem;
                currentItem = digitRootArray[i];

                if (prevItem != currentItem)
                {
                    inputArray = SortSameRootDigitsInIncOrderSubArray(inputArray, beginIdx, endIdx);
                    beginIdx = i;
                }
                else
                {
                    endIdx = i;
                }
            }

            inputArray = SortSameRootDigitsInIncOrderSubArray(inputArray, beginIdx, endIdx);
            return inputArray;
        }

        private static int[] SortSameRootDigitsInIncOrderSubArray(int[] inputArray, int beginIdx, int endIdx)
        {
            if (endIdx > beginIdx)
            {
                Array.Sort(inputArray, beginIdx, endIdx + 1 - beginIdx);
            }
            return inputArray;
        }
    }
}