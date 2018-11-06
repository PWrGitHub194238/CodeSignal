using System.Collections;
using System.Collections.Generic;

namespace AllLongestStrings.Tests.TestData
{
    class ShouldReturnOnlyLongestStringsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: string[] inputArray
			// Outputs: string[]
            yield return new object[] { new string[] { }, new string[] { } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

