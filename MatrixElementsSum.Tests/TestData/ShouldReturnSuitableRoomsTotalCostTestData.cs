using System.Collections;
using System.Collections.Generic;

namespace MatrixElementsSum.Tests.TestData
{
    class ShouldReturnSuitableRoomsTotalCostTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: int[][] matrix
			// Outputs: int
            yield return new object[] { new int[][] { }, 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

