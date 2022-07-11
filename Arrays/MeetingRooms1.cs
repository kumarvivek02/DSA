using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AllAboutHeaps.Arrays
{
    public class MeetingRooms1
    {
        public MeetingRooms1()
        {
        }

        public bool CanAttendMeetings(int[][] intervals)
        {
            var sortedByStartTime = intervals.OrderBy(x => x[0]).ToArray();

            var rows = intervals.GetLength(0);

            for (int i = 0; i < rows - 1; i++)
            {
                if (sortedByStartTime[i][1] > sortedByStartTime[i + 1][0])
                {
                    return false;
                }
            }

            return true;
        }




    }

    public class Custom : IComparer<int[]>
    {
        public int Compare(int[]? x, int[]? y)
        {
            throw new NotImplementedException();
        }
    }
}
