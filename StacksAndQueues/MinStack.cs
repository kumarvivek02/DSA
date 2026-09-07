using System;
using System.Collections.Generic;
using System.Drawing;

namespace DSA.StacksAndQueues
{
    //Solution using 2 stacks.
    // public class MinStack
    // {
    //     Stack<int> S;
    //     Stack<int> SS; //Supporting Stack

    //     public MinStack()
    //     {
    //         S = new Stack<int>();
    //         SS = new Stack<int>();
    //     }

    //     public void Push(int val)
    //     {
    //         S.Push(val);

    //         //Less than EQUAL to is very imp. Can have duplicates and we want to store them all
    //         //eg: 15 16 and again 15
    //         if (SS.Count == 0 || val <= SS.Peek())
    //         {
    //             SS.Push(val);
    //         }
    //     }

    //     public void Pop()
    //     {
    //         if (S.Count == 0)
    //             return; // Nothing to Pop from Main stack

    //         var top = S.Pop();

    //         if (SS.Peek() == top)
    //         {
    //             SS.Pop();
    //         }

    //         return;
    //     }

    //     public int Top()
    //     {
    //         return S.Peek();
    //     }

    //     //GetMin will go off of the supporting stack.
    //     public int GetMin()
    //     {
    //         //If no element, return -1
    //         if (SS.Count == 0)
    //             return -1;
    //         else
    //             return SS.Peek(); //else return top; But don't pop.
    //     }
    // }

    //Solution using 1 stack.
    public class MinStack
    {
        //Using Value Tuple instead of older generic Tuple
        Stack<(int value, int min)> st;

        public MinStack()
        {
            st = new Stack<(int value, int min)>();
        }

        public void Push(int value)
        {
            if (st.Count == 0)
            {
                st.Push((value, value));
            }
            else
            {
                st.Push((value, Math.Min(value, st.Peek().min)));
            }
        }

        public void Pop()
        {
            if (st.Count == 0)
                return;
            st.Pop();
        }

        public int Top()
        {
            return st.Peek().value;
        }

        public int GetMin()
        {
            return st.Peek().min;
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(value);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}
