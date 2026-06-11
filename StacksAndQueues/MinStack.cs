using System;
using System.Collections.Generic;

namespace DSA.StacksAndQueues
{
    public class MinStack
    {
        Stack<int> S;
        Stack<int> SS; //Supporting Stack

        public MinStack()
        {
            S = new Stack<int>();
            SS = new Stack<int>();

        }

        public void Push(int val)
        {
            S.Push(val);

            //Less than EQUAL to is very imp. Can have duplicates and we want to store them all
            //eg: 15 16 and again 15
            if (SS.Count == 0 || val <= SS.Peek())
            {
                SS.Push(val);
            }
        }

        public void Pop()
        {
            if (S.Count == 0) return; // Nothing to Pop from Main stack

            var top = S.Pop();

            if (SS.Peek() == top)
            {
                SS.Pop();
            }

            return;
        }

        public int Top()
        {
            return S.Peek();
        }

        //GetMin will go off of the supporting stack.
        public int GetMin()
        {
            //If no element, return -1
            if (SS.Count == 0) return -1;
            else return SS.Peek(); //else return top; But don't pop.
        }
    }
}

