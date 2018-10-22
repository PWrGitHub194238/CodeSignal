using System.Collections;
using System.Collections.Generic;

namespace TextJustification.Tests.TestData
{
    class ShouldJustifyGivenTextsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: string[] words, int l
			// Outputs: string[]
            yield return new object[] { };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

