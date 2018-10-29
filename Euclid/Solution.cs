
using System;

namespace Euclid
{
    public class Solution
    {
        public const char FIRST_POINT_CHAR = 'A';

        public const char PARALLELOGRAM_POINT_1 = 'A';
        public const char PARALLELOGRAM_POINT_2 = 'B';

        public const char POINT_C = 'C';

        public const char TRIANGLE_POINT_1 = 'D';
        public const char TRIANGLE_POINT_2 = 'E';
        public const char TRIANGLE_POINT_3 = 'F';

        public struct Point
        {
            public readonly double x;
            public readonly double y;

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public static double[] Euclid(double[] coordinates)
        {
            // Get points from array of coordinates.
            Point A = MakePoint(coordinates: coordinates, name: PARALLELOGRAM_POINT_1);
            Point B = MakePoint(coordinates: coordinates, name: PARALLELOGRAM_POINT_2);
            Point C = MakePoint(coordinates: coordinates, name: POINT_C);
            Point D = MakePoint(coordinates: coordinates, name: TRIANGLE_POINT_1);
            Point E = MakePoint(coordinates: coordinates, name: TRIANGLE_POINT_2);
            Point F = MakePoint(coordinates: coordinates, name: TRIANGLE_POINT_3);

            Point G;
            Point H;
            Point prevH;

            // We have to find G and H in such a way that area of parallelogram ABGH is the same as triangle's.
            double triangleArea = GetTriangleArea(pointA: D, pointB: E, pointC: F);
            double parallelogramArea;

            double min_x = A.x;
            double min_y = A.y;
            double max_x, max_y;

            // Based on AC line (point H lies on that straight line) and min/max allowed coordinates [-10^{5},10^{5}]
            // we calculate max point on AC line (assuming that we want max_x > A.x and max_y > A.y).
            (max_x, max_y) = GetStraightLineFunctionMaxValues(linceFunctionCoefficients: GetStraightLineCoefficients(pointA: A, pointB: C));

            // Calculate first middle point of two end values on line AC.
            H = new Point((min_x + max_x) / 2, (min_y + max_y) / 2);

            // Do Binary Search controlled by parallelogram area,
            // break if diffenece between old point H and the new is meaningless.
            do
            {
                prevH = new Point(H.x, H.y);

                parallelogramArea = GetParallelogramArea(pointA: A, pointB: B, pointC: H);

                if (parallelogramArea < triangleArea)
                {
                    min_x = H.x;
                    min_y = H.y;
                }
                else
                {
                    max_x = H.x;
                    max_y = H.y;
                }
                H = new Point((min_x + max_x) / 2, (min_y + max_y) / 2);
            } while (Math.Round(prevH.x, 3) != Math.Round(H.x, 3) || Math.Round(prevH.y, 3) != Math.Round(H.y, 3));

            G = GetMirroredPointByPoint(sourcePoint: A, mirrorByPoint: new Point((H.x + B.x) / 2, (H.y + B.y) / 2));

            return new double[] {
                Math.Round(G.x, 3),
                Math.Round(G.y, 3),
                Math.Round(H.x, 3),
                Math.Round(H.y, 3)
            };
        }

        private static Point GetMirroredPointByPoint(Point sourcePoint, Point mirrorByPoint)
        {
            return new Point(mirrorByPoint.x * 2 - sourcePoint.x, mirrorByPoint.y * 2 - sourcePoint.y);
        }

        private static bool IsConstantFunction(double scaleCoefficient, double shiftCoefficient)
        {
            return scaleCoefficient == 0;
        }

        private static bool IsNotOneToOneFunction(double scaleCoefficient, double shiftCoefficient)
        {
            return scaleCoefficient == double.NegativeInfinity && shiftCoefficient == double.PositiveInfinity;
        }

        private static (double max_x, double max_y) GetStraightLineFunctionMaxValues(
            (double scaleCoefficient, double shiftCoefficient) linceFunctionCoefficients)
        {
            double max_x;
            double max_y;
            bool isOneToOneFunction = !IsNotOneToOneFunction(scaleCoefficient: linceFunctionCoefficients.scaleCoefficient,
                shiftCoefficient: linceFunctionCoefficients.shiftCoefficient);
            bool isNotContantFunction = !IsConstantFunction(scaleCoefficient: linceFunctionCoefficients.scaleCoefficient,
                shiftCoefficient: linceFunctionCoefficients.shiftCoefficient);

            if (isOneToOneFunction && isNotContantFunction)
            {
                max_x = Math.Pow(10, 5);
                max_y = linceFunctionCoefficients.scaleCoefficient * max_x + linceFunctionCoefficients.shiftCoefficient;
            }
            else if (!isOneToOneFunction)  // x = b
            {
                max_x = 0;
                max_y = Math.Pow(10, 5);
            }
            else    // y = b
            {
                max_x = Math.Pow(10, 5);
                max_y = 0;
            }

            return (max_x, max_y);
        }

        // Parallelogram is nothing more than two same triangles and we can caclulate it's area as such.
        private static double GetParallelogramArea(Point pointA, Point pointB, Point pointC)
        {
            return GetTriangleArea(pointA: pointA, pointB: pointB, pointC: pointC) * 2;
        }

        private static (double scaleCoefficient, double shiftCoefficient) GetStraightLineCoefficients(Point pointA, Point pointB)
        {
            if (pointA.x - pointB.x == 0) return (double.NegativeInfinity, double.PositiveInfinity);
            if (pointA.y - pointB.y == 0) return (0, pointA.y);
            double aAB = (pointA.y - pointB.y) / (pointA.x - pointB.x);
            return (aAB, pointA.y - aAB * pointA.x);
        }

        // Heron's formula
        private static double GetTriangleArea(Point pointA, Point pointB, Point pointC)
        {
            double dAB = GetDistanceBetweenPoints(pointA: pointA, pointB: pointB);
            double dBC = GetDistanceBetweenPoints(pointA: pointB, pointB: pointC);
            double dCA = GetDistanceBetweenPoints(pointA: pointC, pointB: pointA);
            double s = (dAB + dBC + dCA) / 2;
            return Math.Sqrt(s * (s - dAB) * (s - dBC) * (s - dCA));
        }

        // Calculate distances from point to point (Pitagoras' formula)
        private static double GetDistanceBetweenPoints(Point pointA, Point pointB)
        {
            return Math.Sqrt(Math.Pow(pointA.x - pointB.x, 2) + Math.Pow(pointA.y - pointB.y, 2));
        }

        private static Point MakePoint(double[] coordinates, char name)
        {
            int argsIdxX = 2 * MapCharToIdx(name);
            int argsIdxY = argsIdxX + 1;
            return new Point(coordinates[argsIdxX], coordinates[argsIdxY]);
        }

        private static int MapCharToIdx(char name)
        {
            return name - FIRST_POINT_CHAR;
        }
    }
}
