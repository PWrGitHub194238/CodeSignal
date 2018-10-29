using Add.Tests.TestData;
using Xunit;

namespace Add.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldSumTestData))]
        public void ShouldSum(int param1, int param2, int expectedResult)
        {
            // Arrange

            // Act
            int result = Solution.Add(param1, param2);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
