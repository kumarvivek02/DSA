using System;
using System.Collections.Generic;


public class PathWithMaximumMinimumValue
{
    //int[][] preReq =
    //       {
    //           new int[]{3,4,6,3,4},
    //           new int[]{0,2,1,1,7},
    //           new int[]{8,8,3,2,7},
    //           new int[]{3,2,4,9,8},
    //           new int[]{4,1,2,0,0},
    //           new int[]{4,6,5,4,3},



    //        };

    //PathWithMaximumMinimumValue pathWithMaximumMinimumValue = new PathWithMaximumMinimumValue();
    //var res = pathWithMaximumMinimumValue.MaximumMinimumPath(preReq);

    public PathWithMaximumMinimumValue()
    {
    }

    public int MaximumMinimumPath(int[][] grid)
    {
        int rows = grid.Length;
        if (rows == 0) return 0;

        int cols = grid[0].Length;
        var smallest = grid[0][0];

        PriorityQueue<Tuple<int, int>, int> priorityQueue = new PriorityQueue<Tuple<int, int>, int>(new CustomComparer());
        int[][] fourNeighbors =
        {
            new int[]{0,1},
            new int[]{1, 0},
            new int[]{-1, 0},
            new int[]{ 0, -1 }
        };

        var visited = new int[rows, cols];

        visited[0, 0] = 1;
        priorityQueue.Enqueue(new Tuple<int, int>(0, 0), grid[0][0]);

        while (priorityQueue.Count > 0)
        {
            var top = priorityQueue.Dequeue();
            var x = top.Item1;
            var y = top.Item2;

            var val = grid[x][y];
            if (val < smallest)
            {
                smallest = val;
            }

            //Have we reached end of grid?
            if (x == rows - 1 && y == cols - 1) break;

            var largestNeighbor = 0;
            var largestNeighborX = 0;
            var largestNeighborY = 0;

            foreach (var neighbor in fourNeighbors)
            {
                var newX = x + neighbor[0];
                var newY = y + neighbor[1];

                if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && visited[newX, newY] != 1)
                {
                    if (grid[newX][newY] > largestNeighbor)
                    {
                        largestNeighborX = newX;
                        largestNeighborY = newY;
                        largestNeighbor = grid[newX][newY];
                    }

                    visited[newX, newY] = 1;

                }

            }

            priorityQueue.Enqueue(new Tuple<int, int>(largestNeighborX, largestNeighborY), largestNeighbor);

        }

        return smallest;

    }
}

public class CustomComparer : IComparer<int>
{
    // Sort in DESCENDING Order
    public int Compare(int x, int y)
    {
        if (x == y)
        {
            return 0;
        }
        else if (x > y)
        {
            return -1;
        }
        else return 1;

    }


}

