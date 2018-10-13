using System.Collections;
using System.Collections.Generic;

namespace NewNumeralSystem.Tests.TestData
{
    class ShouldBePossibleToPresentNumerAsGivenSumOfTwoOtherTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 'G', new string[] { "A + G", "B + F", "C + E", "D + D" } };
            yield return new object[] { 'A', new string[] { "A + A" } };
            yield return new object[] { 'Z', new string[] {
                "A + Z", "B + Y", "C + X", "D + W", "E + V", "F + U", "G + T",
                "H + S", "I + R", "J + Q", "K + P", "L + O", "M + N" } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
