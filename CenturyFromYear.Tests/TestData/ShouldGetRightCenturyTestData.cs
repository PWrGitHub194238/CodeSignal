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
            yield return new object[] { 500, 1 };
            yield return new object[] { 1000, 1 };
            yield return new object[] { 1001, 2 };
            yield return new object[] { 1999, 2 };
            yield return new object[] { 2000, 3 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

