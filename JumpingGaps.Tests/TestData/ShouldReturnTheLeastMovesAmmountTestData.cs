using System.Collections;
using System.Collections.Generic;

namespace JumpingGaps.Tests.TestData
{
    class ShouldReturnTheLeastMovesAmmountTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: string[] stage
			// Outputs: int
            yield return new object[] { new string[] { }, 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

