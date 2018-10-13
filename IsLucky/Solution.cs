using System;

namespace IsLucky
{
    public class Solution
    {
        public static bool IsLucky(int n)
        {
            int halfNumberOfDigits = (int)(Math.Floor(Math.Log10(n)) + 1) / 2;
            int firstHalf = (int)(n / Math.Pow(10, halfNumberOfDigits));
            int secondHalf = n - (int)(firstHalf * Math.Pow(10, halfNumberOfDigits));

            int i;
            int firstHalfSum = 0;
            int secondHalfSum = 0;

            for (i = 0; i < halfNumberOfDigits; i += 1)
            {
                firstHalfSum += (firstHalf % 10);
                firstHalf = firstHalf / 10;
            }

            for (i = 0; i < halfNumberOfDigits; i += 1)
            {
                secondHalfSum += (secondHalf % 10);
                secondHalf = secondHalf / 10;
            }
            return firstHalfSum == secondHalfSum;
        }
    }
}
