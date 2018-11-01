using System.Collections;
using System.Collections.Generic;

namespace AlmostIncreasingSequence.Tests.TestData
{
    class SequenceShouldBeAlmostIncreasingTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: int[] sequence
			// Outputs: bool
            yield return new object[] { new int[] { 1, 3, 2, 1 }, false };
            yield return new object[] { new int[] { 1, 3, 2 }, true };
            yield return new object[] { new int[] { 1, 2, 1, 2 }, false };
            yield return new object[] { new int[] { 1, 4, 10, 4, 2 }, false };
            yield return new object[] { new int[] { 10, 1, 2, 3, 4, 5 }, true };
            yield return new object[] { new int[] { 1, 1, 1, 2, 3 }, false };
            yield return new object[] { new int[] { 1 }, true };
            yield return new object[] { new int[] { }, true };
            yield return new object[] { new int[] { 1, 1 }, true };
            yield return new object[] { new int[] { 1, 1, 1 }, false };
            yield return new object[] { new int[] { 1, 1, 2 }, true };
            yield return new object[] { new int[] { 1, 1, 100 }, true };
            yield return new object[] { new int[] { 1, 100, 1 }, true };
            yield return new object[] { new int[] { 100, 1, 1 }, false };
            yield return new object[] { new int[] { 1, 2, 3, 4, 99, 5, 6 }, true };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

