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
            yield return new object[] { new int[] { }, null };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

