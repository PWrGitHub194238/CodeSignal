using System.Collections;
using System.Collections.Generic;

namespace BankRequests.Tests.TestData
{
    class ShouldAutomateGivenTransactionSequenceTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			// Inputs: int[] accounts, string[] requests
			// Outputs: int[]
            yield return new object[] { };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

