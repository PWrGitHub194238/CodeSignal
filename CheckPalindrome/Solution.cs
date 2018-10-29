namespace CheckPalindrome
{
    public class Solution
    {
        public static bool CheckPalindrome(string inputString)
        {
            if (inputString.Length < 2)
            {
                return true;
            }
            else
            {
                int i = 0;
                int j = inputString.Length - 1;
                int halfUpLength = (inputString.Length + 1) / 2;
                char[] charArray = inputString.ToCharArray();
                do
                {
                    if (charArray[i] != charArray[j])
                    {
                        return false;
                    }
                    i += 1;
                    j -= 1;
                } while (i < halfUpLength);
                return true;
            }
        }
    }
}
