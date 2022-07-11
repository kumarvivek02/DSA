using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    //LC 
    public class ShortestPathInHiddenGrid
    {
        public ShortestPathInHiddenGrid()
        {
        }
        /*
         -1 => Starting Cell
          0 => Blocked
          1 => Empty
          2 => Target
         */

        int[,] matrix = new int[1002, 1002]; // ini with 0
        // Direction[] to hold 4 possible movement directions
        char[] dirs = new char[4] { 'U', 'D', 'L', 'R' };

        // Dict. to go back to original direction cell
        Dictionary<char, char> dirMap = new Dictionary<char, char>()
        {
                {'U','D' },
                {'D','U' },
                {'L','R' },
                {'R','L' }
        };

        int[] dirX = new int[4] { 0, 0, -1, 1 };
        int[] dirY = new int[4] { -1, 1, 0, 0 };

        public int FindShortestPath(IGridMaster master)
        {


            // We use DFS to build the grid, ini. start point as 501,501
            CreateGridThroughDFS(master, 501, 501);

            matrix[501, 501] = -1;

            Queue<GridCell> q = new Queue<GridCell>();
            q.Enqueue(new GridCell(501, 501));

            int distance = 0;

            //It's possible this visited[] is not needed, but instead,
            // you can change the value inside matrix[] to 0 once you've queued the cell,
            // Will save some space.
            bool[,] visited = new bool[1002, 1002];
            visited[501, 501] = true;

            while (q.Count > 0)
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    var front = q.Dequeue();

                    // If cell value is 2, found target & return distance
                    if (matrix[front.x, front.y] == 2) return distance;

                    //Otherwise explore neighbors, Queue them if they've not been visited & are capable of being visited
                    for (int j = 0; j < 4; j++)
                    {
                        var neighborX = front.x + dirX[j];
                        var neighborY = front.y + dirY[j];

                        // < 1 => 0, so BLOCKED cell
                        if (matrix[neighborX, neighborY] < 1 || visited[neighborX, neighborY]) continue;

                        q.Enqueue(new GridCell(neighborX, neighborY));
                        visited[neighborX, neighborY] = true;
                    }

                }
                distance++;
            }

            // If by now distance hasnt been returned, it's probably because cell with value 2 was not found.
            // So return -1
            return -1;

        }

        private void CreateGridThroughDFS(IGridMaster master, int row, int col)
        {
            if (master.isTarget())
            {
                matrix[row, col] = 2;
            }
            else
            {
                matrix[row, col] = 1; // To suggest empty cell where you can move
            }

            // Explore all 4 neighbors
            for (int i = 0; i < 4; i++)
            {
                //If you cannot move to this cell, skip and goto next neighbor
                if (!master.canMove(dirs[i]))
                {
                    continue;
                }

                var neighborX = row + dirX[i];
                var neighborY = col + dirY[i];

                // !=0 would mean it's been visited before
                if (matrix[neighborX, neighborY] != 0) continue;

                master.move(dirs[i]);
                CreateGridThroughDFS(master, neighborX, neighborY);
                master.move(dirMap[dirs[i]]);
            }

        }
    }

    // This interface below is  just so you can call master in the param list without compilation errors
    public interface IGridMaster
    {
        bool canMove(char direction);
        void move(char direction);
        bool isTarget();
    };

    public class GridCell
    {
        public int x;
        public int y;
        public GridCell(int X, int Y)
        {
            x = X;
            y = Y;
        }
    }
}
