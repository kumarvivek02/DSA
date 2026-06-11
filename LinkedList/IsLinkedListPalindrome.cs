using System;
using AllAboutHeaps.LinkedList;

namespace DSA.LinkedList
{
    public class IsLinkedListPalindrome
    {
        public IsLinkedListPalindrome()
        {
        }

        public bool IsPalindrome(ListNode head)
        {
            ListNode middle = FindMiddle(head);

            ListNode newHead = ReverseSecondHalf(middle);

            while (newHead != null)
            {
                if (head.val != newHead.val)
                {
                    return false;
                }
                head = head.next;
                newHead = newHead.next;
            }
            return true;
        }

        private ListNode FindMiddle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            return slow;
        }

        private ListNode ReverseSecondHalf(ListNode head)
        {
            ListNode curr = head;
            ListNode next = head;

            ListNode prev = null;

            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }
    }
}

