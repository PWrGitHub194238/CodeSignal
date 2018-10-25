using System.Collections;
using System.Collections.Generic;

namespace WordBoggle.Tests.TestData
{
    class ShouldFindAllWordsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: char[][] board, string[] words
			// Outputs: string[]
            yield return new object[] { new char[][] { }, new string[] { }, new string[] { } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

