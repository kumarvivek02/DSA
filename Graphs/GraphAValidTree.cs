using System;
namespace AllAboutHeaps
{
    public class GraphAValidTree
    {
        public GraphAValidTree()
        {
        }
    }
    /*
     
     public static bool ValidTree(int n, int[][] edges)
        {
            // If more or less than (n-1) edges, then can't be tree
            if (edges.Length != (n - 1)) return false;

            DSUF dSUF = new DSUF(n);

            foreach (var edge in edges)
            {
                var x = edge[0];

                var y = edge[1];

                if (!dSUF.Union(x, y)) return false;
            }

            return true;

        }
     */

    public class DSUF
    {
        int[] rank;
        int[] root;

        public DSUF(int size)
        {

            root = new int[size];
            rank = new int[size];

            Array.Fill(rank, 1);
            for (int i = 0; i < size; i++)
            {
                root[i] = i;
            }
        }

        public int Find(int x)
        {
            if (x == root[x])
            {
                return x;
            }

            return root[x] = Find(root[x]);
        }

        public bool Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            // If roots are equal, can't perform Union coz it'll create a cycle. Trees cant have cycles.
            if (rootX == rootY) return false;

            if (rank[rootX] > rank[rootY])
            {
                root[rootY] = rootX;

            }
            else if (rank[rootX] < rank[rootY])
            {
                root[rootX] = rootY;
            }
            else
            {
                root[rootY] = rootX;
                rank[rootX] += 1;
            }

            return true;
        }
    }
}
