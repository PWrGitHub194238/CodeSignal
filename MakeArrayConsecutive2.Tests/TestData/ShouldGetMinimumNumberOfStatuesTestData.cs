using System.Collections;
using System.Collections.Generic;

namespace MakeArrayConsecutive2.Tests.TestData
{
    internal class ShouldGetMinimumNumberOfStatuesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Inputs: int[] statues
            // Outputs: int
            yield return new object[] { new int[] { 6, 2, 3, 8 }, 3 };
            yield return new object[] { new int[] { 0, 3 }, 2 };
            yield return new object[] { new int[] { 1 }, 0 };
            yield return new object[] { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, 0 };
            yield return new object[] { new int[] { 6, 2 }, 3 };
            yield return new object[] { new int[] { 2, 2 }, 0 };
            yield return new object[] { new int[] { 2, 2, 4, 4, 6, 6 }, 2 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

