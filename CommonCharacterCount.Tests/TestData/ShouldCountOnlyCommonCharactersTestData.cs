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
            yield return new object[] { null, null, 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

