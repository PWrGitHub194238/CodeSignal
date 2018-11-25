using System.Collections;
using System.Collections.Generic;

namespace AddBorder.Tests.TestData
{
    internal class ShouldReturnPictureWithBorderAddedTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Inputs: string[] picture
            // Outputs: string[]
            yield return new object[] { new string[] {
                "abc",
                "ded" }, new string[] {
                "*****",
                "*abc*",
                "*ded*",
                "*****"} };
            yield return new object[] { new string[] {
                "" }, new string[] {
                "**",
                "**",
                "**"} };
            yield return new object[] { new string[] {
                " " }, new string[] {
                "***",
                "* *",
                "***"} };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

