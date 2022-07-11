using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class GraphQuestions
    {
        public GraphQuestions()
        {
            //public static Dictionary<int, List<int>> EdgeListToAdjacencyList(int[][] edgeList)
            //{
            //    var adjList = new Dictionary<int, List<int>>();

            //    var noOfRows = edgeList.GetLength(0);
            //    foreach (var item in edgeList)
            //    {
            //        var nodeA = item[0];
            //        var nodeB = item[1];

            //        if (!adjList.ContainsKey(nodeA)) adjList.Add(nodeA, new List<int>());

            //        if (!adjList.ContainsKey(nodeB)) adjList.Add(nodeB, new List<int>());

            //        adjList[nodeA].Add(nodeB);
            //        adjList[nodeB].Add(nodeA);
            //    }

            //    return adjList;
            //}

            //###### Convert GRID to Adjacency list

            //public static Dictionary<int, List<int>> GridToAdjacencyList(int[][] edgeList)
            //{
            //    var adjList = new Dictionary<int, List<int>>();

            //    var noOfRows = edgeList.GetLength(0);
            //    for (int i = 0; i < noOfRows; i++)
            //    {
            //        adjList.Add(i, new List<int>());
            //        for (int j = 0; j < edgeList[0].Length; j++)
            //        {
            //            if (i != j && edgeList[i][j] == 1) adjList[i].Add(j);

            //        }
            //    }


            //    return adjList;
            //}

            #region FindCelebrity Q277

            //public static int FindCelebrity(int n)
            //{

            //    int CelebrityContender = 0;
            //     TotalNumberOfPeople = n;

            //    for (int i = 0; i < n; i++)
            //    {
            //        if (i == CelebrityContender) continue;

            //        if (Knows(CelebrityContender, i))
            //        {
            //            CelebrityContender = i;
            //        }

            //    }
            //    if (ConfirmIfCelebrity(CelebrityContender)) return CelebrityContender;
            //    else return -1;
            //}

            //public static bool ConfirmIfCelebrity(int source)
            //{
            //    for (int i = 0; i < TotalNumberOfPeople; i++)
            //    {
            //        if (i == source) continue;
            //        if (!Knows(i, source) || Knows(source, i)) return false;
            //    }
            //    return true;
            //}

            //public static bool Knows(int a, int b)
            //{
            //    return true;
            //}
            #endregion

            #region Find Town Judge Q977
            //public static int FindJudge(int n, int[][] trust)
            //{
            //    var adjList = EdgeListToAdjacencyList(trust, n);

            //    int Contender = 1;
            //    for (int i = 1; i <= n; i++)
            //    {

            //        if (adjList[i].Count > 0)
            //        {

            //            continue;
            //        }

            //        Contender = i;

            //        if (IsTownJudge(Contender, adjList)) return i;
            //    }

            //    return -1;

            //}

            //public static bool IsTownJudge(int id, Dictionary<int, List<int>> adjList)
            //{
            //    for (int i = 1; i <= adjList.Count; i++)
            //    {
            //        if (id == i) continue;

            //        if (!adjList[i].Contains(id)) return false;
            //    }

            //    return true;
            //}
            #endregion

            #region CourseSchedule 2 Q210
            /// <summary>
            ///  Find Topological sort order IFF no cycle exists.
            /// </summary>
            /// <param name="numCourses"></param>
            /// <param name="prerequisites"></param>
            /// <returns></returns>

            // Driver Function (1)
            //public static int[] CanFinish(int numCourses, int[][] prerequisites)
            //{
            //    var adjList = EdgeListToAdjacencyList(prerequisites, numCourses);

            //    HashSet<int> visited = new HashSet<int>();
            //    HashSet<int> currDfsVisited = new HashSet<int>();
            //    Stack<int> topologicalSortStack = new Stack<int>();

            //    foreach (var item in adjList.Keys)
            //    {
            //        if (!visited.Contains(item))
            //        {
            //            if (CycleChecker(adjList, visited, currDfsVisited, item, topologicalSortStack)) return new int[] { };
            //        }

            //    }

            //    var topoList = TopologicalStackToInt(topologicalSortStack);
            //    return topoList;
            //}

            //// 4
            //public static int[] TopologicalStackToInt(Stack<int> topologicalSortStack)
            //{
            //    List<int> temp = new List<int>();
            //    while (topologicalSortStack.Count > 0)
            //    {
            //        temp.Add(topologicalSortStack.Pop());
            //    }
            //    return temp.ToArray();
            //}

            //// 3
            //public static bool CycleChecker(Dictionary<int, List<int>> adjList, HashSet<int> visited,
            //                                                    HashSet<int> currDfsVisited, int source, Stack<int> topologicalSortStack)
            //{
            //    visited.Add(source);
            //    currDfsVisited.Add(source);

            //    foreach (var neighbor in adjList[source])
            //    {
            //        if (!visited.Contains(neighbor))
            //        {
            //            if (CycleChecker(adjList, visited, currDfsVisited, neighbor, topologicalSortStack) == true) return true;
            //        }
            //        else if (currDfsVisited.Contains(neighbor))
            //        {
            //            return true;
            //        }

            //    }
            //    topologicalSortStack.Push(source);
            //    currDfsVisited.Remove(source);
            //    return false;
            //}

            //// 2
            //public static Dictionary<int, List<int>> EdgeListToAdjacencyList(int[][] grid, int numOfCourses)
            //{
            //    var adjList = new Dictionary<int, List<int>>();

            //    for (int i = 0; i < numOfCourses; i++)
            //    {
            //        adjList.Add(i, new List<int>());
            //    }

            //    foreach (var item in grid)
            //    {
            //        int Item1 = item[0];
            //        int Item2 = item[1];

            //        adjList[Item2].Add(Item1);
            //    }

            //    return adjList;
            //}
            #endregion
        }
    }
}
