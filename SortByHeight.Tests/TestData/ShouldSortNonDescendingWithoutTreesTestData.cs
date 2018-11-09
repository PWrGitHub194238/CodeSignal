using System.Collections;
using System.Collections.Generic;

namespace SortByHeight.Tests.TestData
{
    internal class ShouldSortNonDescendingWithoutTreesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Inputs: int[] a
            // Outputs: int[]
            yield return new object[] { new int[] { -1, 150, 190, 170, -1, -1, 160, 180 },
                new int[] { -1, 150, 160, 170, -1, -1, 180, 190 } };

            yield return new object[] { new int[] { 4, 2, 9, 11, 2, 16 },
                new int[] { 2, 2, 4, 9, 11, 16 } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

