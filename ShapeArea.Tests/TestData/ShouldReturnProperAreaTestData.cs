using System.Collections;
using System.Collections.Generic;

namespace ShapeArea.Tests.TestData
{
    class ShouldReturnProperAreaTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: int n
			// Outputs: int
            yield return new object[] { 0, 0 };
            yield return new object[] { 1, 1 };
            yield return new object[] { 2, 5 };
            yield return new object[] { 3, 13 };
            yield return new object[] { 4, 25 };
            yield return new object[] { 5, 41 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

