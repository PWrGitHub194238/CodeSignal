
using System;

namespace Euclid
{
    public class Solution
    {
        public static double[] euclid(double[] coordinates)
        {
            double Ax = coordinates[0];
            double Ay = coordinates[1];
            double Bx = coordinates[2];
            double By = coordinates[3];
            double Cx = coordinates[4];
            double Cy = coordinates[5];

            double Dx = coordinates[6];
            double Dy = coordinates[7];
            double Ex = coordinates[8];
            double Ey = coordinates[9];
            double Fx = coordinates[10];
            double Fy = coordinates[11];

            double Gx = 0, Gy = 0, Hx = 0, Hy = 0;

            double Hs = 0.5;

            double Hs_min = 0;
            double Hs_max = 1;

            double min = Math.Pow(-10, 5);
            double max = Math.Pow(10, 5);

            // współczynniki prostej AC: y = ax + b
            double aAC, bAC;
            double min_x, min_y, max_x, max_y;


            // Jeśli AC nie jest x = 0 ani y = 0 (jest nachylona pod dowolnym innym kątem
            if (Ax - Cx != 0 && Ay - Cy != 0)
            {
                aAC = (Ay - Cy) / (Ax - Cx);
                bAC = Ay - (Ay - Cy) / (Ax - Cx) * Ax;
                if (aAC >= 0)
                {
                    min_x = -bAC / aAC;
                    min_y = 0;
                    max_x = max;
                    max_y = aAC * max_x + bAC;
                }
                else
                {
                    min_x = min;
                    min_y = 0;
                    max_x = -bAC / aAC;
                    max_y = aAC * max_x + bAC;
                }
                /*min_x = min;
                min_y = aAC * min_x + bAC;
                max_x = max;
                max_y = aAC * max_x + bAC;*/
            }
            else if (Ax - Cx == 0)  // x = 0
            {
                min_x = 0;
                min_y = min;
                max_x = 0;
                max_y = max;
            }
            else
            {
                min_x = min;
                min_y = 0;
                max_x = max;
                max_y = 0;
            }


            // Heron's formula
            // nobody cares about order of a triangle's points.
            double a = Math.Sqrt(Math.Pow(Dx - Ex, 2) + Math.Pow(Dy - Ey, 2));
            double b = Math.Sqrt(Math.Pow(Ex - Fx, 2) + Math.Pow(Ey - Fy, 2));
            double c = Math.Sqrt(Math.Pow(Fx - Dx, 2) + Math.Pow(Fy - Dy, 2));
            double s = (a + b + c) / 2;
            double triangleArea = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            double paralellogramArea;


            double dAB = Math.Sqrt(Math.Pow(Ax - Bx, 2) + Math.Pow(Ay - By, 2));    // |AB|

            double dAC = Math.Sqrt(Math.Pow(Ax - Cx, 2) + Math.Pow(Ay - Cy, 2));    // |AC|

            // współczynniki prostej AB: y = ax + b
            double aAB = (Ay - By) / (Ax - Bx);
            double bAB = Ay - (Ay - By) / (Ax - Bx) * Ax;

            paralellogramArea = double.MinValue;

            while (Math.Round(triangleArea, 3) != Math.Round(paralellogramArea, 3))
            {
                // równanie parametryczne dla punktu H (Hs - [0,1])
                Hx = max_x * Hs + min_x * (1 - Hs);
                Hy = max_y * Hs + min_y * (1 - Hs);

                // A, B, H are 3 of 4 points of paralellogram,
                // A, H are guaranteed to form a one side of it
                double dAH = Math.Sqrt(Math.Pow(Ax - Hx, 2) + Math.Pow(Ay - Hy, 2));    // |AH|


                if (Ax - Hx == 0)   // AH) x = 0
                {
                    paralellogramArea = dAH * Math.Abs(Ax - Bx);
                    Gx = Bx;
                    if (By > Ay)
                    {
                        Gy = By + dAH;
                    }
                    else if (By == Ay)
                    {
                        Gy = Hy;
                    }
                    else
                    {
                        Gy = By - dAH;
                    }
                }
                else if (aAB == 0)  // AB) y = 0
                {
                    double h = dAH;
                    paralellogramArea = dAB * h;
                    Gx = Bx;
                    Gy = Hy;
                }
                else
                {

                    // punkt przecięcia prostej prostopadłej do AB, przechodzącej przez C
                    double Ix, Iy;

                    // równanie prostej prostopadłej do AB: y = -1/a * x + b' i przechodzącej przez C
                    double aCI = -1 / aAB;
                    double bCI = Cy - aCI * Cx;

                    // punkt przecięcia prostych AB i CI
                    Ix = -(bAB - bCI) / (aAB - aCI);
                    Iy = (aAB * bCI - aCI * bAB) / (aAB - aCI);

                    double dCI = Math.Sqrt(Math.Pow(Cx - Ix, 2) + Math.Pow(Cy - Iy, 2));    // |CI|

                    double sin_a = dCI / dAC;

                    // CI - równanie prostopadłej do AB, przechodzącej przez C,
                    // J - punkt przecięcia CI z AB
                    // AJ - podstawa trójkąta AJC, JC - wysokość AJC i wysokość równoległoboku
                    double h = dAH * sin_a;
                    paralellogramArea = dAB * h;

                    // równanie prostej równoległej do AB: y = a * x + b' i przechodzącej przez H
                    double aaHG = aAB;
                    double bbHG = Hy - aaHG * Hx;

                    // współczynniki prostej AH: y = ax + b
                    double aAH = (Ay - Hy) / (Ax - Hx);
                    double bAH = Ay - (Ay - Hy) / (Ax - Hx) * Ax;

                    // równanie prostej równoległej do AH: y = a * x + b' i przechodzącej przez B
                    double aaBG = aAH;
                    double bbBG = By - aaBG * Bx;

                    // punkt przecięcia prostych HG i BG
                    Gx = -(bbHG - bbBG) / (aaHG - aaBG);
                    Gy = (aaHG * bbBG - aaBG * bbHG) / (aaHG - aaBG);
                }

                if (Hy < Ay)
                {
                    if (paralellogramArea > triangleArea)
                    {
                        Hs_min = Hs;

                    }
                    else
                    {
                        Hs_max = Hs;
                    }
                }
                else
                {
                    if (paralellogramArea < triangleArea)
                    {
                        Hs_min = Hs;

                    }
                    else
                    {
                        Hs_max = Hs;
                    }
                }

                Hs = (Hs_max + Hs_min) / 2;
            }

            Gx = Math.Round(Gx, 3);
            Gy = Math.Round(Gy, 3);
            Hx = Math.Round(Hx, 3);
            Hy = Math.Round(Hy, 3);
            return new double[] { Gx, Gy, Hx, Hy };
        }
    }
}
