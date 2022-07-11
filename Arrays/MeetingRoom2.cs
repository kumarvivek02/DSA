using System;
using System.Collections.Generic;
using System.Linq;

namespace AllAboutHeaps.Arrays
{
    public class MeetingRoom2
    {
        public MeetingRoom2()
        {
        }

        public int MinMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 0) return 0;

            var intervalsSorted = intervals.OrderBy(x => x[0]).ToArray();

            int rows = intervals.GetLength(0);

            var pq = new PriorityQueue<int, int>();

            pq.Enqueue(intervalsSorted[0][1], intervalsSorted[0][1]);
            for (int i = 1; i < rows; i++)
            {
                var meeting = intervalsSorted[i];

                var top = pq.Peek();

                if (meeting[0] >= top)
                {
                    pq.Dequeue();

                }

                pq.Enqueue(meeting[1], meeting[1]);
            }

            return pq.Count;

        }
    }
}
