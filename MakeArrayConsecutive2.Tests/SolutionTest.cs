using MakeArrayConsecutive2.Tests.TestData;
using Xunit;

namespace MakeArrayConsecutive2.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldGetMinimumNumberOfStatuesTestData))]
        public void ShouldGetMinimumNumberOfStatues(int[] statues, int expectedResult)
        {
            // Arrange

            // Act
            int result = Solution.MakeArrayConsecutive2(statues);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
