using Xunit;
using Zigzag.Tests.TestData;

namespace Zigzag.Tests
{
    public class SolutionTest
    {
        [Theory]
        [ClassData(typeof(ArrayShouldHaveZigzagMaxSubarrayOfLengthTestData))]
        public void ArrayShouldHaveZigzagMaxSubarrayOfLength(int[] inputArray, int maxZigzagSubArrayLength)
        {
            // Arrange

            // Act
            int resultZigzagSubArrayMaxLength = Solution.zigzag(inputArray);

            // Assert
            Assert.Equal(maxZigzagSubArrayLength, resultZigzagSubArrayMaxLength);
        }
    }
}
