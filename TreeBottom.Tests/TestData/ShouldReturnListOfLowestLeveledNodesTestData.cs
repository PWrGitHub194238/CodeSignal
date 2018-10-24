using System.Collections;
using System.Collections.Generic;

namespace TreeBottom.Tests.TestData
{
    class ShouldReturnListOfLowestLeveledNodesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: string tree
			// Outputs: int[]
            yield return new object[] { "(2 (7 (2 () ()) (6 (5 () ()) (11 () ()))) (5 () (9 (4 () ()) ())))", new int[] { 5, 11, 4 } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

