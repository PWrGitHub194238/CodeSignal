
namespace ShapeArea
{
    public class Solution
    {
        public static int shapeArea(int n)
        {
            // 1 5 13 25
            // T(n) = T(n-1) + 2*(2*(n-1) + 1) - 2
            // T(n) = T(n-1) + 4n - 4
            // T(n) = T(n-1) + 4*(n-1)
            // T(0) = 0
            // T(1) = 1
            // T(2) = 1 + 4*1 = 5
            // T(3) = 5 + 4*2 = 13
            // T(4) = 13 + 4*3 = 25

            if (n < 2)
            {
                return n;
            }

            return 4 * (n - 1) + shapeArea(n - 1);
        }
    }
}
