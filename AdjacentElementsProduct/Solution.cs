namespace AdjacentElementsProduct
{
    public class Solution
    {
        public static int AdjacentElementsProduct(int[] inputArray)
        {
            int product;
            int maxIdx = inputArray.Length - 1;
            int maxProduct = inputArray[0] * inputArray[1];
            for (int i = 1; i < maxIdx; i += 1)
            {
                product = inputArray[i] * inputArray[i + 1];
                if (product > maxProduct)
                {
                    maxProduct = product;
                }
            }
            return maxProduct;
        }
    }
}
