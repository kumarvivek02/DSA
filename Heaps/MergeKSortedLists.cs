using System;
using System.Collections.Generic;

namespace AllAboutHeaps.Heaps
{
    public class MergeKSortedLists
    {
        public MergeKSortedLists()
        {
        }

        /* 
         * Test Data
         
            ListNode node1 = new ListNode(1);
            node1.next = new ListNode(2);
            node1.next.next = new ListNode(4);

            ListNode node2 = new ListNode(3);
            node2.next = new ListNode(4);
            node2.next.next = new ListNode(5);

            ListNode node3 = new ListNode(2);
            node3.next = new ListNode(3);
            node3.next.next = new ListNode(6);

            MergeKSortedLists mergeKSortedLists = new MergeKSortedLists();
            var res1 = mergeKSortedLists.MergeKLists(new ListNode[] { node1, node2, node3 });

         
         */

        public ListNode MergeKLists(ListNode[] lists)
        {
            //res & head are 2 references to the same Resultant Node
            ListNode res = new ListNode();
            ListNode head = res;

            //PQ will sort based on val of ListNode. In Asc order y default
            PriorityQueue<ListNode, int> pq = new PriorityQueue<ListNode, int>();

            //Put the 1st element from each linked list into the PQ
            foreach (var node in lists)
            {
                if (node != null)
                    pq.Enqueue(node, node.val);
            }

            //
            while (pq.Count > 0)
            {
                var front = pq.Dequeue();
                res.next = front;
                res = res.next;
                if (front.next != null)
                {
                    pq.Enqueue(front.next, front.next.val);
                }
            }

            return head.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }


}

