using System.Collections;
using System.Collections.Generic;

namespace AlternatingSums.Tests.TestData
{
    internal class ShouldReturnTeamTotalWeightsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Inputs: int[] a
            // Outputs: int[]
            yield return new object[] { new int[] { 50, 60, 60, 45, 70 }, new int[] { 180, 105 } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}