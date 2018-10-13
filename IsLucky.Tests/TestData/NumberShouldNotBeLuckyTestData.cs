using System;
using System.Collections;
using System.Collections.Generic;

namespace IsLucky.Tests.TestData
{
    class NumberShouldNotBeLuckyTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 239017 };
            yield return new object[] { Math.Pow(10, 1) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
