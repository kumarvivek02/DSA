using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class DetonateMaximumNumberOfBombs
    {
        public DetonateMaximumNumberOfBombs()
        {
        }

        public int MaximumDetonation(int[][] bombs)
        {
            int rows = bombs.Length;
            int cols = bombs[0].Length;


            int max = 0;
            for (int i = 0; i < rows; i++)
            {
                max = Math.Max(max, doBfs(i, bombs, rows));
            }

            return max;
        }

        private int doBfs(int curr, int[][] bombs, int rows)
        {
            Queue<int> q = new Queue<int>();
            var count = 1; // You can always detonate yourself.
            q.Enqueue(curr);

            bool[] visited = new bool[rows];

            while (q.Count > 0)
            {
                var current = q.Dequeue();

                visited[current] = true;

                var currBomb = bombs[current];
                var currBombX = currBomb[0];
                var currBombY = currBomb[1];
                var currBombR = currBomb[2];

                for (int i = 0; i < rows; i++)
                {
                    if (i == current || visited[i]) continue;

                    var neighbor = bombs[i];

                    long neighborX = neighbor[0];
                    long neighborY = neighbor[1];
                    long neighborR = neighbor[2];

                    long distanceX = currBombX - neighborX;
                    long distanceY = currBombY - neighborY;

                    UInt64 distance = (UInt64)(distanceX * distanceX + distanceY * distanceY);

                    if ((UInt64)(currBombR * currBombR) >= distance)
                    {
                        if (!q.Contains(i))
                        {
                            q.Enqueue(i);
                            count++;
                        }
                    }
                }
            }

            return count;
        }
    }
}
