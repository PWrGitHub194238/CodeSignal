using System.Collections;
using System.Collections.Generic;

namespace ReverseParentheses.Tests.TestData
{
    internal class ShouldReturnProperlyReversedStringTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Inputs: string s
            // Outputs: string
            yield return new object[] { "", "" };
            yield return new object[] { "a", "a" };
            yield return new object[] { "abc", "abc" };
            yield return new object[] { "aaaa", "aaaa" };
            yield return new object[] { "a(aa)a", "aaaa" };
            yield return new object[] { "a(b)c(d)e", "abcde" };
            yield return new object[] { "(ab)(cde)(f)(g)", "baedcfg" };
            yield return new object[] { "a(bc)d", "acbd" };
            yield return new object[] { "abc(d(e(fgh)ijk)lm)op(rs)tu(w(xy))z", "abcmlehgfijkdopsrtuxywz" };
            yield return new object[] { "a(bc)de", "acbde" };
            yield return new object[] { "a(bcdefghijkl(mno)p)q", "apmnolkjihgfedcbq" };
            yield return new object[] { "co(de(fight)s)", "cosfighted" };
            yield return new object[] { "Code(Cha(lle)nge)", "CodeegnlleahC" };
            yield return new object[] { "The ((quick (brown) (fox) jumps over the lazy) dog)", "The god quick nworb xof jumps over the lazy" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

