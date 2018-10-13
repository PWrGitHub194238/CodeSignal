namespace Zigzag
{
    public class Solution
    {
        public static int Zigzag(int[] a)
        {
            int arrayLength = a.Length;

            switch (arrayLength)
            {
                case 0:
                case 1:
                    // Array of length 1 is always a zigzag.
                    return arrayLength;
                default:
                    return GetZigzagSubArrayMaxLength(inputArray: a, arrayLength: arrayLength);
            }
        }

        private static int GetZigzagSubArrayMaxLength(int[] inputArray, int arrayLength)
        {
            bool[] isZigzagAbleElement = CheckEveryElementIsZigZagAble(arrayToCheck: inputArray, arrayLength: arrayLength);
            return GetTheLongestZigZagSubArrayLength(inputArray: isZigzagAbleElement, arrayLength: arrayLength);
        }

        private static int GetTheLongestZigZagSubArrayLength(bool[] inputArray, int arrayLength)
        {
            int zigZagSubArrayLength = 0;
            int maxZigZagSubArrayLength = zigZagSubArrayLength;
            int subArrayEndIdx = 0;

            // Scan every element for the longest streak of zigzagable elements
            // Do not include first element since - if it is a zigzagable element - it may block other subarrays 
            // of length 1 from being recorded and after the longest subarray would been found, 
            // we always want to be able to expand it by adding additional element 
            // to the beginning of the subarray or it's end.
            for (int i = 1; i < arrayLength; i += 1)
            {
                if (inputArray[i])
                {
                    // Element is zigzagable
                    zigZagSubArrayLength += 1;
                    if (zigZagSubArrayLength > maxZigZagSubArrayLength)
                    {
                        // and it can be added to currently the longest subarray.
                        maxZigZagSubArrayLength = zigZagSubArrayLength;
                        subArrayEndIdx = i;
                    }
                }
                else
                {
                    // Reset counter on non-zigzagable element
                    zigZagSubArrayLength = 0;
                }
            }

            // If no zigzag subarray was found and 1st element is zigzagable.
            if (maxZigZagSubArrayLength == 0 && inputArray[0] == true)
            {
                maxZigZagSubArrayLength = 1;
            }

            int subArrayBeginIdx = GetBeginArrayIndex(lastElementIndex: subArrayEndIdx, numberOfElements: maxZigZagSubArrayLength);

            // After determinating the longest zigzag subarray, we must check 
            // if the previous element of a first element in subarray is not half-zigzagable.
            // If it is, it will be fully zigzagable as a first element of subarray (it's previous element
            // - which makes it non-zigzagable - will be no longer it's neighbor), so we definitely want to add this element to our subarray.
            if (PreviousElementWillBeZigZagAbleAtTheBegining(inputArray: inputArray, indexElement: subArrayBeginIdx))
            {
                //subArrayBeginIdx -= 1;
                maxZigZagSubArrayLength += 1;
            }

            // After determinating the longest zigzag subarray, we must check 
            // if the next element after last element in subarray is not half-zigzagable.
            // If it is, it will be fully zigzagable as a last element of subarray (next element of it 
            // - which makes it non-zigzagable - will be no longer it's neighbor), so we definitely want to add it to our subarray.
            if (NextElementWillBeZigZagAbleAtTheEnd(inputArray: inputArray, indexElement: subArrayEndIdx))
            {
                //subArrayEndIdx += 1;
                maxZigZagSubArrayLength += 1;
            }

            return maxZigZagSubArrayLength;
        }

        private static int GetBeginArrayIndex(int lastElementIndex, int numberOfElements)
        {
            return lastElementIndex - (numberOfElements > 0 ? numberOfElements - 1 : 0);
        }

        private static bool PreviousElementWillBeZigZagAbleAtTheBegining(bool[] inputArray, int indexElement)
        {
            return indexElement == 1 || indexElement > 0 && inputArray[indexElement - 1] == false;
        }

        private static bool NextElementWillBeZigZagAbleAtTheEnd(bool[] inputArray, int indexElement)
        {
            return indexElement == inputArray.Length - 2 || indexElement + 1 < inputArray.Length && inputArray[indexElement + 1] == false;
        }

        private static bool[] CheckEveryElementIsZigZagAble(int[] arrayToCheck, int arrayLength)
        {
            bool[] isZigzagAbleElement = new bool[arrayLength];

            isZigzagAbleElement[0] = IsFirstElementZigZagAble(inputArray: arrayToCheck);
            isZigzagAbleElement[arrayLength - 1] = IsLastElementZigZagAble(inputArray: arrayToCheck);

            arrayLength -= 1;
            for (int i = 1; i < arrayLength; i++)
            {
                isZigzagAbleElement[i] = IsZigZagAble(inputArray: arrayToCheck, elementIndex: i);
            }
            return isZigzagAbleElement;
        }

        private static bool IsFirstElementZigZagAble(int[] inputArray)
        {
            return IsNextElementNotEqual(inputArray: inputArray, elementIndex: 0);
        }

        private static bool IsNextElementNotEqual(int[] inputArray, int elementIndex)
        {
            return inputArray[elementIndex].CompareTo(inputArray[elementIndex + 1]) != 0;
        }

        private static bool IsLastElementZigZagAble(int[] inputArray)
        {
            return IsPreviousElementNotEqual(inputArray: inputArray, elementIndex: inputArray.Length - 1);
        }

        private static bool IsPreviousElementNotEqual(int[] inputArray, int elementIndex)
        {
            return inputArray[elementIndex].CompareTo(inputArray[elementIndex - 1]) != 0;
        }

        private static bool IsZigZagAble(int[] inputArray, int elementIndex)
        {
            return HasSmallerNeighbors(inputArray: inputArray, elementIndex: elementIndex) || HasBiggerNeighbors(inputArray: inputArray, elementIndex: elementIndex);
        }

        private static bool HasSmallerNeighbors(int[] inputArray, int elementIndex)
        {
            return IsElementGreaterThanSuccessor(inputArray: inputArray, elementIndex: elementIndex) && IsElementGreaterThanPredecessor(inputArray: inputArray, elementIndex: elementIndex);
        }

        private static bool IsElementGreaterThanSuccessor(int[] inputArray, int elementIndex)
        {
            return inputArray[elementIndex].CompareTo(inputArray[elementIndex + 1]) > 0;
        }

        private static bool IsElementGreaterThanPredecessor(int[] inputArray, int elementIndex)
        {
            return inputArray[elementIndex].CompareTo(inputArray[elementIndex - 1]) > 0;
        }

        private static bool HasBiggerNeighbors(int[] inputArray, int elementIndex)
        {
            return IsElementSmallerThanSuccessor(inputArray: inputArray, elementIndex: elementIndex) && IsElementSmallerThanPredecessor(inputArray: inputArray, elementIndex: elementIndex);
        }

        private static bool IsElementSmallerThanSuccessor(int[] inputArray, int elementIndex)
        {
            return inputArray[elementIndex].CompareTo(inputArray[elementIndex + 1]) < 0;
        }

        private static bool IsElementSmallerThanPredecessor(int[] inputArray, int elementIndex)
        {
            return inputArray[elementIndex].CompareTo(inputArray[elementIndex - 1]) < 0;
        }
    }
}