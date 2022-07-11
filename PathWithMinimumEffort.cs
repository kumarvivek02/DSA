using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class PathWithMinimumEffort
    {
        public PathWithMinimumEffort()
        {
        }

        public int MinimumEffortPath(int[][] heights)
        {
            int rows = heights.GetLength(0);
            int cols = heights[0].Length;

            if (rows < 0 || cols < 0) return 0;

            var dirs = new int[,]
            {
                {1,0 },
                {-1,0 },
                {0,1 },
                {0,-1 }
            };

            var costMatrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    costMatrix[i, j] = Int32.MaxValue;
                }
            }

            PriorityQueue<Tuple<int, int, int>, int> pq = new PriorityQueue<Tuple<int, int, int>, int>();

            // Push source node into PQ and ini. cost in costMatrix to 0 for source node.
            pq.Enqueue(new Tuple<int, int, int>(0, 0, 0), 0);
            costMatrix[0, 0] = 0;


            while (pq.Count > 0)
            {
                var front = pq.Dequeue();
                var currX = front.Item1;
                var currY = front.Item2;
                var currCost = front.Item3;

                if (currX == rows - 1 && currY == cols - 1) return currCost;



                for (int i = 0; i < 4; i++)
                {
                    var adjacentX = currX + dirs[i, 0];
                    var adjacentY = currY + dirs[i, 1];

                    //Check if neighbor is valid
                    if (adjacentX >= 0 && adjacentX <= rows - 1 && adjacentY >= 0 && adjacentY <= cols - 1)
                    {
                        var diff = Math.Abs(heights[currX][currY] - heights[adjacentX][adjacentY]);

                        //Find Max effort to get to ADj. Cell
                        var currMaxEffort = Math.Max(diff, currCost);

                        var currMinEffort = costMatrix[adjacentX, adjacentY];

                        if (currMaxEffort < currMinEffort)
                        {
                            // Update min cost to get to this adj. cell
                            costMatrix[adjacentX, adjacentY] = Math.Min(currMaxEffort, costMatrix[adjacentX, adjacentY]);
                            pq.Enqueue(new Tuple<int, int, int>(adjacentX, adjacentY, costMatrix[adjacentX, adjacentY]), costMatrix[adjacentX, adjacentY]);
                        }
                    }
                }
            }

            return costMatrix[rows - 1, cols - 1];

        }

        //public int MinimumEffortPath(int[][] heights)
        //{

        //    int rows = heights.Length;
        //    int cols = heights[0].Length;

        //    var pq = new PriorityQueue<Tuple<int, int, int>, int>();

        //    var neighbors = new int[4, 2] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };


        //    bool[,] visited = new bool[rows, cols];
        //    int[,] cost = new int[rows, cols];

        //    for (int i = 0; i < rows; i++)
        //    {
        //        for (int j = 0; j < cols; j++)
        //        {
        //            visited[i, j] = false;
        //            cost[i, j] = Int32.MaxValue;
        //        }
        //    }


        //    //initialise with cell 0,0 with a cost of 0
        //    pq.Enqueue(new Tuple<int, int, int>(0, 0, 0), 0);
        //    cost[0, 0] = 0;

        //    while (pq.Count > 0)
        //    {
        //        var top = pq.Dequeue();

        //        if (top.Item1 == rows - 1 && top.Item2 == cols - 1) return top.Item3;

        //        if (visited[top.Item1, top.Item2]) continue;

        //        visited[top.Item1, top.Item2] = true;

        //        for (int i = 0; i < 4; i++)
        //        {

        //            var neighborX = top.Item1 + neighbors[i, 0];
        //            var neighborY = top.Item2 + neighbors[i, 1];

        //            if (neighborX >= 0 && neighborX < rows && neighborY >= 0 && neighborY < cols)
        //            {
        //                var currentDiff = Math.Abs(heights[top.Item1][top.Item2] - heights[neighborX][neighborY]);
        //                var MaxDiff = Math.Max(currentDiff, cost[top.Item1, top.Item2]);

        //                if (cost[neighborX, neighborY] > MaxDiff)
        //                {
        //                    cost[neighborX, neighborY] = MaxDiff;
        //                    pq.Enqueue(new Tuple<int, int, int>(neighborX, neighborY, MaxDiff), MaxDiff);
        //                }

        //            }
        //        }

        //    }

        //    return cost[rows - 1, cols - 1];

        //}
    }
}
