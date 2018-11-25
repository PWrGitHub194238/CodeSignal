using System.Collections.Generic;

namespace JumpingGaps
{
    public class Node
    {
        public const char BOARDGAME_TILE_SOLID_BLOCK = '#';
        public const char BOARDGAME_TILE_EMPTY_BLOCK = ' ';
        public const char BOARDGAME_TILE_START_BLOCK = 'S';
        public const char BOARDGAME_TILE_END_BLOCK = 'E';

        public char Tile { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Scanned { get; set; }

        public Node(char tile, int x, int y)
        {
            Tile = tile;
            X = x;
            Y = y;
        }

        internal bool IsBlock()
        {
            return Tile.Equals(BOARDGAME_TILE_SOLID_BLOCK);
        }
    }

    public class Solution
    {
        private const int NO_PATH_CAN_BE_FOUND_RESULT = -1;
        private const int ALLOWED_HORIZONTAL_MOVE_LENGTH = 3;
        private const int ALLOWED_VERTICAL_MOVE_LENGTH = 3;

        public static int JumpingGaps(string[] stage)
        {
            // Stage is empty
            if (stage == null || stage.Length == 0 || stage[0].Length == 0) return NO_PATH_CAN_BE_FOUND_RESULT;

            Node[][] gameboardMatrix = BuildGameBoard(stage: stage);
            Node startPoint = GetStartPoint(gameboard: gameboardMatrix);
            Node endPoint = GetEndPoint(gameboard: gameboardMatrix);

            // Stage has no start and end point
            if (startPoint == null || endPoint == null) return NO_PATH_CAN_BE_FOUND_RESULT;

            // Set of tiles we can end after each move.
            ISet<Node> nextMoveTargetTiles;
            // Set of tiles to be explored for a next move possibilities.
            ISet<Node> startingPointTiles = new HashSet<Node> { startPoint };
            // Whenever during a tile exploration we will be able to reach a new tile.
            bool newTilesReached = true;

            int moves = 0;
            do
            {
                newTilesReached = false;
                IEnumerator<Node> nodeToScan = startingPointTiles.GetEnumerator();
                nodeToScan.Reset();
                moves += 1;

                nextMoveTargetTiles = new HashSet<Node>();
                // Resolve next possible moves for every tile we have ended up on.
                while (nodeToScan.MoveNext())
                {
                    Node tile = nodeToScan.Current;
                    // For each tile we can end up on after a move
                    foreach (Node endMoveTile in ExploreTile(gameboard: gameboardMatrix, tile: tile))
                    {
                        // if it is an end tile, resturn number of moves taken to explore that tile.
                        if (endMoveTile.Tile.Equals('E')) return moves;
                        newTilesReached = true;
                        nextMoveTargetTiles.Add(endMoveTile);
                    }
                }
                startingPointTiles = nextMoveTargetTiles;
            } while (newTilesReached);

            return NO_PATH_CAN_BE_FOUND_RESULT;
        }

        private static IEnumerable<Node> ExploreTile(Node[][] gameboard, Node tile)
        {
            ISet<Node> nextMoveTargetTiles = new HashSet<Node>();
            if (!tile.Scanned)
            {
                tile.Scanned = true;
                int possibleJumpHeight = GetPossibleJumpHeightFromGivenTile(gameboard: gameboard, startingTile: tile,
                    horizontalMoveLength: ALLOWED_HORIZONTAL_MOVE_LENGTH);
                foreach (Node endMoveTile in ExploreTileMoves(gameboard: gameboard, startingTile: tile,
                    horizontalMoveLength: possibleJumpHeight, verticalMoveLength: ALLOWED_VERTICAL_MOVE_LENGTH))
                {
                    yield return endMoveTile;
                }
            }
        }

        private static int GetPossibleJumpHeightFromGivenTile(Node[][] gameboard, Node startingTile, int horizontalMoveLength)
        {
            int currentHeight = startingTile.Y;
            int tileColumnIdx = startingTile.X;
            int possibleJumpHeight = 0;
            while (currentHeight > 0 && possibleJumpHeight < horizontalMoveLength
                && !gameboard[currentHeight - 1][tileColumnIdx].IsBlock())
            {
                currentHeight -= 1;
                possibleJumpHeight += 1;
            }
            return possibleJumpHeight;
        }

        private static IEnumerable<Node> ExploreTileMoves(Node[][] gameboard, Node startingTile, int horizontalMoveLength,
            int verticalMoveLength)
        {
            var nextMoveTargetTiles = new HashSet<Node>();
            int currentTileRowIdx = startingTile.Y;
            int highestRowReachedFromCurrentTileIdx = currentTileRowIdx - horizontalMoveLength;
            // From our position to highets position as we could jump
            for (int y = currentTileRowIdx; y >= highestRowReachedFromCurrentTileIdx; y -= 1)
            {
                // moving right from current jumping position
                for (int x = 1; x <= verticalMoveLength; x += 1)
                {
                    int resultTileColumnIdx = startingTile.X + x;
                    Node resultTile = gameboard[y][resultTileColumnIdx];
                    if (!resultTile.IsBlock())
                    {
                        resultTile = gameboard[GetRowIdxAfterApplyGravity(gameboard: gameboard,
                            currentTileRow: y, currentTileColumn: resultTileColumnIdx)][resultTileColumnIdx];
                        if (!nextMoveTargetTiles.Contains(resultTile))
                        {
                            nextMoveTargetTiles.Add(resultTile);
                            yield return resultTile;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                // moving left from current jumping position
                for (int x = 1; x <= verticalMoveLength; x += 1)
                {
                    int resultTileColumnIdx = startingTile.X - x;
                    Node resultTile = gameboard[y][resultTileColumnIdx];
                    if (!resultTile.IsBlock())
                    {
                        resultTile = gameboard[GetRowIdxAfterApplyGravity(gameboard: gameboard,
                            currentTileRow: y, currentTileColumn: resultTileColumnIdx)][resultTileColumnIdx];
                        if (!nextMoveTargetTiles.Contains(resultTile))
                        {
                            nextMoveTargetTiles.Add(resultTile);
                            yield return resultTile;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }

        private static int GetRowIdxAfterApplyGravity(Node[][] gameboard, int currentTileRow, int currentTileColumn)
        {
            while (!gameboard[currentTileRow + 1][currentTileColumn].IsBlock())
            {
                currentTileRow += 1;
            }
            return currentTileRow;
        }

        private static Node GetStartPoint(Node[][] gameboard)
        {
            return FindFirstTile(gameboard: gameboard, tileType: Node.BOARDGAME_TILE_START_BLOCK);
        }

        private static Node GetEndPoint(Node[][] gameboard)
        {
            return FindFirstTile(gameboard: gameboard, tileType: Node.BOARDGAME_TILE_END_BLOCK);
        }

        private static Node FindFirstTile(Node[][] gameboard, char tileType)
        {
            int gameboardHeight = gameboard.Length;
            int gameboardWidth = gameboard[0].Length;
            Node[] gameboardRow;

            for (int i = 0; i < gameboardHeight; i += 1)
            {
                gameboardRow = gameboard[i];
                for (int j = 0; j < gameboardWidth; j += 1)
                {
                    if (gameboardRow[j].Tile.Equals(tileType))
                    {
                        return gameboardRow[j];
                    }
                }
            }
            return null;
        }

        private static Node[][] BuildGameBoard(string[] stage)
        {
            int stageInnerHeight = stage.Length;
            int stageInnerWidth = stage[0].Length;
            // Plus one rows to gameboard's height because we are allowed to jump beond.
            // By adding one artificial row on top of our gameboard, we ensure that 
            // we would be able to jump through everything.
            int gameboardMatrixHeight = stageInnerHeight + 1 + 2;
            // Also we would like to add some borders around gameboard so we won't have to check
            // tile coordinates every single time, because there will be no such situation 
            // when we have been trying jump outside the board.
            int gameboardMatrixWidth = stageInnerWidth + 2;

            Node[][] gameboardMatrix = new Node[gameboardMatrixHeight][];

            // Add the top border.
            gameboardMatrix = FillRowBorder(gameboard: gameboardMatrix, rowIdx: 0, rowWidth: gameboardMatrixWidth);

            // Add the sky right under the top border
            gameboardMatrix = FillRowSky(gameboard: gameboardMatrix, rowIdx: 0, rowWidth: gameboardMatrixWidth);

            gameboardMatrix = MapStageRows(gameboard: gameboardMatrix, innerBoard: stage,
                rowBeginIdx: 2, rowEndIdx: gameboardMatrixHeight - 1,
                rowWidth: gameboardMatrixWidth, innerBoardWidth: stageInnerWidth);

            // Add the bottom border.
            gameboardMatrix = FillRowBorder(gameboard: gameboardMatrix,
                rowIdx: gameboardMatrixHeight - 1, rowWidth: gameboardMatrixWidth);

            return gameboardMatrix;
        }

        private static Node[][] MapStageRows(Node[][] gameboard, string[] innerBoard,
            int rowBeginIdx, int rowEndIdx, int rowWidth, int innerBoardWidth)
        {
            Node[] gameboardRow;
            char[] innerBoardRowData;
            for (int i = rowBeginIdx; i < rowEndIdx; i += 1)
            {
                gameboard[i] = new Node[rowWidth];

                gameboardRow = gameboard[i];
                innerBoardRowData = innerBoard[i - 2].ToCharArray();

                for (int j = 0; j < innerBoardWidth; j += 1)
                {
                    gameboardRow[j + 1] = new Node(innerBoardRowData[j], j + 1, i);
                }

                gameboard = AddRowBorder(gameboard: gameboard, rowIdx: i);
            }
            return gameboard;
        }

        private static Node[][] FillRowSky(Node[][] gameboard, int rowIdx, int rowWidth)
        {
            gameboard = FillGameboardRow(gameboard: gameboard, rowIdx: 1,
                beginIdx: 1, endIdx: rowWidth - 1, rowWidth: rowWidth, tileType: Node.BOARDGAME_TILE_EMPTY_BLOCK);
            return AddRowBorder(gameboard: gameboard, rowIdx: 1);
        }

        private static Node[][] AddRowBorder(Node[][] gameboard, int rowIdx)
        {
            int rowLastIdx = gameboard[rowIdx].Length - 1;
            gameboard[rowIdx][0] = new Node(Node.BOARDGAME_TILE_SOLID_BLOCK, 0, rowIdx);
            gameboard[rowIdx][rowLastIdx] = new Node(Node.BOARDGAME_TILE_SOLID_BLOCK, rowLastIdx, rowIdx);
            return gameboard;
        }

        private static Node[][] FillRowBorder(Node[][] gameboard, int rowIdx, int rowWidth)
        {
            return FillGameboardRow(gameboard: gameboard, rowIdx: rowIdx,
                beginIdx: 0, endIdx: rowWidth, rowWidth: rowWidth, tileType: Node.BOARDGAME_TILE_SOLID_BLOCK);
        }

        private static Node[][] FillGameboardRow(Node[][] gameboard, int rowIdx,
            int beginIdx, int endIdx, int rowWidth, char tileType)
        {
            Node[] gameboardRow = new Node[rowWidth];
            gameboard[rowIdx] = gameboardRow;
            for (int j = beginIdx; j < endIdx; j += 1)
            {
                gameboardRow[j] = new Node(tileType, j, rowIdx);
            }
            return gameboard;
        }
    }
}