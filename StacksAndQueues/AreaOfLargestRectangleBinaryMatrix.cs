using System;
using System.Collections.Generic;

namespace DSA.StacksAndQueues
{
    public class AreaOfLargestRectangleBinaryMatrix
    {
        public AreaOfLargestRectangleBinaryMatrix()
        {
        }

        public int MaximalRectangle(char[][] matrix)
        {
            int[] colVals = new int[matrix[0].Length];
            int numOfRows = matrix.Length;
            int numOfCols = matrix[0].Length;

            int i = 0;
            AreaOfLargestRectangleInHistogram area = new AreaOfLargestRectangleInHistogram();

            int maxArea = 0;
            for (int j = 0; j < matrix[i].Length; j++)
            {
                colVals[j] = Int32.Parse(matrix[i][j].ToString());
            }

            var res = area.LargestRectangleArea(colVals);
            maxArea = Math.Max(maxArea, res);

            for (i = 1; i < numOfRows; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (Int32.Parse(matrix[i][j].ToString()) == 1)
                    {
                        colVals[j] += 1;
                    }
                    else if (Int32.Parse(matrix[i][j].ToString()) == 0)
                    {
                        colVals[j] = 0;
                    }
                }
                res = area.LargestRectangleArea(colVals);
                maxArea = Math.Max(maxArea, res);
            }

            return maxArea;
        }



    }
}

