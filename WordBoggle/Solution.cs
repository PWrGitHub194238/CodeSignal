using System;
using System.Collections.Generic;
using System.Linq;

namespace WordBoggle
{
    public class Solution
    {
        public const char BOARD_MIN_CHAR = 'A';
        public const char BOARD_MAX_CHAR = 'Z';

        public static string[] WordBoggle(char[][] board, string[] words)
        {
            // If there is no letters on the board, no words can be assembled.
            // If the list of words to be found is empty, we can also immediatly return an empty array.
            if (BoardIsEmpty(board: board) || NoWordsToFind(wordsToFindArray: words))
            {
                return new string[] { };
            }

            //words = Sort(inputArray: words);
            words = RemoveDuplicates(inputArray: words);
            //words = RemoveEmptyWords(inputArray: words);

            // Board sizes (assumed that every row length is equal).
            int boardHeight = board.Length;
            int boardWidth = board[0].Length;

            // Array of all letters' list of coordinates.
            IList<(int x, int y)>[] charToPositionMappingArray = MapLettersFromBoardIntoArray(board: board);
            // Matrix to track moves on the boards as assembling the word.
            bool[][] fieldAlreadyVisited = BuildMatrix<bool>(height: boardHeight, width: boardWidth);
            // List of successfuly assembled words from possible list of words (words array).
            IList<string> assemblyableWordList = new List<string>();

            foreach (var word in words)
            {
                if (WordCanBeAsembled(charMappingArray: charToPositionMappingArray,
                    fieldAlreadyVisited: fieldAlreadyVisited, wordChars: word.ToCharArray(), board: board,
                    boardHeight: boardHeight, boardWidth: boardWidth))
                {
                    assemblyableWordList.Add(word);
                }
            }

            return assemblyableWordList.ToArray();
        }

        private static bool WordCanBeAsembled(IList<(int x, int y)>[] charMappingArray,
            bool[][] fieldAlreadyVisited, char[] wordChars, char[][] board, int boardHeight, int boardWidth)
        {
            // As algorithm keeps going, it puts all characters to which it can reach at a time
            // recording theirs positions, values and order that they would have in a sequence
            // that pottentialy will sum up into the looking word.
            Stack<(int x, int y, char c, int inWordIdx)> reachableCharStack = new Stack<(int x, int y, char c, int inWordIdx)>();
            // Collects information about every move toward next character that is needed to assemble the word.
            // If the word was found, it contains a full sequence of it's chars it a right order,
            // along with each char's position on a board.
            Stack<(int x, int y, char c, int inWordIdx)> onBoardWordPath = new Stack<(int x, int y, char c, int inWordIdx)>();
            IList<(int x, int y, char c, int inWordIdx)> validMoveList;

            // Currently examinated char on the board.
            (int x, int y, char c, int inWordIdx) currentCharInfo;
            (int x, int y, char c, int inWordIdx) backTrackInfo;

            // List of coordinates of a first letter in the word. If there is none - word cannot be found.
            IList<(int x, int y)> firstLetterCoorditateList = charMappingArray[CharToIdx(wordChars[0])];

            int wordLastIdx = wordChars.Length - 1;
            bool wordFound = false;

            // Push each candidate to be computed later.
            foreach (var (x, y) in firstLetterCoorditateList)
            {
                reachableCharStack.Push((x, y, wordChars[0], 0));
            }

            // If there is at least one position on a board with a starting character
            if (reachableCharStack.Count > 0)
            {
                // The word has only one character (starting character) and we have already found it.
                if (wordLastIdx == 0)
                {
                    wordFound = true;
                }
                else
                {
                    // Set the next char that we are going to search for form the last char position in a sequence.
                    int nextCharIdx = 1;
                    char nextChar = wordChars[nextCharIdx];

                    do
                    {
                        currentCharInfo = reachableCharStack.Pop();

                        // If currentCharInfo idicates we have poped out a char with lower index in the word than
                        // the last character in recorded onBoardWordPath, we have to retrieve from that path
                        // as far as this index determinates (we will start tracking the word's path from that point).
                        if (onBoardWordPath.Count > 0)
                        {
                            while (onBoardWordPath.Count > 0 && onBoardWordPath.Peek().inWordIdx >= currentCharInfo.inWordIdx)
                            {
                                backTrackInfo = onBoardWordPath.Pop();
                                fieldAlreadyVisited[backTrackInfo.x][backTrackInfo.y] = false;
                            }
                        }

                        // If we poped out a charracter which is happend to be the ending character for a word
                        // we were able to make a valid path from the starting character to it and we have assembled the word).
                        if (currentCharInfo.inWordIdx == wordLastIdx)
                        {
                            wordFound = true;
                        }
                        else
                        {
                            // If not, make a move toword selected character (which is a next character in the word)
                            nextCharIdx = AdvanceInWordAssemblyPath(onBoardWordPath: onBoardWordPath,
                                fieldAlreadyVisited: fieldAlreadyVisited, currentCharInfo: currentCharInfo);

                            nextChar = wordChars[nextCharIdx];

                            // get all possible moves from that character the next char in our word
                            validMoveList = GetListOfNextValidMovements(currentCharPosX: currentCharInfo.x,
                                currentCharPosY: currentCharInfo.y, nextChar: nextChar, nextCharIdx: nextCharIdx, board: board,
                                boardHeight: boardHeight, boardWidth: boardWidth, fieldAlreadyVisited: fieldAlreadyVisited);

                            // and if there are some, add them to the stack to be processed.
                            if (validMoveList.Count > 0)
                            {
                                foreach (var nextValidReachableChar in validMoveList)
                                {
                                    reachableCharStack.Push(nextValidReachableChar);
                                }
                            }
                            else
                            {
                                // If we couldn't find any valid move, that means we are stuck
                                // and have to go back, retrievieng from the current path by one step.
                                fieldAlreadyVisited[currentCharInfo.x][currentCharInfo.y] = false;
                                nextChar = wordChars[nextCharIdx - 1];
                                onBoardWordPath.Pop();
                            }
                        }
                    } while (reachableCharStack.Count > 0 && currentCharInfo.inWordIdx < wordLastIdx);

                    // After we have built a whole path and found the word, we have to mark each of it's characters as non-visited once more.
                    // A search for a new word needs that to be done (we retrace our steps instead of simply iterating throu entire matrix).
                    fieldAlreadyVisited = MarkAllFieldsAsNonVisited(fieldAlreadyVisited: fieldAlreadyVisited,
                        assembledWordPath: onBoardWordPath);
                }
            }
            return wordFound;
        }

        private static int AdvanceInWordAssemblyPath(Stack<(int x, int y, char c, int inWordIdx)> onBoardWordPath,
            bool[][] fieldAlreadyVisited, (int x, int y, char c, int inWordIdx) currentCharInfo)
        {
            onBoardWordPath.Push(currentCharInfo);
            fieldAlreadyVisited[currentCharInfo.x][currentCharInfo.y] = true;
            return currentCharInfo.inWordIdx + 1;
        }

        private static bool[][] MarkAllFieldsAsNonVisited(bool[][] fieldAlreadyVisited,
            Stack<(int x, int y, char c, int inWordIdx)> assembledWordPath)
        {
            (int x, int y, char c, int inWordIdx) currentCharInfo;
            while (assembledWordPath.Count > 0)
            {
                currentCharInfo = assembledWordPath.Pop();
                fieldAlreadyVisited[currentCharInfo.x][currentCharInfo.y] = false;
            }
            return fieldAlreadyVisited;
        }

        private static IList<(int x, int y, char c, int inWordIdx)> GetListOfNextValidMovements(int currentCharPosX,
            int currentCharPosY, char nextChar, int nextCharIdx, char[][] board, int boardHeight, int boardWidth, bool[][] fieldAlreadyVisited)
        {
            IList<(int x, int y, char c, int inWordIdx)> validMoveList = new List<(int x, int y, char c, int inWordIdx)>();
            int minX = Math.Max(0, currentCharPosX - 1);
            int maxX = Math.Min(currentCharPosX + 1, boardHeight - 1);

            int minY = Math.Max(0, currentCharPosY - 1);
            int maxY = Math.Min(currentCharPosY + 1, boardWidth - 1);

            for (int x = minX; x <= maxX; x += 1)
            {
                for (int y = minY; y <= maxY; y += 1)
                {
                    if (fieldAlreadyVisited[x][y] == false && board[x][y] == nextChar)
                    {
                        validMoveList.Add((x, y, nextChar, nextCharIdx));
                    }
                }
            }
            return validMoveList;
        }

        private static T[][] BuildMatrix<T>(int height, int width)
        {
            T[][] matrix = new T[height][];
            for (int row = 0; row < height; row += 1)
            {
                matrix[row] = new T[width];
            }
            return matrix;
        }

        /// <summary>
        /// Creates an array that for every character avaliable on the board contains a list of that letter coordinates on a board.
        /// E.g. if there are on the board three fields with letter 'F', array['F'] will return a list with three pairs of coordinates (x,y).
        /// </summary>
        /// <param name="board">Matrix containing board game,</param>
        /// <returns>array with lists of coordinates for every letter on the board.</returns>
        private static IList<(int x, int y)>[] MapLettersFromBoardIntoArray(char[][] board)
        {
            int charToPositionMappingArrayLength = BOARD_MAX_CHAR - BOARD_MIN_CHAR + 1;
            IList<(int x, int y)>[] charToPositionMappingArray = new List<(int x, int y)>[charToPositionMappingArrayLength];
            // Board sizes (assumed that every row length is equal).
            int boardHeight = board.Length;
            int boardWidth = board[0].Length;

            for (int i = 0; i < charToPositionMappingArrayLength; i++)
            {
                charToPositionMappingArray[i] = new List<(int x, int y)>();
            }

            for (int x = 0; x < boardHeight; x += 1)
            {
                for (int y = 0; y < boardWidth; y += 1)
                {
                    // Map a board's character to 0-based index and add character's coordinates.
                    charToPositionMappingArray[CharToIdx(asciiChar: board[x][y])].Add((x, y));
                }
            }
            return charToPositionMappingArray;
        }

        private static int CharToIdx(char asciiChar)
        {
            return asciiChar - BOARD_MIN_CHAR;
        }

        private static string[] RemoveEmptyWords(string[] inputArray)
        {
            int inputArrayLength = inputArray.Length;
            IList<string> nonEmptyWordList = new List<string>();
            string currentWord;

            for (int idx = 0; idx < inputArrayLength; idx += 1)
            {
                currentWord = inputArray[idx];
                if (!string.IsNullOrWhiteSpace(currentWord))
                {
                    nonEmptyWordList.Add(currentWord);
                }
            }
            return nonEmptyWordList.ToArray();
        }

        private static string[] RemoveDuplicates(string[] inputArray)
        {
            // If there is only one or no element in the array,
            // it's elements are unique by definition.
            if (inputArray.Length > 1)
            {
                int idx = 0;
                IList<string> uniqueWordList = new List<string>();
                string[] sortedArray = Sort(inputArray: inputArray);
                int sortedarrayLength = sortedArray.Length;
                string arrayLastElement = sortedArray[sortedarrayLength - 1];
                string currentElement = sortedArray[0];

                // While there is some previous elements differ from the last element's value
                while (currentElement != arrayLastElement)
                {
                    idx += 1;
                    if (!currentElement.Equals(sortedArray[idx]))
                    {
                        uniqueWordList.Add(currentElement);
                    }
                    currentElement = sortedArray[idx];
                }
                // Add last unique elements (it was never checked).
                uniqueWordList.Add(arrayLastElement);

                return uniqueWordList.ToArray();
            }
            return inputArray;
        }

        private static string[] Sort(string[] inputArray)
        {
            string[] sortedArray = (string[])inputArray.Clone();
            Array.Sort(sortedArray);
            return sortedArray;
        }

        private static bool NoWordsToFind(string[] wordsToFindArray)
        {
            return wordsToFindArray.Length == 0;
        }

        private static bool BoardIsEmpty(char[][] board)
        {
            return board.Length == 0;
        }
    }
}
