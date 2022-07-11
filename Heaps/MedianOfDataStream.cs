using System;
using System.Collections.Generic;
namespace AllAboutHeaps.Heaps
{
    public class MedianOfDataStream
    {
        PriorityQueue<int, int> maxHeap;
        PriorityQueue<int, int> minHeap;
        public MedianOfDataStream()
        {
            maxHeap = new PriorityQueue<int, int>(new MaxHeapComparer());
            minHeap = new PriorityQueue<int, int>();
        }

        public void AddNum(int num)
        {
            // STEP 1 --> Insert the Data
            //For odd len array, Max heap should have exactly 1 more numbe than min heap
            //Any more, then move 
            if (maxHeap.Count == 0 || maxHeap.Peek() >= num)
            {
                maxHeap.Enqueue(num, num);
            }
            else
            {
                minHeap.Enqueue(num, num);
            }


            //Step 2 --> Balance the data, if needed
            //In case we need to re shuffle/ mvoe numbers from 1 PQ to another
            // 3 cases possible, maxHeap == minHeap (do nothing
            // maxHeap - minHeap > 1 --> move 1 element from max to min
            // maxHeap < minHeap  --> move 1 element from min to max
            if (maxHeap.Count > minHeap.Count + 1)
            {
                var element = maxHeap.Dequeue();
                minHeap.Enqueue(element, element);
            }
            else if (maxHeap.Count < minHeap.Count)
            {
                var element = minHeap.Dequeue();
                maxHeap.Enqueue(element, element);
            }



        }

        public double FindMedian()
        {
            // ODD number of total elements
            if ((maxHeap.Count + minHeap.Count) % 2 != 0)
            {
                return maxHeap.Peek();
            }
            else
            {
                return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
            }
        }
    }

    public class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y) return -1;
            else if (x < y) return 1;
            return 0;
        }
    }
}

