using System.Collections;
using System.Collections.Generic;

namespace DigitRootSort.Tests.TestData
{
    class ShouldSortCorrectlyTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            //yield return new object[] { new int[] { 13, 20, 7, 4 }, new int[] { 20, 4, 13, 7 } };
            yield return new object[] { new int[] { 100, 22, 4, 11, 31, 103 }, new int[] { 100, 11, 4, 22, 31, 103 } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
