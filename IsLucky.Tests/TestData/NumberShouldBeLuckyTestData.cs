using System;
using System.Collections;
using System.Collections.Generic;

namespace IsLucky.Tests.TestData
{
    class NumberShouldBeLuckyTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1230 };
            yield return new object[] { Math.Pow(10, 6) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
