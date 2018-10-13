using System.Collections;
using System.Collections.Generic;

namespace Zigzag.Tests.TestData
{
    public class ArrayShouldHaveZigzagMaxSubarrayOfLengthTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new int[] { 9, 8, 8, 5, 3, 5, 3, 2, 8, 6 }, 4 };
            yield return new object[] { new int[] { 4 }, 1 };
            yield return new object[] { new int[] { 4, 4 }, 1 };
            yield return new object[] { new int[] { 2, 1, 4, 4, 1, 4, 4, 1, 2, 0, 1, 0, 0, 3, 1, 3, 4, 1, 3, 4 }, 6 };
            yield return new object[] { new int[] { }, 0 };
            yield return new object[] { new int[] { 1, 1, 2 }, 2 };
            yield return new object[] { new int[] { 2, 1, 1 }, 2 };
            yield return new object[] { new int[] { 1, 4, 1, 4, 4 }, 4 };
            yield return new object[] { new int[] { 5, 4, 1, 4, 5 }, 3 };
            yield return new object[] { new int[] { 4, 4, 1, 4, 4 }, 3 };
            yield return new object[] { new int[] { 4, 1, 4 }, 3 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
