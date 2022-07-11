using System;
using System.Collections.Generic;

namespace AllAboutHeaps.Tree
{
    public class SerializeDeserialiseBinaryTree
    {
        public SerializeDeserialiseBinaryTree()
        {
        }

        public string serialize(TreeNode root)
        {
            if (root == null) return "";

            string res = "";

            return DfsSerialization(root, res);
        }

        private string DfsSerialization(TreeNode root, string res)
        {
            if (root == null)
            {
                res += "None,";
                return res;

            }

            res += root.val + ",";

            res = DfsSerialization(root.left, res);

            res = DfsSerialization(root.right, res);

            return res;

        }



        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == null) return null;

            string[] subs = data.Split(',');

            List<string> list = new List<string>(subs);

            return DfsDeserialization(list);
        }

        private TreeNode DfsDeserialization(List<string> list)
        {
            if (list[0] == "None")
            {

                list.RemoveAt(0);
                return null;

            }


            TreeNode root = new TreeNode(Int32.Parse(list[0]));
            list.RemoveAt(0);
            root.left = DfsDeserialization(list);

            root.right = DfsDeserialization(list);

            return root;
        }
    }
}
