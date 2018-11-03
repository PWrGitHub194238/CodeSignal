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
            yield return new object[] { new int[] { 1, 4, 3, 2, 2, 2, 2, 1, 4, 4, 2, 3, 3, 4, 1, 4, 2, 1, 2, 4, 1, 2, 2, 4, 1 },
                new int[] { 1, 3, 11 }, new int[] { 2, 4, 5, 7, 12, 20, 22 }, 4, 56 };
            yield return new object[] { new int[] { 1, 9, 15, 21, 36 },
                new int[] { }, new int[] { 0, 1, 2, 3, 4 }, 9, 1 };
            yield return new object[] { new int[] { 2, 6, 2, 2, 2, 3, 8, 9, 7, 5, 2, 3, 5, 7, 3, 3, 2, 4, 4, 7, 5, 5, 5, 7, 4,
                5, 10, 2, 10, 10, 3, 5, 2, 9, 2, 6, 7, 8, 2, 8, 8, 3, 6, 8, 9, 3, 2, 5, 6, 6, 4, 2, 1, 4, 1, 8, 9, 2, 4, 9, 9,
                5, 2, 6, 3, 5, 5, 3, 3, 3, 7, 8, 9, 7, 5, 4, 10, 1, 4, 1, 2, 9, 2, 7, 3, 6, 1, 4, 9, 6, 8, 9, 7, 3, 5, 2, 8 },
                new int[] { 4, 10, 12, 19, 26, 33, 35, 40, 43, 46, 47, 51, 69, 71, 73, 74, 75, 79, 80, 93 },
                new int[] { 1, 3, 11, 50, 56, 65, 81, 88, 94 }, 10, 492 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

