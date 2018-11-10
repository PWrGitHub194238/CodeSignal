using System.Collections;
using System.Collections.Generic;

namespace AlternatingSums.Tests.TestData
{
    class ShouldReturnTeamTotalWeightsTestData : IEnumerable<object[]>
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

