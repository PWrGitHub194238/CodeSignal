using System.Collections.Generic;

namespace AddBorder
{
    public class Solution
    {
        public static string[] AddBorder(string[] picture)
        {
            int pictureWidth = picture[0].Length;
            string topBottimBorder = new string('*', pictureWidth + 2);

            List<string> borderedPicture = new List<string>
            {
                topBottimBorder
            };

            foreach (var pictureRow in picture)
            {
                borderedPicture.Add("*" + pictureRow + "*");
            }

            borderedPicture.Add(topBottimBorder);

            return borderedPicture.ToArray();
        }
    }
}
