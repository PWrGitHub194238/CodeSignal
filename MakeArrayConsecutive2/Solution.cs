
namespace MakeArrayConsecutive2
{
    public class Solution
    {
        public static int makeArrayConsecutive2(int[] statues)
        {
            int smallestStatueSize = 0;
            int biggestStatusSize = 0;
            bool[] hasStatueOfSize = new bool[20];
            int missingStatues = 0;

            for (int idx = 0; idx < statues.Length; idx++)
            {
                hasStatueOfSize[statues[idx]] = true;
            }

            for (int idx = 0; idx < hasStatueOfSize.Length; idx++)
            {
                if (hasStatueOfSize[idx] == true)
                {
                    smallestStatueSize = idx;
                    break;
                }
            }
            for (int idx = hasStatueOfSize.Length - 1; idx >= 0; idx -= 1)
            {
                if (hasStatueOfSize[idx] == true)
                {
                    biggestStatusSize = idx;
                    break;
                }
            }

            for (int idx = smallestStatueSize; idx <= biggestStatusSize; idx++)
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
