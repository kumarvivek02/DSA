using System;
namespace AllAboutHeaps.Tree
{
    public class BinaryTreeMaxPathSum
    {
        int maxSum = Int32.MinValue;

        public BinaryTreeMaxPathSum()
        {
        }
        public int MaxPathSum(TreeNode root)
        {
            CalcMaxPathSumRecursion(root);

            return maxSum;
        }


        private int CalcMaxPathSumRecursion(TreeNode root)
        {
            if (root == null) return 0;

            int leftSum = CalcMaxPathSumRecursion(root.left);

            int rightSum = CalcMaxPathSumRecursion(root.right);

            //What value should the Node pass UP, Remember left / right could be -ve, so compare with Node val.
            var temp = Math.Max(Math.Max(leftSum, rightSum) + root.val,
                                root.val);

            //If MaxSum passes through this Node, compute it & comp. with Temp. 
            var ans = Math.Max(temp, leftSum + rightSum + root.val);

            // Update global Max if applicable
            maxSum = Math.Max(maxSum, ans);

            return temp;
        }
    }
}
