using System;
namespace AllAboutHeaps.Tree
{
    public class FindLCAinBST
    {
        public FindLCAinBST()
        {
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var rootVal = root.val;

            var pVal = p.val;
            var qVal = q.val;

            if (pVal < rootVal && qVal < rootVal)
            {
                return LowestCommonAncestor(root.left, p, q);
            }
            else if (pVal > rootVal && qVal > rootVal)
            {
                return LowestCommonAncestor(root.right, p, q);
            }

            return root;
        }
    }
}
