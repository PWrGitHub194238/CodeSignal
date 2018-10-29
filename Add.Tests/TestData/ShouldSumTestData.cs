using System.Collections;
using System.Collections.Generic;

namespace Add.Tests.TestData
{
    class ShouldSumTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: int param1, int param2
			// Outputs: int
            yield return new object[] { 0, 0, 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

