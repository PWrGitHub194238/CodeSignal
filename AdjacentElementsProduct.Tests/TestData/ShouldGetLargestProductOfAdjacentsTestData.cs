using System.Collections;
using System.Collections.Generic;

namespace AdjacentElementsProduct.Tests.TestData
{
    class ShouldGetLargestProductOfAdjacentsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: int[] inputArray
			// Outputs: int
            yield return new object[] { new int[] { }, 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

