using CenturyFromYear.Tests.TestData;
using Xunit;

namespace CenturyFromYear.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldGetRightCenturyTestData))]
        public void ShouldGetRightCentury(int year, int expectedResult)
        {
            // Arrange

            // Act
            int result = Solution.CenturyFromYear(year);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
