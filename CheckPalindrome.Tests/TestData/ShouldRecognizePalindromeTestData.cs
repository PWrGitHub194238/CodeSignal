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
            yield return new object[] { "a", true };
            yield return new object[] { "aa", true };
            yield return new object[] { "aba", true };
            yield return new object[] { "aaba", false };
            yield return new object[] { "ab", false };
            yield return new object[] { "aabaa", true };
            yield return new object[] { "abac", false };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

