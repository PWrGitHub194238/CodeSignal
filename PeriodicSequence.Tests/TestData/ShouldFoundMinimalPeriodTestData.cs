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
            yield return new object[] { };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

