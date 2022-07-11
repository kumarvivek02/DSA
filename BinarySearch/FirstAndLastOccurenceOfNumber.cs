using System;
namespace AllAboutHeaps.BinarySearch
{
    public class FirstAndLastOccurenceOfNumber
    {
        public FirstAndLastOccurenceOfNumber()
        {
        }

        public int[] SearchRange(int[] nums, int target)
        {

            int rightOccurence = -1;
            var leftOccurence = firstLeftOccurence(nums, target);
            if (leftOccurence != -1)
            {
                rightOccurence = firstRightOccurence(nums, target);
            }

            return new int[] { leftOccurence, rightOccurence };
        }

        public int firstLeftOccurence(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;

            int res = -1;

            while (start <= end)
            {
                var mid = start + (end - start) / 2;

                if (target == nums[mid])
                {
                    res = mid;
                    end = mid - 1;
                }
                else if (target > nums[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return res;
        }

        public int firstRightOccurence(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;

            int res = -1;

            while (start <= end)
            {
                var mid = start + (end - start) / 2;

                if (target == nums[mid])
                {
                    res = mid;
                    start = mid + 1;
                }
                else if (target > nums[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return res;
        }
    }
}
