using System;
using System.Collections.Generic;
using System.Drawing;

namespace AllAboutHeaps
{
    public class ShortestPathInHiddenGraph
    {
        public ShortestPathInHiddenGraph()
        {
            /*
             -1     => Source
              0     => Blocked
              1     => Empty
              2     => Target
             
             */
        }
        //private int[][] grid = new int[1002][1002];

        int[,] grid = new int[1002, 1002];
        private char[] instructions = { 'U', 'D', 'L', 'R' };
        private int[] dx = { -1, 1, 0, 0 };
        private int[] dy = { 0, 0, -1, 1 };
        private bool seenTarget = false;

        public int FindShortestPath(GridMaster master)
        {

            //Create a grid


            grid[501, 501] = -1;
            dfs(master, 501, 501);
            return seenTarget ? bfs() : -1;

        }

        private int bfs()
        {
            Queue<int[]> que = new Queue<int[]>();
            que.Enqueue(new int[] { 501, 501 });
            int step = 0, size = 0;

            while (que.Count > 0)
            {
                size = que.Count;
                step++;

                for (int i = 0; i < size; i++)
                {
                    int[] curPoint = que.Dequeue();

                    for (int j = 0; j < dx.Length; j++)
                    {
                        int nextRow = curPoint[0] + dx[j];
                        int nextCol = curPoint[1] + dy[j];
                        if (grid[nextRow, nextCol] == 2)
                        {
                            return step;
                        }
                        if (grid[nextRow, nextCol] != 1)
                        {
                            continue;
                        }
                        grid[nextRow, nextCol] = -1;
                        que.Enqueue(new int[] { nextRow, nextCol });
                    }
                }
            }
            return -1;
        }

        private void dfs(GridMaster master, int row, int col)
        {
            if (master.isTarget())
            {
                grid[row, col] = 2;
                seenTarget = true;
            }

            for (int i = 0; i < dx.Length; i++)
            {
                if (!master.canMove(instructions[i]))
                {
                    continue;
                }

                int nextRow = row + dx[i];
                int nextCol = col + dy[i];

                // has been visited
                if (grid[nextRow, nextCol] != 0)
                {
                    continue;
                }

                grid[nextRow, nextCol] = 1;
                master.move(instructions[i]);
                dfs(master, nextRow, nextCol);
                // backtracking
                if ((i & 1) == 0)
                {
                    master.move(instructions[i + 1]);
                }
                else
                {
                    master.move(instructions[i - 1]);
                }
            }
        }


    }


    public interface GridMaster
    {
        public bool canMove(char direction);
        public void move(char direction);
        public bool isTarget();
    };
}
