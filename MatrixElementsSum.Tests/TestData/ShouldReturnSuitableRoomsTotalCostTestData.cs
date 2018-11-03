using System.Collections;
using System.Collections.Generic;

namespace MatrixElementsSum.Tests.TestData
{
    internal class ShouldReturnSuitableRoomsTotalCostTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Inputs: int[][] matrix
            // Outputs: int
            yield return new object[] { new int[][] { }, 0 };
            yield return new object[] { new int[][] {
                new int[] { 0 } }, 0 };
            yield return new object[] { new int[][] {
                new int[] { 0, 0, 0 } }, 0 };
            yield return new object[] { new int[][] {
                new int[] { 0 },
                new int[] { 1 } }, 0 };
            yield return new object[] { new int[][] {
                new int[] { 1 },
                new int[] { 0 } }, 1 };
            yield return new object[] { new int[][] {
                new int[] { 0, 1, 0 } }, 1 };
            yield return new object[] { new int[][] {
                new int[] { 1, 0, 1 } }, 2 };
            yield return new object[] { new int[][] {
                new int[] { 1, 0, 1 },
                new int[] { 0, 1, 0 },
                new int[] { 1, 0, 1 }}, 2 };
            yield return new object[] { new int[][] {
                new int[] { 1, 1, 1 },
                new int[] { 0, 1, 1 },
                new int[] { 1, 0, 1 }}, 6 };
            yield return new object[] { new int[][] {
                new int[] { 0, 1, 1, 2 },
                new int[] { 0, 5, 0, 0 },
                new int[] { 2, 0, 3, 3 } }, 9 };
            yield return new object[] { new int[][] {
                new int[] { 1, 1, 1, 0 },
                new int[] { 0, 5, 0, 1 },
                new int[] { 2, 1, 3, 10 } }, 9 };
            yield return new object[] { new int[][] {
                new int[] { 1, 1, 1 },
                new int[] { 2, 2, 2 },
                new int[] { 3, 3, 3 } }, 18 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}