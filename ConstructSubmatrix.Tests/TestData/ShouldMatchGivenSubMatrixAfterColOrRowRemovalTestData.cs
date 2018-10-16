using System.Collections;
using System.Collections.Generic;

namespace ConstructSubmatrix.Tests.TestData
{
    class ShouldMatchGivenSubMatrixAfterColOrRowRemovalTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: int[][] matrix, int[] rowsToDelete, int[] columnsToDelete
			// Outputs: int[][]
            yield return new object[] { };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

