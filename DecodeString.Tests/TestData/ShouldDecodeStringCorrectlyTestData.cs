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
            yield return new object[] { "4[ab]", "abababab" };
            yield return new object[] { "2[b3[a]]", "baaabaaa" };
            yield return new object[] { "z1[y]zzz2[abc]", "zyzzzabcabc" };
            yield return new object[] { "100[codesignal]", "codesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignalcodesignal" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

