using System;
namespace DSA.StacksAndQueues
{
    public class MyCircularQueue
    {

        int front, rear;
        int size;
        int[] arr;

        public MyCircularQueue(int k)
        {

            front = -1;
            rear = -1;
            size = k;

            arr = new int[k];
        }

        public bool EnQueue(int value)
        {
            //Check if array is full
            if (IsFull()) return false;

            //Special consideration when Enqueing 1st element
            if (front == -1) front = 0;
            rear = (rear + 1) % size;
            arr[rear] = value;

            return true;
        }

        public bool DeQueue()
        {
            if (IsEmpty()) return false;

            var result = arr[front];
            if (front == rear) front = rear = -1;
            else front = (front + 1) % size;

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
            return front == -1;
        }

        public bool IsFull()
        {
            return ((rear + 1) % size) == front;
        }
    }
}

