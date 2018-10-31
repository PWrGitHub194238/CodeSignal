
namespace MakeArrayConsecutive2
{
    public class Solution
    {
        public const int MIN_STATUSE_SIZE = 0;
        public const int MAX_STATUSE_SIZE = 20;

        public static int MakeArrayConsecutive2(int[] statues)
        {
            int smallestStatueSizeIdx = MIN_STATUSE_SIZE;
            int biggestStatusSizeIdx = MAX_STATUSE_SIZE;
            bool[] hasStatueOfSize = new bool[MAX_STATUSE_SIZE - MIN_STATUSE_SIZE + 1];
            int statuesArrayLength = statues.Length;
            int missingStatues = 0;

            // mark statues of given sizes as posessed
            for (int idx = 0; idx < statuesArrayLength; idx += 1)
            {
                hasStatueOfSize[statues[idx]] = true;
            }

            // stop when we have found the smallest statue in the colection
            while (!hasStatueOfSize[smallestStatueSizeIdx])
            {
                smallestStatueSizeIdx += 1;
            }

            // stop when we have found the biggest statue in the colection
            while (!hasStatueOfSize[biggestStatusSizeIdx])
            {
                biggestStatusSizeIdx -= 1;
            }

            for (int idx = smallestStatueSizeIdx; idx <= biggestStatusSizeIdx; idx++)
            {
                if (hasStatueOfSize[idx] == false)
                {
                    missingStatues += 1;
                }
            }
            return missingStatues;
        }
    }
}
