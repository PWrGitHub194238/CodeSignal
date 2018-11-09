using System.Collections;
using System.Collections.Generic;

namespace SortByHeight.Tests.TestData
{
    class ShouldSortNonDescendingWithoutTreesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: int[] a
			// Outputs: int[]
            yield return new object[] { new int[] { }, new int[] { } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

