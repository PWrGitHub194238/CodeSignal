namespace ConstructArray
{
    public class Solution
    {
        public static int[] constructArray(int size)
        {
            int idx;
            int val = 1;
            int[] array = new int[size];

            for (idx = 1; idx < size; idx += 2)
            {
                array[idx - 1] = val;
                array[idx] = size - (val - 1);
                val += 1;
            }

            if (idx == size)
            {
                array[size - 1] = val;
            }
            return array;
        }
    }
}
