using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class SpiralMatrix
    {
        public SpiralMatrix()
        {
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            var dir = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix[0].Length;

            int T = 0;
            int B = rows - 1;

            int L = 0;
            int R = cols - 1;
            // dir = 0 ==> left to Right
            // dir = 1 ==> Top to Bottom
            // dir = 2 ==> Right to Left
            // dir = 3 ==> Bottom to Top

            List<int> res = new List<int>();

            while (T <= B && L <= R)
            {
                if (dir == 0)
                {
                    for (int i = L; i <= R; i++)
                    {
                        res.Add(matrix[T][i]);
                    }
                    T++;
                }
                else if (dir == 1)
                {
                    for (int i = T; i <= B; i++)
                    {
                        res.Add(matrix[i][R]);
                    }
                    R--;
                }
                else if (dir == 2)
                {
                    for (int i = R; i >= L; i--)
                    {
                        res.Add(matrix[B][i]);
                    }
                    B--;
                }
                else if (dir == 3)
                {
                    for (int i = B; i >= T; i--)
                    {
                        res.Add(matrix[i][L]);
                    }
                    L++;
                }

                dir++;
                dir = dir % 4;
            }

            return res;
        }
    }
}
