using System.Collections;
using System.Collections.Generic;

namespace ChangeRoot.Tests.TestData
{
    class ShouldReturnParentArrayForNewTreeAfterRootChangeTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: int[] parent, int newRoot
			// Outputs: int[]
            yield return new object[] { };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

