namespace MatrixElementsSum
{
    public class Solution
    {
        public static int MatrixElementsSum(int[][] matrix)
        {
            if (matrix.Length == 0) return 0;

            int matrixWidth = matrix[0].Length;
            int matrixHeight = matrix.Length;

            int[] roomsInColumnAreHaunted = new int[matrixWidth];

            int totalPrice = 0;

            for (int i = 0; i < matrixHeight; i++)
            {
                for (int j = 0; j < matrixWidth; j++)
                {
                    // If there where no free room yet in j'th column and current room is free
                    if (roomsInColumnAreHaunted[j] == 0 && matrix[i][j] == 0)
                    {
                        // mark those column haunted
                        roomsInColumnAreHaunted[j] = 1;
                    }
                    else
                    {
                        // so price of every next room in the same column (under hauned room) is irrelevant (we won't book this room).
                        totalPrice += (1 - roomsInColumnAreHaunted[j]) * matrix[i][j];
                    }
                }
            }
            return totalPrice;
        }
    }
}