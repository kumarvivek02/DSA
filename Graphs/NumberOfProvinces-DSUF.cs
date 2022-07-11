using System;
namespace AllAboutHeaps
{
    public class NumberOfProvinces_DSUF
    {
        public NumberOfProvinces_DSUF()
        {
        }
    }

    public class UnionFind
    {
        int[] rank;
        int[] root;
        int count;

        public UnionFind(int size)
        {
            rank = new int[size];
            root = new int[size];

            Array.Fill(rank, 1);
            for (int i = 0; i < size; i++)
            {
                root[i] = i;

            }
            count = size;
        }

        public int Find(int x)
        {
            if (x == root[x])
            {
                return x;
            }

            return root[x] = Find(root[x]);
        }

        public void Union(int x, int y)
        {
            int RootX = Find(x);
            int RootY = Find(y);

            if (RootX != RootY)
            {
                if (rank[RootX] > rank[RootY])
                {
                    root[RootY] = RootX;
                }
                else if (rank[RootX] < rank[RootY])
                {
                    root[RootX] = RootY;
                }
                else
                {
                    root[RootY] = RootX;
                    rank[RootX] += 1;
                }
                count--;
            }
        }

        public int GetCount()
        {
            return count;
        }

        public bool IsConnected(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }
}
