using System;
using System.Collections.Generic;

namespace AllAboutHeaps.Tree
{
    public class BinaryTreeFromPostOrderAndInOrder
    {
        public BinaryTreeFromPostOrderAndInOrder()
        {
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder.Length != postorder.Length) return null;

            //Build hashmap for Root element lookup in InOrder array
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < postorder.Length; i++)
            {
                dict.Add(inorder[i], i);

            }

            return BuildBinaryTree(postorder, 0, postorder.Length - 1,
                                        inorder, 0, inorder.Length - 1, dict);
        }

        public TreeNode BuildBinaryTree(int[] postorder, int postStart, int postEnd,
                                                int[] inorder, int inStart, int inEnd, Dictionary<int, int> dict)
        {

            if (postStart > postEnd || inStart > inEnd) return null;


            TreeNode root = new TreeNode(postorder[postEnd]);

            var inRoot = dict[root.val]; // index of root in InOrder array

            var leftItems = inRoot - inStart;

            root.left = BuildBinaryTree(postorder, postStart, postStart + leftItems - 1,
                                        inorder, inStart, inRoot - 1, dict);

            root.right = BuildBinaryTree(postorder, postStart + leftItems, postEnd - 1,
                                            inorder, inRoot + 1, inEnd, dict);

            return root;

        }
    }
}
