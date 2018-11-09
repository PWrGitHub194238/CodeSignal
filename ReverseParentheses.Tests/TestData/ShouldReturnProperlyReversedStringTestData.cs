using System.Collections;
using System.Collections.Generic;

namespace ReverseParentheses.Tests.TestData
{
    class ShouldReturnProperlyReversedStringTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: string s
			// Outputs: string
            yield return new object[] { null, null };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

