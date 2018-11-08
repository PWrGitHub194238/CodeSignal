using System.Collections;
using System.Collections.Generic;

namespace IsLucky2.Tests.TestData
{
    internal class ShouldDeterminateNumberIsLuckyTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Inputs: int n
            // Outputs: bool
            yield return new object[] { 1230, true };
            yield return new object[] { 239017, false };
            yield return new object[] { 134008, true };
            yield return new object[] { 10, false };
            yield return new object[] { 11, true };
            yield return new object[] { 1010, true };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

