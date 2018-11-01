
namespace ShapeArea
{
    public class Solution
    {
        public static int ShapeArea(int n)
        {
            /*
             * A = {0, 1, 5, 13, 25, 41, ... }
             * T(0) = 0 && T(1) = 1 &&
             * T(n) = T(n-1) + 2*(2*(n-1) + 1) - 2 <=> T(n) = T(n-1) + 4n - 4 <=> T(n) = T(n-1) + 4*(n-1)
             * 
             * T(n) = T(n-2) + 4*(n-2) + 4*(n-1) = ... = T(n-(n-1)) + 4*(n-(n-1)) + 4*(n-(n-2)) + ... + 4*(n-(1)) <=>
             * T(n) = T(1) + 4 * Sum_{k=1}^{n-1}n-k = 1 + 4*[(n-1)-(1)+1]*n - 4*Sum_{k=1}^{n-1}k = 1 + 4*n*(n-1) - (4*n*(n-1))/2
             * T(n) = 1 + 4*n*(n-1) - 2*n*(n-1) = 2*n^{2} - 2*n + 1
             * 
             * T(2) = 1 + 4*1 = 5
             * T(3) = 5 + 4*2 = 13
             * T(4) = 13 + 4*3 = 25
             */

            if (n == 0) return 0;
            return 2 * n * n - 2 * n + 1;
        }
    }
}
