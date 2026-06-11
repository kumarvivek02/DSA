using System;
using System.Collections.Generic;
using System.Linq;
using AllAboutHeaps;

namespace DSA.Tree
{
    public class VerticalOrderTraversalSorted
    {
        public VerticalOrderTraversalSorted()
        {

        }

        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            var res = new List<IList<int>>();
            var maps = new SortedDictionary<int, SortedDictionary<int, PriorityQueue<int, int>>>();
            //hd, vd, Val
            var q = new Queue<Tuple<int, int, TreeNode>>();

            q.Enqueue(new Tuple<int, int, TreeNode>(0, 0, root));

            while (q.Count > 0)
            {
                var front = q.Dequeue();
                var hd = front.Item1;
                var vd = front.Item2;
                var node = front.Item3;

                if (!maps.ContainsKey(hd))
                {
                    maps.Add(hd, new SortedDictionary<int, PriorityQueue<int, int>>());
                }
                if (!maps[hd].ContainsKey(vd))
                {
                    maps[hd].Add(vd, new PriorityQueue<int, int>());
                }

                var dict = maps[hd];
                dict[vd].Enqueue(node.val, node.val);

                if (node.left != null)
                {
                    q.Enqueue(new Tuple<int, int, TreeNode>(hd - 1, vd + 1, node.left));
                }
                if (node.right != null)
                {
                    q.Enqueue(new Tuple<int, int, TreeNode>(hd + 1, vd + 1, node.right));
                }
            }

            foreach (var key in maps.Keys)
            {
                var tempDict = maps[key];
                // res.Add(new List<int>());

                var list = new List<int>();
                foreach (var key1 in tempDict.Keys)
                {
                    var pq = tempDict[key1];

                    while (pq.Count > 0)
                    {
                        list.Add(pq.Dequeue());
                    }

                    //  list.AddRange(temp2.Select(x => x.Key));
                }

                res.Add(new List<int>(list));
            }

            return res;

        }
    }

    //public class TreeNode
    //{
    //    public int val;
    //    public TreeNode left;
    //    public TreeNode right;
    //    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    //    {
    //        this.val = val;
    //        this.left = left;
    //        this.right = right;
    //    }
    //}
}

