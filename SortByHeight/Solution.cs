using System;
using System.Collections.Generic;
using System.Linq;

namespace SortByHeight
{
    public class Solution
    {
        public static int[] sortByHeight(int[] a)
        {
            int arrayLength = a.Length;
            Queue<int> fixedElements = new Queue<int>();
            ICollection<int> elementsToSort = new List<int>();

            for (int i = 0; i < arrayLength; i += 1)
            {
                if (a[i] == -1)
                {
                    fixedElements.Enqueue(i);
                }
                else
                {
                    elementsToSort.Add(a[i]);
                }
            }

            int idx = 0;
            int jdx = 0;
            int fixedElement;
            int[] sortedElementsArray = elementsToSort.ToArray();
            Array.Sort(sortedElementsArray);

            while (fixedElements.Count > 0)
            {
                fixedElement = fixedElements.Dequeue();
                while (idx < fixedElement)
                {
                    a[idx] = sortedElementsArray[jdx];
                    idx += 1;
                    jdx += 1;
                }
                a[idx] = -1;
                idx += 1;
            }

            while (idx < arrayLength)
            {
                a[idx] = sortedElementsArray[jdx];
                idx += 1;
                jdx += 1;
            }

            return a;
        }
    }
}
