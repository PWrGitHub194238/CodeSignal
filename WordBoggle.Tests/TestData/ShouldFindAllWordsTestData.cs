using System.Collections;
using System.Collections.Generic;

namespace WordBoggle.Tests.TestData
{
    internal class ShouldFindAllWordsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Inputs: char[][] board, string[] words
            // Outputs: string[]
            yield return new object[] { new char[][] {
                new char[] { 'R', 'L', 'D' },
                new char[] { 'U', 'O', 'E' },
                new char[] { 'C', 'S', 'O' }
            }, new string[] { "CODE", "SOLO", "RULES", "COOL" },
            new string[] { "CODE", "RULES" } };
            yield return new object[] { new char[][] {
                new char[] { 'A', 'X', 'V', 'W' },
                new char[] { 'A', 'L', 'T' ,'I' },
                new char[] { 'T', 'T', 'J', 'R' }
            }, new string[] { "AXOLOTL", "TAXA", "ABA", "VITA", "VITTA", "GO", "AXAL", "LATTE", "TALA", "RJ" },
                new string[] { "AXAL", "RJ", "TALA", "TAXA", "VITTA" } };
            yield return new object[] { new char[][] {
                new char[] { 'A', 'B' },
                new char[] { 'C', 'D' }
            }, new string[] { },
                new string[] { } };
            yield return new object[] { new char[][] {
            }, new string[] { },
                new string[] { } };
            yield return new object[] { new char[][] {
            }, new string[] { "A", "B","C" },
                new string[] { } };
            yield return new object[] { new char[][] {
                new char[] { 'A' }
            }, new string[] { "A" },
                new string[] { "A" } };
            yield return new object[] { new char[][] {
                new char[] { 'A', 'B', }
            }, new string[] { "A", "B", "C", "AA", "AB", "AC", "BA", "BB", "BC", "CA", "CB", "CC" },
                new string[] { "A", "AB", "B", "BA" } };
            yield return new object[] { new char[][] {
                new char[] { 'A', 'B' },
                new char[] { 'C', 'D' }
            }, new string[] { "A", "AA", "ABCD", "DABC", "BCDA", "CDAB" },
                new string[] { "A", "ABCD", "BCDA", "CDAB", "DABC" } };
            yield return new object[] { new char[][] {
                new char[] { 'A', 'B' },
                new char[] { 'C', 'D' }
            }, new string[] {  "BD", "A", "B", "A", "B", "BD" },
                new string[] { "A", "B", "BD" } };
            yield return new object[] { new char[][] {
                new char[] { 'A', 'B', 'C', 'D' }
            }, new string[] { "C" },
                new string[] { "C" } };
            yield return new object[] { new char[][] {
                new char[] { 'A', 'B', 'C', 'D' }
            }, new string[] { "CB" },
                new string[] { "CB" } };
            yield return new object[] { new char[][] {
                new char[] { 'A', 'B', 'C', 'D' }
            }, new string[] { "BD" },
                new string[] { } };
            yield return new object[] { new char[][] {
                new char[] { 'A', 'B', 'C', 'D' }
            }, new string[] { "DA" },
                new string[] { } };
            yield return new object[] { new char[][] {
                new char[] { 'A', 'B', 'C', 'D' }
            }, new string[] { "AD" },
                new string[] { } };
            yield return new object[] { new char[][] {
                new char[] { 'A', 'A', 'A', 'A' }
            }, new string[] { "A", "AA", "AAA", "AAAA", "AAAAA" },
                new string[] { "A", "AA", "AAA", "AAAA" } };
            yield return new object[] { new char[][] {
                new char[] { 'A', 'B', 'C', 'D' }
            }, new string[] { "B", "B", "B", "B" },
                new string[] { "B" } };
            yield return new object[] { new char[][] {
                new char[] { 'B' }
            }, new string[] { "B", "B", "B", "B" },
                new string[] { "B" } };
            yield return new object[] { new char[][] {
                new char[] { 'B' },
                new char[] { 'B' },
                new char[] { 'B' },
                new char[] { 'B' }
            }, new string[] { "B", "B", "B", "B" },
                new string[] { "B" } };
            yield return new object[] { new char[][] {
                new char[] { 'B' },
                new char[] { 'B' },
                new char[] { 'B' },
                new char[] { 'B' }
            }, new string[] { "B", "BB", "BBB", "BBBB", "BBBBB" },
                new string[] { "B", "BB", "BBB", "BBBB" } };
            yield return new object[] { new char[][] {
                new char[] { 'C', 'C' },
                new char[] { 'C', 'C' },
            }, new string[] { "CCCC", "CCC", "CC", "C", "CCCCC", "CC", "C", "CCC", "CCCC", "CC", "C" },
                new string[] { "C", "CC", "CCC", "CCCC" } };
            yield return new object[] { new char[][] {
                new char[] { 'C', 'C', 'C' },
                new char[] { 'C', 'C', 'C' },
                new char[] { 'C', 'C', 'C' },
            }, new string[] { "CCCCCCCCC", "CCCCCCCC", "CCCCCCC", "CCCCCC", "CCCCC", "CCCC", "CCC", "CC", "C", "CC", "C", "CCCCCCCCCC" },
                new string[] { "C", "CC", "CCC", "CCCC", "CCCCC", "CCCCCC", "CCCCCCC", "CCCCCCCC", "CCCCCCCCC" } };
            yield return new object[] { new char[][] {
                new char[] { 'C', 'C', 'C', 'C' },
                new char[] { 'C', 'C', 'C', 'C' },
                new char[] { 'C', 'C', 'C', 'C' },
                new char[] { 'C', 'C', 'C', 'C' },
            }, new string[] { "CCCCCCCCCCCCCCCCC", "CCCCCCCCCCCCCCCC", "CCCCCCCCCCCCCCC", "CCCCCCCCCCCCCC", "CCCCCCCCCCCCC",
                "CCCCCCCCCCCCC", "CCCCCCCCCCCC","CCCCCCCCCCC", "CCCCCCCCCC", "CCCCCCCCC", "CCCCCCCC", "CCCCCCC", "CCCCCC",
                "CCCCC", "CCCC", "CCC", "CC", "C", "CC", "CCC", "CCCC", "CCCCCC", "CCCCCCCCCCCCCCCCCC", "CCCCCCCC", "CCC" },
                new string[] { "C", "CC", "CCC", "CCCC", "CCCCC", "CCCCCC", "CCCCCCC", "CCCCCCCC",
                    "CCCCCCCCC", "CCCCCCCCCC", "CCCCCCCCCCC", "CCCCCCCCCCCC", "CCCCCCCCCCCCC",
                    "CCCCCCCCCCCCCC", "CCCCCCCCCCCCCCC", "CCCCCCCCCCCCCCCC" } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}