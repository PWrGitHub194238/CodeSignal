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
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

