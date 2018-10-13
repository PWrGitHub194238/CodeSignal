using IsLucky.Tests.TestData;
using Xunit;

namespace IsLucky.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(NumberShouldBeLuckyTestData))]
        public void NumberShouldBeLucky(int n)
        {
            // Arrange

            // Act
            bool isLuckyNumber = Solution.IsLucky(n);

            // Assert
            Assert.True(isLuckyNumber);
        }

        [Theory]
        [ClassData(typeof(NumberShouldNotBeLuckyTestData))]
        public void NumberShouldNotBeLucky(int n)
        {
            // Arrange

            // Act
            bool isNotLuckyNumber = Solution.IsLucky(n);

            // Assert
            Assert.False(isNotLuckyNumber);
        }
    }
}
