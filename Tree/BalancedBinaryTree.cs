using System;
namespace AllAboutHeaps.Tree
{
    public class BalancedBinaryTree
    {
        public BalancedBinaryTree()
        {
        }

        public bool IsBalanced(TreeNode root)
        {

            return CheckForBalanced(root) != -1;
        }

        public int CheckForBalanced(TreeNode root)
        {
            if (root == null) return 0;

            var left = CheckForBalanced(root.left);

            if (left == -1) return -1;

            var right = CheckForBalanced(root.right);

            if (right == -1) return -1;

            if (Math.Abs(left - right) > 1) return -1;

            return Math.Max(left, right) + 1;


        }


    }
}
