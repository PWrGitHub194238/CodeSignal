using AlmostIncreasingSequence.Tests.TestData;
using Xunit;

namespace AlmostIncreasingSequence.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(SequenceShouldBeAlmostIncreasingTestData))]
        public void SequenceShouldBeAlmostIncreasing(int[] sequence, bool expectedResult)
        {
            // Arrange

            // Act
            bool result = Solution.almostIncreasingSequence(sequence);

            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
