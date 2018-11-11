namespace AlternatingSums
{
    public class Solution
    {
        public static int[] AlternatingSums(int[] a)
        {
            int[] teams = new int[2];
            int aLength = a.Length;

            for (int idx = 0; idx < aLength; idx += 1)
            {
                teams[idx % 2] += a[idx];
            }
            return teams;
        }
    }
}