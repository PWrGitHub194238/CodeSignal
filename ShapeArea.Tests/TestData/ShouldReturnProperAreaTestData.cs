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
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

