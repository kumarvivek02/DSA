using System;
namespace AllAboutHeaps.Arrays
{
    public class MoveZerosToEnd
    {
        public MoveZerosToEnd()
        {
        }
        //eg ip => nums = [0,1,0,3,12]
        // op => [1,3,12,0,0]
        public void MoveZeroes(int[] nums)
        {
            // ini slow and fast pointer with 0
            // slow will always point to 1st available 0
            // fast will always point to 1st NON 0 number
            int slow = 0;
            for (int fast = 0; fast < nums.Length; fast++)
            {
                if (nums[fast] != 0)
                {
                    //Do Swap
                    var temp = nums[slow];
                    nums[slow] = nums[fast];
                    nums[fast] = temp;
                    slow++;
                }
            }

        }
    }
}

