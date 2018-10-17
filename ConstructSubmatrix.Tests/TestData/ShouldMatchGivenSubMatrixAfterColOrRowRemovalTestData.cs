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
            yield return new object[] {
                new int[][] {
                    new int[] { 1, 0, 0, 2 },
                    new int[] { 0, 5, 0, 1 },
                    new int[] { 0, 0, 3, 5 }
                }, new int[] { 1 }, new int[] { 0, 2 },
                new int[][] {
                    new int[] { 0, 2 },
                    new int[] { 0, 5 }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

