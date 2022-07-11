using System;
using System.Collections.Generic;

namespace AllAboutHeaps.Tree
{
    public class AllNodesDistKinBiinaryTree
    {
        public AllNodesDistKinBiinaryTree()
        {
        }


        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {

            // Step 1 -> create a map of parent pointers
            Dictionary<TreeNode, TreeNode> parentPointers = new Dictionary<TreeNode, TreeNode>();

            BuildParentPointers(root, parentPointers);

            // Dictionary to maintain status of Visited nodes
            Dictionary<TreeNode, bool> visited = new Dictionary<TreeNode, bool>();



            Queue<TreeNode> qt = new Queue<TreeNode>();
            qt.Enqueue(target);
            int currK = 0;

            while (qt.Count > 0)
            {


                if (currK == k) break;

                currK++;

                var size = qt.Count;
                for (int i = 0; i < size; i++)
                {
                    var front = qt.Dequeue();

                    //Left child
                    if (front.left != null && !visited.ContainsKey(front.left))
                    {
                        qt.Enqueue(front.left);
                        visited[front.left] = true;
                    }

                    //Right Child
                    if (front.right != null && !visited.ContainsKey(front.right))
                    {
                        qt.Enqueue(front.right);
                        visited[front.right] = true;
                    }

                    //Parent
                    if (parentPointers.ContainsKey(front) && !visited.ContainsKey(front))
                    {
                        qt.Enqueue(parentPointers[front]);
                        visited[front] = true;
                    }
                }
            }


            List<int> res = new List<int>();

            while (qt.Count > 0)
            {
                res.Add(qt.Dequeue().val);
            }

            return res;

        }

        private void BuildParentPointers(TreeNode root, Dictionary<TreeNode, TreeNode> parentPointers)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var top = q.Dequeue();

                // If left child exists, mark left child's parent as current node
                if (top.left != null)
                {
                    parentPointers.Add(top.left, top);
                    q.Enqueue(top.left);
                }

                if (top.right != null)
                {
                    parentPointers.Add(top.right, top);
                    q.Enqueue(top.right);
                }
            }
        }
    }
}
