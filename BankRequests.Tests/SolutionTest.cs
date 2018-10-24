using BankRequests.Tests.TestData;
using Xunit;

namespace BankRequests.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldAutomateGivenTransactionSequenceTestData))]
        public void ShouldAutomateGivenTransactionSequence(int[] accounts, string[] requests, int[] expectedResult)
        {
            // Arrange

            // Act
            int[] result = Solution.BankRequests(accounts, requests);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
