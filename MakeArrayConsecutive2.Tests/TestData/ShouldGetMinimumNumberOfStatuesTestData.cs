using System.Collections;
using System.Collections.Generic;

namespace MakeArrayConsecutive2.Tests.TestData
{
    class ShouldGetMinimumNumberOfStatuesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: int[] statues
			// Outputs: int
            yield return new object[] { new int[] { }, 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

