using System.Collections;
using System.Collections.Generic;

namespace CenturyFromYear.Tests.TestData
{
    class ShouldGetRightCenturyTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: int year
			// Outputs: int
            yield return new object[] { 1, 1 };
            yield return new object[] { 50, 1 };
            yield return new object[] { 100, 1 };
            yield return new object[] { 101, 2 };
            yield return new object[] { 199, 2 };
            yield return new object[] { 200, 2 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

