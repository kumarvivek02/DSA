using System;
using System.Collections.Generic;

namespace AllAboutHeaps.Tree
{
    public class ZigZagTraversalBinaryTree
    {
        public ZigZagTraversalBinaryTree()
        {
        }
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {

            var res = new List<IList<int>>();
            if (root == null) return res;

            var list = new List<int>();

            bool leftToRight = true;

            Queue<TreeNode> q = new Queue<TreeNode>();

            q.Enqueue(root);
            q.Enqueue(null);

            while (q.Count > 0)
            {
                var front = q.Dequeue();

                if (front != null)
                {

                    if (leftToRight)
                    {
                        list.Add(front.val);
                    }
                    else
                    {
                        list.Insert(0, front.val);
                    }

                    if (front.left != null) q.Enqueue(front.left);
                    if (front.right != null) q.Enqueue(front.right);
                }
                else // null indicates end of level.
                {
                    res.Add(new List<int>(list));
                    list = new List<int>();

                    // If this is not the last level, add null to signify end of the next level in Q
                    if (q.Count > 0)
                    {
                        q.Enqueue(null);

                    }

                    leftToRight = !leftToRight;
                }
            }

            return res;
        }
    }
}
