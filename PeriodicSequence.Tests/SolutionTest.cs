
using System;

namespace PeriodicSequence
{
    public class Solution
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s0">the first - s[0] - element in the series (s[0] < m),</param>
        /// <param name="a">multiplier of the expression for the next element in the series (2 ≤ a ≤ 100),</param>
        /// <param name="b">component of the expression for the next element (2 ≤ b ≤ 100),</param>
        /// <param name="m">module of the expression (5 ≤ m ≤ 100),</param>
        /// <returns>the minimum length T of a subperiod in a series (s[i] = s[i+T]).</returns>
        public static int PeriodicSequence(int s0, int a, int b, int m)
        {
            // Track values of items in the series and stores their indexes.
            int[] isPresent = new int[m];
            int idx = 0;
            int s_idx = s0;

            do  // generate next items in series as long as they have uniqe values
            {
                // Store information that value of s[idx] has been generated as idx'th element of this series
                isPresent[s_idx] = idx;
                idx += 1;
                s_idx = GetNextElementInSeries(a, b, previousElement: s_idx, module: m);
            } while (!IsItemValueAlreadyPresentInSeries(trackingArray: isPresent, calculatedElement: s_idx));
            // Difference between index of currently calculated element 
            // and the index of the element in s which has the same value as s[idx] gives us a period T. 
            return idx - isPresent[s_idx];
        }

        private static bool IsItemValueAlreadyPresentInSeries(int[] trackingArray, int calculatedElement)
        {
            // Notice that we don't bother about s[0] beeing a first element of a period -
            // to make condition siplified (or beeing forced to initialize trackingArray with non-positive value)
            // we are going to track down the second element in a period (a period's length stays the same 
            // as s[i] =s[i+T] <=> s[i+n] = s[i+n+T], where T is a length of the period).
            return trackingArray[calculatedElement] > 0;
        }

        private static int GetNextElementInSeries(int a, int b, int previousElement, int module)
        {
            return (a * previousElement + b) % module;
        }
    }
}
