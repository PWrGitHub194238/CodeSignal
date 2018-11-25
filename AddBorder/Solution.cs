
using System.Collections.Generic;
using System.Text;

namespace AddBorder
{
    public class Solution
    {
        public static string[] addBorder(string[] picture)
        {
            int pictureWidth = picture[0].Length;
            string topBottimBorder = new string('*', pictureWidth + 2);

            List<string> borderedPicture = new List<string>
            {
                topBottimBorder
            };

            foreach (var pictureRow in picture)
            {
                borderedPicture.Add(
                    new StringBuilder("*")
                        .Append(pictureRow)
                        .Append("*")
                        .ToString());
            }

            borderedPicture.Add(topBottimBorder);

            return borderedPicture.ToArray();
        }
    }
}
