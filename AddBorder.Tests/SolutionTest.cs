using AddBorder.Tests.TestData;
using Xunit;

namespace AddBorder.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldReturnPictureWithBorderAddedTestData))]
        public void ShouldReturnPictureWithBorderAdded(string[] picture, string[] expectedResult)
        {
            // Arrange

            // Act
            string[] result = Solution.addBorder(picture);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
