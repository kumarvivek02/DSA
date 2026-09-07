using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AllAboutHeaps.Arrays
{
    public class MeetingRooms1
    {
        public MeetingRooms1() { }

        // ---- Version 1: Array.Sort with an inline lambda (default choice in interviews) ----
        public bool CanAttendMeetings(int[][] intervals)
        {
            // Sort by start time, in place.
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            var rows = intervals.GetLength(0);

            // Once sorted by start, an overlap can only be between neighbours.
            for (int i = 0; i < rows - 1; i++)
            {
                if (intervals[i][1] > intervals[i + 1][0]) // strict >: [1,5] and [5,10] do NOT overlap
                {
                    return false;
                }
            }

            return true;
        }

        // ---- Version 2: identical, but the ordering lives in the Custom comparer class ----
        // Only the sort line changes; everything below it is the same.
        public bool CanAttendMeetings2(int[][] intervals)
        {
            // Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));   // version 1's lambda
            Array.Sort(intervals, new Custom()); // same ordering, as IComparer<int[]>

            var rows = intervals.GetLength(0);

            for (int i = 0; i < rows - 1; i++)
            {
                if (intervals[i][1] > intervals[i + 1][0])
                {
                    return false;
                }
            }

            return true;
        }
    }

    // Same ordering as the Array.Sort lambda, as a reusable class.
    // Use when an API demands IComparer<T> (SortedSet, PriorityQueue, BinarySearch),
    // or when the same ordering is needed in several places.
    //  eg: Array.Sort(intervals, new Custom());
    public class Custom : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            return x[0].CompareTo(y[0]);

            // descending: return y[0].CompareTo(x[0]);
        }
    }

    
}
