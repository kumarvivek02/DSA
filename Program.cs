using System;
using System.Collections.Generic;
using AllAboutHeaps.Arrays;
using AllAboutHeaps.BinarySearch;
using AllAboutHeaps.HashSet;
using AllAboutHeaps.Maths;
using DSA.Arrays;
using DSA.StacksAndQueues;
using DSA.Strings;
using DSA.Tree;

namespace AllAboutHeaps
{
    public class Program
    {
        public static int count = 0;

        static void Main(string[] args)
        {
           LongestConsecutiveSequence longestConsecutiveSequence = new LongestConsecutiveSequence();
            var ans = longestConsecutiveSequence.LongestConsecutive(new int[] { 100,4,200,1,3,2 });
            Console.WriteLine($"Answer is {ans}");
            Console.ReadLine();
        }

        public static int[] PrefixSumSubArraySum(int[] arr, int target)
        {
            int sum = 0;
            // Dict to hold CurrSum at every index as Key, and index as Value
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                var complement = sum - target;

                if (dict.ContainsKey(complement))
                {
                    // +1 because of formula explained above
                    return new int[] { dict[complement] + 1, i };
                }
            }

            return null;

        }

    }

    public class ArrayComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x[0] > y[0])
            {
                return -1;
            }
            else if (x[0] < y[0])
            {
                return 1;
            }
            return 0;
        }
    }


    public class Node
    {

        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }

    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int Val = 0, TreeNode left = null, TreeNode right = null)
        {
            val = Val;
            this.left = left;
            this.right = right;
        }
    }
}

