
namespace AlmostIncreasingSequence
{
    public class Solution
    {
        public static bool almostIncreasingSequence(int[] sequence)
        {
            int sequenceLength = sequence.Length;
            int idx = 1;

            while (idx < sequenceLength && sequence[idx - 1] < sequence[idx])
            {
                idx += 1;
            }

            // Entire seqience is strictly increasing or only the last element violates desired property
            if (idx >= sequenceLength - 1)
            {
                return true;
            }
            else if (idx > 1)
            {
                if (sequence[idx - 2] >= sequence[idx] && sequence[idx - 1] >= sequence[idx + 1])
                {
                    return false;
                }
            }

            idx += 1;

            while (idx < sequenceLength && sequence[idx - 1] < sequence[idx])
            {
                idx += 1;
            }

            return idx == sequenceLength;
        }
    }
}
