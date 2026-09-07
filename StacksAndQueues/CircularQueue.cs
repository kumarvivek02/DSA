using System;

namespace DSA.StacksAndQueues
{
    public class MyCircularQueue
    {
        int front, rear;
        int capacity;
        int currSize;
        int[] arr;

        public MyCircularQueue(int k)
        {
            front = 0; // think of after 1 insert, if we pop, -1 as ini value will give exception for front
            rear = -1;
            capacity = k;
            currSize = 0;

            arr = new int[k];
        }

        public bool EnQueue(int value)
        {
            //Check if array is full
            if (IsFull())
                return false;

            rear = (rear + 1) % capacity;
            arr[rear] = value;
            currSize++;
            return true;
        }

        public bool DeQueue()
        {
            if (IsEmpty())
                return false;

            front = (front + 1) % capacity;
            currSize--;

            return true;
        }

        public int Front()
        {
            return IsEmpty() ? -1 : arr[front];
        }

        public int Rear()
        {
            return IsEmpty() ? -1 : arr[rear];
        }

        public bool IsEmpty()
        {
            return currSize == 0;
        }

        public bool IsFull()
        {
            return currSize == capacity;
        }
    }
}
