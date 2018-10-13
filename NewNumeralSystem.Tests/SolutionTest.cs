using NewNumeralSystem.Tests.TestData;
using Xunit;

namespace NewNumeralSystem.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ShouldBePossibleToPresentNumerAsGivenSumOfTwoOtherTestData))]
        public void ShouldBePossibleToPresentNumerAsGivenSumOfTwoOther(char givenNumber, string[] arrayOfSums)
        {
            // Arrange

            // Act
            string[] solutionArray = Solution.NewNumeralSystem(givenNumber);

            // Assert
            Assert.Equal(arrayOfSums, solutionArray);
        }
    }
}
