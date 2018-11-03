namespace AlmostIncreasingSequence
{
    public class Solution
    {
        public static bool AlmostIncreasingSequence(int[] sequence)
        {
            int sequenceLength = sequence.Length;
            int idx = 1;

            // Skip items that form a strictly increasing sequence.
            // Leave either after looping throu entire sequence or on a first element that violates desired property of a sequence.
            while (PairInSequenceIsInStrictlyIncreasingOrder(checkSequence: sequence, nextItemIdxToCheck: idx, sequenceLength: sequenceLength))
            {
                idx += 1;
            }

            // Entire seqience is strictly increasing or only the last element violates desired property.
            // In case of the last element, we can ensure proper behavior of a sequence simply be removing it
            // and we are allowed to do that just one time.
            if (idx >= sequenceLength - 1)
            {
                return true;
            }
            else if (idx > 1)
            {
                // If we cannot obtain a strictly increasing sequence without removing at least two items form a sequence.
                if (IsNotStrictlyIncreasingSequenceWithoutItem(checkSequence: sequence, itemIdxToRemove: idx - 1)
                    && IsNotStrictlyIncreasingSequenceWithoutItem(checkSequence: sequence, itemIdxToRemove: idx))
                {
                    return false;
                }
            }

            // There is still hope that after skipping an item that violates desired sequence properties
            // rest of the sequence is in the right order.
            idx += 1;

            while (PairInSequenceIsInStrictlyIncreasingOrder(checkSequence: sequence, nextItemIdxToCheck: idx, sequenceLength: sequenceLength))
            {
                idx += 1;
            }

            return idx == sequenceLength;
        }

        private static bool PairInSequenceIsInStrictlyIncreasingOrder(int[] checkSequence, int nextItemIdxToCheck, int sequenceLength)
        {
            return nextItemIdxToCheck < sequenceLength && checkSequence[nextItemIdxToCheck - 1] < checkSequence[nextItemIdxToCheck];
        }

        private static bool IsNotStrictlyIncreasingSequenceWithoutItem(int[] checkSequence, int itemIdxToRemove)
        {
            return checkSequence[itemIdxToRemove - 1].CompareTo(checkSequence[itemIdxToRemove + 1]) >= 0;
        }
    }
}