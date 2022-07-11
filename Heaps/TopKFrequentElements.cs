using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class TopKFrequentElements
    {
        public TopKFrequentElements()
        {
        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            var listOfNums = new List<int>();

            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>(new CustomComparer());

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            for (int i = 0; i < 9; i++)
            {
                pq.Enqueue(i, i);
            }

            var top = pq.Dequeue();

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!keyValuePairs.ContainsKey(nums[i]))
                {
                    keyValuePairs.Add(nums[i], 1);
                }
                else
                {
                    keyValuePairs[nums[i]]++;
                }
            }

            foreach (var key in keyValuePairs.Keys)
            {
                priorityQueue.Enqueue(key, keyValuePairs[key]);

                if (priorityQueue.Count > k)
                {
                    priorityQueue.Dequeue();
                }
            }

            while (priorityQueue.Count > 0)
            {
                listOfNums.Add(priorityQueue.Dequeue());
            }

            return listOfNums.ToArray();

        }



    }


}
