using System.Collections;
using System.Collections.Generic;

namespace CheckPalindrome.Tests.TestData
{
    class ShouldRecognizePalindromeTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: string inputString
			// Outputs: bool
            yield return new object[] { null, null };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

