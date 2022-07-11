using System;
namespace AllAboutHeaps.Tree
{
    public class MinimumDepthOfBinaryTree
    {
        public MinimumDepthOfBinaryTree()
        {
        }

        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;


            int left = MinDepth(root.left);
            int right = MinDepth(root.right);

            if (left == 0 && right == 0) return 1;

            else if (left != 0 && right != 0) return Math.Min(left, right) + 1;
            else
            {
                return right == 0 ? left + 1 : right + 1;
            }
        }
    }
}
