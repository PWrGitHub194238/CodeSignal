using System.Collections;
using System.Collections.Generic;

namespace AdjacentElementsProduct.Tests.TestData
{
    internal class ShouldGetLargestProductOfAdjacentsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Inputs: int[] inputArray
            // Outputs: int
            yield return new object[] { new int[] { 3, 6, -2, -5, 7, 3 }, 21 };
            yield return new object[] { new int[] { 1, 2, 3, 0 }, 6 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

