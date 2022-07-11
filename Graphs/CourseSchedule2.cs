using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class CourseSchedule2
    {
        /// <summary>
        /// Done with Topo sort with DFS
        /// </summary>
        public CourseSchedule2()
        {
            // TEST DATA.
            /*
            int[][] preReq =
            {
               new int[]{1,0},
               new int[]{2,0},
               new int[]{3,1 },
               new int[]{3,2 },

            };
            */

        }

        // Needs to be revisited. a -> b means do a first before b. inverse of that is implemented here hence the extra Reverse at end.
        public int[] CourseOrdering(int numCourses, int[][] prerequisites)
        {
            bool[] visited = new bool[numCourses];
            bool[] dfsVisited = new bool[numCourses];
            Stack<int> finalList = new Stack<int>();

            //Edge list to Adj list.
            var adjList = ConvertEdgeListToAdjacencyList(prerequisites, numCourses);

            var courseOrdering = new List<int>(numCourses);

            for (int i = 0; i < numCourses; i++)
            {
                if (!visited[i])
                {
                    if (dfsShowsCycle(i, visited, dfsVisited, adjList, finalList))
                        return new int[] { };

                }
            }

            while (finalList.Count > 0)
            {
                var temp = finalList.Pop();

                courseOrdering.Add(temp);

            }
            courseOrdering.Reverse();
            return courseOrdering.ToArray();
        }

        public bool dfsShowsCycle(int curr, bool[] visited, bool[] dfsvisited, Dictionary<int, List<int>> adjList, Stack<int> finalList)
        {
            visited[curr] = true;
            dfsvisited[curr] = true;


            foreach (var depCourse in adjList[curr])
            {
                if (visited[depCourse] == false)
                {
                    if (dfsShowsCycle(depCourse, visited, dfsvisited, adjList, finalList) == true) return true;
                }
                else if (dfsvisited[depCourse]) return true;
            }


            dfsvisited[curr] = false;
            finalList.Push(curr);
            return false;

        }

        public Dictionary<int, List<int>> ConvertEdgeListToAdjacencyList(int[][] edgeList, int totNumber)
        {
            var res = new Dictionary<int, List<int>>();

            for (int i = 0; i < totNumber; i++)
            {
                res.Add(i, new List<int>());
            }

            foreach (var item in edgeList)
            {
                var a = item[0];
                var b = item[1];

                res[a].Add(b);
            }

            return res;
        }


    }
}
