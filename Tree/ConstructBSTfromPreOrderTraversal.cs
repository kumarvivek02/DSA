using System;
namespace AllAboutHeaps.Tree
{
    public class ConstructBSTfromPreOrderTraversal
    {
        public ConstructBSTfromPreOrderTraversal()
        {
        }

        public TreeNode BstFromPreorder(int[] preorder)
        {
            int index = 0;
            return CalcBST(preorder, ref index, Int32.MaxValue);
        }

        private TreeNode CalcBST(int[] preorder, ref int i, int ub)
        {
            // Either no more elements in Array or Curr Ele is larger than UB, return null
            if (i == preorder.Length || preorder[i] > ub) return null;

            TreeNode root = new TreeNode(preorder[i]);
            i++;
            root.left = CalcBST(preorder, ref i, root.val);

            root.right = CalcBST(preorder, ref i, ub);

            return root;

        }
    }
}
