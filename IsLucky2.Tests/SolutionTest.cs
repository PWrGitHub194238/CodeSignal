using IsLucky2.Tests.TestData;
using Xunit;

namespace IsLucky2.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldDeterminateNumberIsLuckyTestData))]
        public void ShouldDeterminateNumberIsLucky(int n, bool expectedResult)
        {
            // Arrange

            // Act
            bool result = Solution.isLucky2(n);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
