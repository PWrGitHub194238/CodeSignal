using System.Collections;
using System.Collections.Generic;

namespace CommonCharacterCount.Tests.TestData
{
    internal class ShouldCountOnlyCommonCharactersTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Inputs: string s1, string s2
            // Outputs: int
            yield return new object[] { "aabcc", "adcaa", 3 };
            yield return new object[] { "zzzz", "zzzzzzz", 4 };
            yield return new object[] { "", "adcaa", 0 };
            yield return new object[] { "aabcc", "", 0 };
            yield return new object[] { "", "", 0 };
            yield return new object[] { "zzz", "zzz", 3 };
            yield return new object[] { "zz", "z", 1 };
            yield return new object[] { "aabcc", "aaabcc", 5 };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

