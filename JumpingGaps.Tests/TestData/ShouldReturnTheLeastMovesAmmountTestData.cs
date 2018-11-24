using System.Collections;
using System.Collections.Generic;

namespace JumpingGaps.Tests.TestData
{
    internal class ShouldReturnTheLeastMovesAmmountTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Inputs: string[] stage
            // Outputs: int
            /*yield return new object[] { new string[] {
                "       E",
                "       #",
                "    #  #",
                "S  ## ##",
                "## ## ##"}, 3 };
            yield return new object[] { new string[] {
                "######################################",
                 "                                      ",
                 "                                      ",
                 "                          ########    ",
                 "                          ########    ",
                 "               ####       ########    ",
                 "           #######################   E",
                 "S          ###########################",
                 "#####  ###############################",
                 "#####  ###############################"}, 13 };
            yield return new object[] { new string[] {
                "      E   ",
                " # ####   ",
                " #        ",
                "  #####   ",
                "          ",
                "        # ",
                "  S     # ",
                " ######## ",
                "          ",
                "          " }, 6 };*/

            yield return new object[] { new string[] {
                "                ",
                "       #        ",
                "       #        ",
                "       #        ",
                "                ",
                "      ##        ",
                "       #        ",
                "       #        ",
                "      S#        ",
                "  ######        ",
                "              E ",
                "        #    ## ",
                "        #    #  ",
                "        #    #  ",
                "        ######  ",
                "                " }, -1 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

