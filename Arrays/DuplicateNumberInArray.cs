using System;
namespace AllAboutHeaps.Arrays
{
    public class DuplicateNumberInArray
    {
        public DuplicateNumberInArray()
        {
        }

        public int FindDuplicate(int[] nums)
        {
            while (nums[0] != nums[nums[0]])
            {
                int nxt = nums[nums[0]];
                nums[nums[0]] = nums[0];
                nums[0] = nxt;
            }
            return nums[0];
        }
    }
}
