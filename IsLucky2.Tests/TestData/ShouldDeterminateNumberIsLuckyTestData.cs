using System.Collections;
using System.Collections.Generic;

namespace IsLucky2.Tests.TestData
{
    class ShouldDeterminateNumberIsLuckyTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: int n
			// Outputs: bool
            yield return new object[] { 0, null };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

