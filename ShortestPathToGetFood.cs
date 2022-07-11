using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class ShortestPathToGetFood
    {
        public ShortestPathToGetFood()
        {
        }

        public int GetFood(char[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
            bool[,] visited = new bool[rows, cols];

            int[][] dirs =
            {
                new int[]{1,0 },
                new int[]{-1,0 },
                new int[]{0,1 },
                new int[]{0,-1},
            };

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == '*')
                    {
                        queue.Enqueue(new Tuple<int, int, int>(i, j, 0));
                        break;
                    }
                }
            }

            while (queue.Count > 0)
            {
                var frontItem = queue.Dequeue();

                var X = frontItem.Item1;
                var Y = frontItem.Item2;
                var C = frontItem.Item3;

                if (visited[X, Y]) continue;

                visited[X, Y] = true;

                foreach (var dir in dirs)
                {
                    var newX = X + dir[0];
                    var newY = Y + dir[1];

                    if (newX >= 0 && newX < rows && newY >= 0 && newY < cols)
                    {
                        if (grid[newX][newY] == 'X') continue;

                        else if (grid[newX][newY] == 'O')
                        {
                            queue.Enqueue(new Tuple<int, int, int>(newX, newY, C + 1));
                        }
                        else if (grid[newX][newY] == '#')
                        {
                            return (C + 1);
                        }
                    }
                }
            }

            return -1;
        }
    }
}
