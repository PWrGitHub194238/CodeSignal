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
            yield return new object[] { new int[] { 0, 0, 0, 1 }, 1, new int[] { 1, 1, 0, 1 } };
            yield return new object[] { new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 7 }, 7, new int[] { 2, 0, 7, 1, 1, 1, 2, 7, 7 } };
            yield return new object[] { new int[] { 0, 0 }, 1, new int[] { 1, 1 } };
            yield return new object[] { new int[] { 0 }, 0, new int[] { 0 } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

