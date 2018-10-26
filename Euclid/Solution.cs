
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

            // Heron's formula
            // nobody cares about order of a triangle's points.
            double dDE = Math.Sqrt(Math.Pow(Dx - Ex, 2) + Math.Pow(Dy - Ey, 2));
            double dEF = Math.Sqrt(Math.Pow(Ex - Fx, 2) + Math.Pow(Ey - Fy, 2));
            double dFD = Math.Sqrt(Math.Pow(Fx - Dx, 2) + Math.Pow(Fy - Dy, 2));
            double s = (dDE + dEF + dFD) / 2;
            double triangleArea = Math.Sqrt(s * (s - dDE) * (s - dEF) * (s - dFD));

        
            double dAB = Math.Sqrt(Math.Pow(Ax - Bx, 2) + Math.Pow(Ay - By, 2));

            double oldHx;
            double oldHy;

            double dBH;
            double dHA;
            double s1;
            double parallelogramArea;

            // współczynniki prostej AC: y = ax + b
            double aAC, bAC;
            double min_x = Ax;
            double min_y = Ay;
            double max_x, max_y;

            // Math.Pow(10, 5)

            // Jeśli AC nie jest x = 0 ani y = 0 (jest nachylona pod dowolnym innym kątem
            if (Ax - Cx != 0 && Ay - Cy != 0)
            {
                aAC = (Ay - Cy) / (Ax - Cx);
                bAC = Ay - (Ay - Cy) / (Ax - Cx) * Ax;
                max_x = Math.Pow(10, 5);
                max_y = aAC * max_x + bAC;
            }
            else if (Ax - Cx == 0)  // x = 0
            {
                max_x = 0;
                max_y = Math.Pow(10, 5);
            }
            else    // y = 0
            {
                max_x = Math.Pow(10, 5);
                max_y = 0;
            }

            do {
                oldHx = Hx;
                oldHy = Hy;

                Hx = (min_x + max_x) / 2;
                Hy = (min_y + max_y) / 2;

                dBH = Math.Sqrt(Math.Pow(Bx - Hx, 2) + Math.Pow(By - Hy, 2));
                dHA = Math.Sqrt(Math.Pow(Hx - Ax, 2) + Math.Pow(Hy - Ay, 2));
                s1 = (dAB + dBH + dHA) / 2;
                parallelogramArea = Math.Sqrt(s1 * (s1 - dAB) * (s1 - dBH) * (s1 - dHA)) * 2;

                if (parallelogramArea < triangleArea)
                {
                    min_x = Hx;
                    min_y = Hy;
                } else
                {
                    max_x = Hx;
                    max_y = Hy;
                }
                
            } while (Math.Round(oldHx,3) != Math.Round(Hx, 3) || Math.Round(oldHy, 3) != Math.Round(Hy, 3));

            /*double cABx = (Ax + Bx) / 2;
            double cABy = (Ay + By) / 2;


            Gx = cABx * 2 - Hx;
            Gy = cABy * 2 - Hy;*/

            double cHBx = (Hx + Bx) / 2;
            double cHBy = (Hy + By) / 2;


            Gx = cHBx * 2 - Ax;
            Gy = cHBy * 2 - Ay; 

            return new double[] {
                Math.Round(Gx, 3),
                Math.Round(Gy, 3),
                Math.Round(Hx, 3),
                Math.Round(Hy, 3)
            };
        }
    }
}
