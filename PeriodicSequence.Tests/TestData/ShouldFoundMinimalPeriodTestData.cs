using System.Collections;
using System.Collections.Generic;

namespace PeriodicSequence.Tests.TestData
{
    class ShouldFoundMinimalPeriodTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Inputs: int s0, int a, int b, int m
            // Outputs: int
            yield return new object[] { 11, 2, 6, 12, 2 };
            yield return new object[] { 1, 2, 3, 5, 4 };
            yield return new object[] { 0, 0, 0, 1, 1 };
            yield return new object[] { 6, 0, 1, 7, 1 };
            yield return new object[] { 10, 0, 1, 17, 1 };
            yield return new object[] { 6, 0, 2, 7, 1 };
            yield return new object[] { 6, 1, 1, 7, 7 };
            yield return new object[] { 6, 1, 2, 7, 7};
            yield return new object[] { 6, 1, 3, 7, 7 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}