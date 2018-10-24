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
            yield return new object[] { new string[] { "This", "is", "an", "example", "of", "text", "justification." },
                16, new string[] { "This    is    an",
                                 "example  of text",
                                 "justification.  " } };
            yield return new object[] { new string[] { "Two", "words." }, 11, new string[] { "Two words. " } };
            yield return new object[] { new string[] { "Two", "words." }, 9, new string[] { "Two      ", "words.   " } };
            yield return new object[] { new string[] { "a", "b", "b", "longword" }, 8, new string[] { "a   b  b", "longword" } };
            yield return new object[] { new string[] { "a", "b", "c", "d", "e" }, 1, new string[] { "a", "b", "c", "d", "e" } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

