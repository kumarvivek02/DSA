using System;
using System.Collections.Generic;
using System.Linq;

namespace AllAboutHeaps.Tree
{
    public class BFS_NextPointer_LevelOrder
    {
        public BFS_NextPointer_LevelOrder()
        {
        }

        //Node root = new Node(1);
        //root.children.Add(new Node(3));
        //    root.children.Add(new Node(2));
        //    root.children.Add(new Node(4));
        //    root.children[0].children.Add(new Node(5));
        //    root.children[0].children.Add(new Node(6));

        public static IList<IList<int>> LevelOrder(Node root)
        {

            Queue<Node> q = new Queue<Node>();
            List<IList<int>> res = new List<IList<int>>();

            if (root != null)
            {

                //q.Enqueue(root);

                //while (q.Count > 0)
                //{
                //    int size = q.Count();

                //    var levelList = new List<int>();

                //    for (int i = 0; i < size; i++)
                //    {

                //        var front = q.Dequeue();
                //        levelList.Add(front.val);
                //        for (int j = 0; j < front.children.Count; j++)
                //        {
                //            q.Enqueue(front.children[j]);
                //        }


                //    }
                //    res.Add(levelList);
                //}
            }
            return res;
        }
    }

    //public class Node
    //{
    //    public int val;
    //    public IList<Node> children = new List<Node>();

    //    public Node() { }

    //    public Node(int _val)
    //    {
    //        val = _val;
    //    }

    //    public Node(int _val, IList<Node> _children)
    //    {
    //        val = _val;
    //        children = _children;
    //    }

    //}

}
