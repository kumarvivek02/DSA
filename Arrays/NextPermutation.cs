using System;
namespace AllAboutHeaps.Arrays
{
    public class NextPermutation
    {
        public NextPermutation()
        {
        }

        public void NextPermutationMethod(int[] nums)
        {
            // Start from 2nd last element
            int i = nums.Length - 2;

            while (i >= 0 && nums[i] >= nums[i + 1]) // nums[i] >= nums[i +1] means numbers are in descending order. 
            {
                i--; // i will hold 1st index where number is smaller than right neighbor
            }

            int j = nums.Length - 1;
            //Start from last element, moving left, find 1st instance where nums[j] > nums[i]
            if (i >= 0)
            {
                while (nums[j] <= nums[i])
                {
                    j--;
                }
                Swap(nums, i, j);
            }


            Reverse(nums, i + 1);
        }

        private void Reverse(int[] nums, int i)
        {
            int j = nums.Length - 1;
            while (i < j)
            {
                Swap(nums, i, j);
                i++;
                j--;

            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[j];

            nums[j] = nums[i];
            nums[i] = temp;
        }
    }
}

