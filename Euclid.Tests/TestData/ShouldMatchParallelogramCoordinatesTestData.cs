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
            yield return new object[] { new double[] { 0, 0, 5, 0, 0, 5, 3, 2, 7, 2, 0, 4 }, new double[] { 5, 0.8, 0, 0.8 } };
            yield return new object[] { new double[] { 2, 1, 7, 6, -1, 5, -4, -1, -4, 9, 3, -1 }, new double[] { 2.101, 5, -2.899, 0 } }; // new double[] { 4, 10, -1, 5 }
            yield return new object[] { new double[] { 0, 0, -1, 10, 0, 10, 20, 20, 30, 25, 25, 15 }, new double[] { -1, 47.5, 0, 37.5 } };
            yield return new object[] { new double[] { 1, 2, 19, 27, 9, 33, 30, 25, 25, 15, 20, 20 }, new double[] { 19.838, 30.247, 1.838, 5.247 } };
            yield return new object[] { new double[] { 1.3, 2.6, 12.1, 4.5, 8.1, 13.7, 2.2, 0.1, 9.8, 6.6, 1.9, 6.7 },
                new double[] { 13.756, 7.204, 2.956, 5.304 } };


        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

