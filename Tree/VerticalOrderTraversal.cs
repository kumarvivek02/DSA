using System;
using System.Collections.Generic;
using System.Linq;
using AllAboutHeaps;

namespace DSA.Tree
{
    public class VerticalOrderTraversal
    {
        public VerticalOrderTraversal()
        {
        }

        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            SortedDictionary<int, List<int>> dict = new SortedDictionary<int, List<int>>();

            Queue<Tuple<int, TreeNode>> q = new Queue<Tuple<int, TreeNode>>();

            List<IList<int>> res = new List<IList<int>>();

            if (root == null) return res;

            int hd = 0; // Horizontal distance

            q.Enqueue(new Tuple<int, TreeNode>(hd, root));

            while (q.Count > 0)
            {
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {
                    var front = q.Dequeue();
                    if (!dict.ContainsKey(front.Item1)) dict.Add(front.Item1, new List<int>());

                    dict[front.Item1].Add(front.Item2.val);

                    if (front.Item2.left != null)
                    {
                        q.Enqueue(new Tuple<int, TreeNode>(front.Item1 - 1, front.Item2.left));
                    }
                    if (front.Item2.right != null)
                    {
                        q.Enqueue(new Tuple<int, TreeNode>(front.Item1 + 1, front.Item2.right));
                    }
                }
            }

            //var newDict = dict.OrderBy(x => x.Key);
            foreach (var key in dict.Keys)
            {
                var list = new List<int>();
                for (int i = 0; i < dict[key].Count; i++)
                {
                    list.Add(dict[key][i]);
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

