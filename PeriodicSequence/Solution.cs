
namespace PeriodicSequence
{
    public class Solution
    {
        public static int periodicSequence(int s0, int a, int b, int m)
        {
            int[] isPresent = new int[m];
            int idx = 0;
            int s_idx = s0;
            do
            {
                isPresent[s_idx] = idx;
                idx += 1;
                s_idx = (a * s_idx + b) % m;
            } while (isPresent[s_idx] == 0);
            return idx - isPresent[s_idx];
        }
    }
}
