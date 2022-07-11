using System;
namespace AllAboutHeaps.DynamicProgramming
{
    public class HouseRobber1
    {
        int[] t;
        public HouseRobber1()
        {
        }

        public int Rob(int[] nums)
        {
            t = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                t[i] = -1;
            }
            return Rob(nums, nums.Length - 1);

        }


        // Plain Recursive solution. will work for small ips but TLE for large
        private int Rob(int[] nums, int houseNo)
        {

            if (houseNo < 0) return 0;

            if (t[houseNo] != -1) return t[houseNo];
            // Either rob CUrrent house (so add it's loot & call curr-2)
            // OR don't rob current & call curr -1
            // Take MAX of these 2
            return t[houseNo] = Math.Max(Rob(nums, houseNo - 2) + nums[houseNo],
                            Rob(nums, houseNo - 1));
        }

        // Plain Recursive solution. will work for small ips but TLE for large
        //private int Rob(int[] nums, int houseNo)
        //{

        //    if (houseNo < 0) return 0;

        //    // Either rob CUrrent house (so add it's loot & call curr-2)
        //    // OR don't rob current & call curr -1
        //    // Take MAX of these 2
        //    return Math.Max(Rob(nums, houseNo - 2) + nums[houseNo],
        //                    Rob(nums, houseNo - 1));
        //}
    }
}
