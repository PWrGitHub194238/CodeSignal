using System.Collections;
using System.Collections.Generic;

namespace AddBorder.Tests.TestData
{
    class ShouldReturnPictureWithBorderAddedTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: string[] picture
			// Outputs: string[]
            yield return new object[] { new string[] { }, new string[] { } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

