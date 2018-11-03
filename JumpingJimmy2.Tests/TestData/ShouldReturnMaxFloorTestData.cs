using System.Collections;
using System.Collections.Generic;

namespace JumpingJimmy2.Tests.TestData
{
    class ShouldReturnMaxFloorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: int[] tower, int[] power, int[] poison, int jumpHeight
			// Outputs: int
            yield return new object[] { new int[] { }, new int[] { }, new int[] { }, 0, 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

