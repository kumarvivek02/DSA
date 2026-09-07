using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutHeaps.StacksAndQueues
{
    public class RottingOranges
    {
        public RottingOranges() { }

        public int OrangesRotting(int[][] grid)
        {
            var q = new Queue<(int row, int col)>();
            int rows = grid.Length;
            int cols = grid[0].Length;
            var countGoodOranges = 0;
            var totalMinutes = 0;

            (int dx, int dy)[] neighbors = [(1, 0), (-1, 0), (0, 1), (0, -1)];
            // int[][] Dirs =
            // [
            //     [1, 0],
            //     [-1, 0],
            //     [0, 1],
            //     [0, -1],
            // ];

            //traverse and get list of all oranges  that are initially rotten
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 2)
                        q.Enqueue((i, j));

                    if (grid[i][j] == 1)
                        countGoodOranges++;
                }
            }

            while (q.Count > 0)
            {
                int levelSize = q.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    var (x,y) = q.Dequeue();                    

                    foreach (var (dx, dy) in neighbors)
                    {
                        var newX = x + dx;
                        var newY = y + dy;
                        //out of bounds check
                        if (newX < 0 || newX >= rows || newY < 0 || newY >= cols)
                            continue;
                        
                        //good Orange. Add to Queue coz it's next
                        if (grid[newX][newY] == 1)
                        {
                            q.Enqueue((newX, newY));
                            grid[newX][newY] = 2;
                            countGoodOranges--;
                        }
                    }
                }

                if(q.Count>0) totalMinutes++;
            }

            return countGoodOranges == 0 ? totalMinutes : -1;
        }
    }
}
