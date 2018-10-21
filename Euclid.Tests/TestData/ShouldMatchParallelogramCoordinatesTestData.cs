using System.Collections;
using System.Collections.Generic;

namespace Euclid.Tests.TestData
{
    class ShouldMatchParallelogramCoordinatesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: double[] coordinates
			// Outputs: double[]
            yield return new object[] { };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

