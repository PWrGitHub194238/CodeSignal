
namespace MatrixElementsSum
{
    public class Solution
    {
        public static int matrixElementsSum(int[][] matrix)
        {
            if (matrix.Length == 0) return 0;

            int matrixWidth = matrix[0].Length;
            int matrixHeight = matrix.Length;

            bool[] roomsInColumnAreHaunted = new bool[matrixWidth];

            int totalPrice = 0;

            for (int i = 0; i < matrixHeight; i++)
            {
                for (int j = 0; j < matrixWidth; j++)
                {
                    if (roomsInColumnAreHaunted[j] == false && matrix[i][j] == 0)
                    {
                        roomsInColumnAreHaunted[j] = true;
                    }
                    else if (roomsInColumnAreHaunted[j] == false)
                    {
                        totalPrice += matrix[i][j];
                    }
                }
            }
            return totalPrice;
        }
    }
}
