using System.Collections;
using System.Collections.Generic;

namespace CommonCharacterCount.Tests.TestData
{
    class ShouldCountOnlyCommonCharactersTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: string s1, string s2
			// Outputs: int
            yield return new object[] { "aabcc", "adcaa", 3 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

