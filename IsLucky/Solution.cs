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

            return SumOfDigits(firstHalf, halfNumberOfDigits) == SumOfDigits(secondHalf, halfNumberOfDigits);
        }

        private static int SumOfDigits(int n, int? numberOfDigits)
        {
            if (numberOfDigits == null)
            {
                numberOfDigits = (int)(Math.Floor(Math.Log10(n)) + 1);
            }

            int sum = 0;

            for (int i = 0; i < numberOfDigits; i += 1)
            {
                sum += (n % 10);
                n = n / 10;
            }
            return sum;
        }
    }
}
