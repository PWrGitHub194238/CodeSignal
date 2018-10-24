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
            yield return new object[] { new int[] { 10, 100, 20, 50, 30 }, new string[] {
                "withdraw 2 10", "transfer 5 1 20", "deposit 5 20", "transfer 3 4 15" },
                new int[] { 30, 90, 5, 65, 30 } };
            yield return new object[] { new int[] { 20, 1000, 500, 40, 90  },  new string[] {
                "deposit 3 400", "transfer 1 2 30", "withdraw 4 50" }, new int[] { -2 } };
            yield return new object[] { new int[] { 261, 56616, 60279, 53365, 18657, 82840, 44790, 83941, 64953, 13422 }, new string[]
            {
                "transfer 1 3 68", "transfer 6 9 81881", "withdraw 90 80372", "transfer 4 5 2423",
                "withdraw 4 73899", "deposit 5 73905", "transfer 7 3 93623"
            }, new int[] { -3 } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

