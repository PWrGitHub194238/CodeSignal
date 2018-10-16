using System.Collections;
using System.Collections.Generic;

namespace ConstructArray.Tests.TestData
{
    class ShouldContainItemsInGivenOrderTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {  }; // int size
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

