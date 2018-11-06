using JumpingJimmy2.Tests.TestData;
using Xunit;

namespace JumpingJimmy2.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldReturnMaxFloorTestData))]
        public void ShouldReturnMaxFloor(int[] tower, int[] power, int[] poison, int jumpHeight, int expectedResult)
        {
            // Arrange

            // Act
            int result = Solution.JumpingJimmy2(tower, power, poison, jumpHeight);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
