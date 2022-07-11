using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class NetworkDelayTime
    {
        public NetworkDelayTime()
        {
        }

        public int NetworkDelayTimeMethod(int[][] times, int n, int k)
        {

            //Build Adjacency List
            Dictionary<int, List<Tuple<int, int>>> adjList = new Dictionary<int, List<Tuple<int, int>>>();

            BuildAdjacencyList(times, n, adjList);

            //ShortestTime array
            int[] shortestTime = new int[n + 1];
            Array.Fill(shortestTime, Int32.MaxValue);


            //PriorityQueue
            PriorityQueue<Tuple<int, int>, int> pq = new PriorityQueue<Tuple<int, int>, int>();

            pq.Enqueue(new Tuple<int, int>(k, 0), 0);

            shortestTime[k] = 0;

            while (pq.Count > 0)
            {
                var node = pq.Dequeue();

                var currTime = node.Item2;
                var currNode = node.Item1;

                if (currTime > shortestTime[currNode]) continue;

                foreach (var item in adjList[currNode])
                {
                    var v = item.Item1;
                    var w = item.Item2;

                    if ((currTime + w) < shortestTime[v])
                    {
                        shortestTime[v] = currTime + w;
                        pq.Enqueue(new Tuple<int, int>(v, shortestTime[v]), shortestTime[v]);
                    }
                }
            }

            var largest = 0;
            for (int i = 1; i <= n; i++)
            {
                if (shortestTime[i] == Int32.MaxValue) return -1;
                else
                {
                    largest = Math.Max(largest, shortestTime[i]);
                }
            }

            return largest;

        }

        public void BuildAdjacencyList(int[][] times, int n, Dictionary<int, List<Tuple<int, int>>> adjList)
        {


            for (int i = 1; i <= n; i++)
            {
                adjList.Add(i, new List<Tuple<int, int>>());
            }

            foreach (var neighbor in times)
            {
                var u = neighbor[0]; //Source
                var v = neighbor[1]; //Destination
                var w = neighbor[2]; //Time taken

                adjList[u].Add(new Tuple<int, int>(v, w));

            }
        }
    }
}
