using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class CheapestFlightWithKStops
    {
        //int[][] preReq =
        //   {
        //       new int[]{0,1,100},
        //       new int[]{1,2,100},
        //       new int[]{ 0, 2, 500 }

        //    };

        //int n = 3;

        //int src = 0;
        //int dst = 2;
        //int k = 0;
        //CheapestFlightWithKStops cheapestFlightWithKStops = new CheapestFlightWithKStops();
        //var res = cheapestFlightWithKStops.FindCheapestPrice(n, preReq, src, dst, k);

        public CheapestFlightWithKStops()
        {

        }

        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            var adjList = new Dictionary<int, List<Tuple<int, int>>>();
            BuildAdjacencyList(n, flights, adjList);
            //<dstCity, Cost, K>
            PriorityQueue<Tuple<int, int, int>, int> pq = new PriorityQueue<Tuple<int, int, int>, int>();

            int[] totCities = new int[n];
            for (int i = 0; i < n; i++)
            {
                totCities[i] = Int32.MaxValue;
            }

            pq.Enqueue(new Tuple<int, int, int>(src, 0, 0), 0);

            while (pq.Count > 0)
            {

                var temp = pq.Dequeue();
                var u = temp.Item1;
                var currC = temp.Item2;
                var currK = temp.Item3;

                if (u == dst) return currC;

                if (currK > k || totCities[u] < currK) continue;


                Console.WriteLine(temp);
                foreach (var neighbor in adjList[u])
                {
                    var v = neighbor.Item1;
                    var c = neighbor.Item2;

                    pq.Enqueue(new Tuple<int, int, int>(v, c + currC, currK + 1), c + currC);
                }

            }
            return -1;
        }

        public void BuildAdjacencyList(int n, int[][] flights, Dictionary<int, List<Tuple<int, int>>> adjList)
        {
            for (int i = 0; i < n; i++)
            {
                adjList.Add(i, new List<Tuple<int, int>>());
            }

            foreach (var flight in flights)
            {
                var u = flight[0];
                var v = flight[1];
                var c = flight[2];

                adjList[u].Add(new Tuple<int, int>(v, c));
            }

        }




    }

    public class CustomComparerForFlights : IComparer<int>
    {


        // Sort in ASCENDING Order
        public int Compare(int x, int y)
        {
            if (x == y)
            {
                return 0;
            }
            else if (x > y)
            {
                return 1;
            }
            else return -1;

        }
        //public int Compare(Tuple<int, int> x, Tuple<int, int> y)
        //{
        //    if (x.Item2 == y.Item2)
        //    {
        //        return 0;
        //    }
        //    else if (x.Item2 > y.Item2)
        //    {
        //        return 1;
        //    }
        //    else return -1;

        //}
    }
}
