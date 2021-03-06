using System.Collections;
using System.Collections.Generic;

namespace AllLongestStrings.Tests.TestData
{
    internal class ShouldReturnOnlyLongestStringsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Inputs: string[] inputArray
            // Outputs: string[]
            yield return new object[] { new string[] { "aba", "aa", "ad", "vcd", "aba" }, new string[] { "aba", "vcd", "aba" } };
            yield return new object[] { new string[] { }, new string[] { } };
            yield return new object[] { new string[] { "" }, new string[] { "" } };
            yield return new object[] { new string[] { "", "" }, new string[] { "", "" } };
            yield return new object[] { new string[] { "", " ", "", "", "" }, new string[] { " " } };
            yield return new object[] { new string[] { "", "", " ", "", " " }, new string[] { " ", " " } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

