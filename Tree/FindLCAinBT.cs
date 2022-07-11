using System;
namespace AllAboutHeaps.Tree
{
    public class FindLCAinBT
    {
        public FindLCAinBT()
        {
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root.val == p.val || root.val == q.val)
            {
                return root;
            }

            TreeNode left = null; TreeNode right = null;
            if (root.left != null)
            {
                left = LowestCommonAncestor(root.left, p, q);
            }

            if (root.right != null)
            {
                right = LowestCommonAncestor(root.right, p, q);
            }

            if (left != null && right != null)
            {
                return root;
            }
            else
            {
                return left == null ? right : left;
            }
        }
    }
}
