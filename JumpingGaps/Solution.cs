using System;
using System.Collections.Generic;
using System.Text;

namespace JumpingGaps
{

    public class NodeDistComparer : IComparer<Node>
    {
        public int Compare(Node x, Node y)
        {
            return x.Distance.CompareTo(y.Distance);
        }
    }

    public class PriorityQueue<T>
    {
        private IComparer<T> comparer;
        private T[] heap;
        public int Count { get; private set; }
        public PriorityQueue() : this(null) { }
        public PriorityQueue(int capacity) : this(capacity, null) { }
        public PriorityQueue(IComparer<T> comparer) : this(16, comparer) { }
        public PriorityQueue(int capacity, IComparer<T> comparer)
        {
            this.comparer = (comparer == null) ? Comparer<T>.Default : comparer;
            heap = new T[capacity];
        }
        public void push(T v)
        {
            if (Count >= heap.Length) Array.Resize(ref heap, Count * 2);
            heap[Count] = v;
            SiftUp(Count++);
        }
        public T pop()
        {
            var v = top();
            heap[0] = heap[--Count];
            if (Count > 0) SiftDown(0);
            return v;
        }
        public T top()
        {
            if (Count > 0) return heap[0];
            return heap[0];
        }

        private void SiftUp(int n)
        {
            var v = heap[n];
            for (var n2 = n / 2; n > 0 && comparer.Compare(v, heap[n2]) > 0; n = n2, n2 /= 2) heap[n] = heap[n2];
            heap[n] = v;
        }

        private void SiftDown(int n)
        {
            var v = heap[n];
            for (var n2 = n * 2; n2 < Count; n = n2, n2 *= 2)
            {
                if (n2 + 1 < Count && comparer.Compare(heap[n2 + 1], heap[n2]) > 0) n2++;
                if (comparer.Compare(v, heap[n2]) >= 0) break;
                heap[n] = heap[n2];
            }
            heap[n] = v;
        }
    }

    public class Algorithm
    {
        public static void Dijkstra(Node s, Node e)
        {
            var Q = new PriorityQueue<Node>(new NodeDistComparer());
            Q.push(s);

            while (Q.Count > 0)
            {
                Node u = Q.pop();

                foreach (var adj in u.Children)
                {

                    if (adj.Distance > u.Distance + 1)
                    {
                        adj.Distance = u.Distance + 1;
                        adj.Parent = u;
                        Q.push(adj);
                    }
                }
            }
        }
    }





    public class Node
    {
        public char Tile { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Distance { get; set; }
        public Node Parent { get; set; }
        public ISet<Node> Children { get; set; }

        public Node(char tile, int x, int y)
        {
            Tile = tile;
            X = x;
            Y = y;
            Distance = int.MaxValue;
        }
    }

    public class Solution
    {
        public static int jumpingGaps(string[] stage)
        {
            Node startPoint = null;
            Node endPoint = null;
            // Plus one rows to gameboard's height because we are allowed to jump beond.
            // By adding one artificial row on top of our gameboard, we ensure that 
            // we would be able to jump through everything.
            // Also we would like to add some borders around gameboard so we won't have to check
            // tile coordinates every single time, because there will be no such situation 
            // when we have been trying jump outside the board.
            int stageInnerHeight = stage.Length;
            int stageInnerWidth = stage[0].Length;
            int gameboardMatrixHeight = stageInnerHeight + 1 + 2;
            int gameboardMatrixWidth = stageInnerWidth + 2;
            Node[][] gameboardMatrix = new Node[gameboardMatrixHeight][];

            // Add the top border.
            gameboardMatrix[0] = new Node[gameboardMatrixWidth];
            for (int j = 0; j < gameboardMatrixWidth; j++)
            {
                gameboardMatrix[0][j] = new Node('#', j, 0);
            }

            // Add the sky
            gameboardMatrix[1] = new Node[gameboardMatrixWidth];
            gameboardMatrix[1][0] = new Node('#', 0, 1);
            for (int j = 1; j < gameboardMatrixWidth - 1; j++)
            {
                gameboardMatrix[1][j] = new Node(' ', j, 1);
            }
            gameboardMatrix[1][gameboardMatrixWidth - 1] = new Node('#', gameboardMatrixWidth - 1, 1);

            // Copy rest of data
            for (int i = 2; i < gameboardMatrixHeight - 1; i++)
            {
                gameboardMatrix[i] = new Node[gameboardMatrixWidth];
                // Add left border
                gameboardMatrix[i][0] = new Node('#', 0, i);

                var charArray = stage[i - 2].ToCharArray();
                for (int j = 1; j < gameboardMatrixWidth - 1; j++)
                {
                    if (charArray[j - 1] == 'S')
                    {
                        startPoint = new Node(charArray[j - 1], j, i);
                        gameboardMatrix[i][j] = startPoint;
                        startPoint.Distance = 0;
                    }
                    else if (charArray[j - 1] == 'E')
                    {
                        endPoint = new Node(charArray[j - 1], j, i);
                        gameboardMatrix[i][j] = endPoint;
                    }
                    else
                    {
                        gameboardMatrix[i][j] = new Node(charArray[j - 1], j, i);
                    }
                }

                // Add right border
                gameboardMatrix[i][gameboardMatrixWidth - 1] = new Node('#', gameboardMatrixWidth - 1, i);
            }

            // Add the bottom border.
            gameboardMatrix[gameboardMatrixHeight - 1] = new Node[gameboardMatrixWidth];
            for (int j = 0; j < gameboardMatrixWidth; j++)
            {
                gameboardMatrix[gameboardMatrix.Length - 1][j] = new Node('#', j, gameboardMatrix.Length - 1);
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < gameboardMatrixHeight; i++)
            {
                for (int j = 0; j < gameboardMatrixWidth; j++)
                {
                    sb.Append(gameboardMatrix[i][j].Tile);
                }
                sb.AppendLine();
            }

            string s = sb.ToString();

            if (startPoint != null && endPoint != null)
            {
                ISet<Node> beginMoveTiles;
                ISet<Node> endMoveTiles;
                Queue<Node> nodeToScan = new Queue<Node>();

                nodeToScan.Enqueue(startPoint);

                do
                {
                    beginMoveTiles = new HashSet<Node>();
                    endMoveTiles = new HashSet<Node>();
                    Node currentNode = nodeToScan.Dequeue();

                    if (currentNode.Children == null)
                    {
                        currentNode.Children = new HashSet<Node>();
                        //beginMoveTiles.Add(currentNode);
                        /*for (int i = 0; i < 3; i++)
                        {
                            foreach (var node in beginMoveTiles)
                            {
                                for (int x = node.X - 1; x <= node.X + 1; x++)
                                {
                                    for (int y = node.Y - 1; y <= node.Y + 1; y++)
                                    {
                                        if (gameboardMatrix[y][x].Tile != '#')
                                        {
                                            endMoveTiles.Add(gameboardMatrix[y][x]);
                                        }
                                    }
                                }
                            }

                            foreach (var nodeToAdd in endMoveTiles)
                            {
                                beginMoveTiles.Add(nodeToAdd);
                            }
                        }*/

                        int allowedHeight = currentNode.Y;
                        int allowedHeightDelta = 0;
                        while (allowedHeight > 0 && allowedHeightDelta < 3 && gameboardMatrix[allowedHeight - 1][currentNode.X].Tile != '#')
                        {
                            allowedHeight -= 1;
                            allowedHeightDelta += 1;
                        }

                        // From our position to highets position as we could jump
                        for (int y = currentNode.Y; y >= allowedHeight; y -= 1)
                        {
                            // moving right from current jumping position
                            for (int x = 1; x <= 3; x += 1)
                            {
                                if (gameboardMatrix[y][currentNode.X + x].Tile != '#')
                                {
                                    beginMoveTiles.Add(gameboardMatrix[y][currentNode.X + x]);
                                }
                                else
                                {
                                    break;
                                }
                            }

                            // moving left from current jumping position
                            for (int x = 1; x <= 3; x += 1)
                            {
                                if (gameboardMatrix[y][currentNode.X - x].Tile != '#')
                                {
                                    beginMoveTiles.Add(gameboardMatrix[y][currentNode.X - x]);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        foreach (var nodeToAdd in beginMoveTiles)
                        {
                            var x = nodeToAdd.X;
                            var y = nodeToAdd.Y;

                            while (gameboardMatrix[y + 1][x].Tile != '#')
                            {
                                y += 1;
                            }
                            if (gameboardMatrix[y][x] != currentNode)
                            {
                                if (!currentNode.Children.Contains(gameboardMatrix[y][x]))
                                {
                                    currentNode.Children.Add(gameboardMatrix[y][x]);
                                    nodeToScan.Enqueue(gameboardMatrix[y][x]);
                                }
                            }
                        }
                    }
                } while (nodeToScan.Count > 0);
            }

            Algorithm.Dijkstra(startPoint, endPoint);
            var point = endPoint;

            if (point.Parent == null) return -1;
            while (point != startPoint)
            {
                point = point.Parent;
            }
            return endPoint.Distance;
        }
    }
}