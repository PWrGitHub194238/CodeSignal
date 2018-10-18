using System.Collections;
using System.Collections.Generic;

namespace DecodeString.Tests.TestData
{
    class ShouldDecodeStringCorrectlyTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: string s
			// Outputs: string
            yield return new object[] { };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

