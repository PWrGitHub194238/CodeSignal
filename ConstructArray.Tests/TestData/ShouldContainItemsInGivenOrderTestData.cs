using System.Collections;
using System.Collections.Generic;

namespace ConstructArray.Tests.TestData
{
    class ShouldContainItemsInGivenOrderTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 7, new int[] { 1, 7, 2, 6, 3, 5, 4 } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

