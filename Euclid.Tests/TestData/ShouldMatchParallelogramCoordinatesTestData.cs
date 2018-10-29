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
            yield return new object[] { new double[] { 0, 0, -1, 10, 0, 10, 20, 20, 30, 25, 25, 15 }, new double[] { -1, 47.5, 0, 37.5 } };
            yield return new object[] { new double[] { 1, 2, 19, 27, 9, 33, 30, 25, 25, 15, 20, 20 }, new double[] { 19.838, 30.247, 1.838, 5.247 } };
            yield return new object[] { new double[] { 1.3, 2.6, 12.1, 4.5, 8.1, 13.7, 2.2, 0.1, 9.8, 6.6, 1.9, 6.7 },
                new double[] { 13.756, 7.204, 2.956, 5.304 } };
            yield return new object[] { new double[] { 917.683, 576.345, 706.645, 616.15, -490.799, 367.801, -140.606, -11.46, 155.487, -341.635, -309.023, 957.086 },
                new double[] { -920.142, 375.283, -709.104, 335.478 } };
            yield return new object[] { new double[] { 563.488, 220.2, -914.645, -677.06, 195.524, -566.953, -513.828, -592.337, 709.471, -770.917, -173.057, 875.43 },
                new double[] { -1324.48, -1553.784, 153.653, -656.524 } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

