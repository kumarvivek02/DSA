using System;
namespace AllAboutHeaps.BinarySearch
{
    public class MinimumInRotatedSortedArray
    {
        public MinimumInRotatedSortedArray()
        {
        }

        public int FindMin(int[] nums)
        {

            //Binary search
            var start = 0;
            var N = nums.Length;
            var end = nums.Length - 1;

            if (start == end) return nums[start]; //Single element

            if (nums[start] <= nums[end]) return nums[start]; //Already sorted array

            while (start <= end)
            {
                var mid = start + (end - start) / 2;

                var prev = (mid - 1 + N) % N; // If at 1st element
                var next = (mid + 1) % N; //If mid is at last element, add 1 will go out of bounds, so % N

                if (nums[mid] <= nums[prev] && nums[mid] <= nums[next])
                {
                    return nums[mid];
                }
                else if (nums[start] <= nums[mid])
                {
                    //left half is sorted, so go right
                    start = mid + 1;

                }
                else if (nums[mid] <= nums[end])
                {
                    end = mid - 1;
                }
            }

            return -1;

            /*
             int findMin(vector<int>& nums) {
            int n = nums.size();        //Taking array size
            int low = 0 , high = n-1;   //Initializing our low and high variable 
       
            if(low == high) return nums[low];         //If array contains only one element             
            if(nums[low] <= nums[high])return nums[0];    //If array is already sorted and at correct positions like : 1 2 3 4 5 (No Rotation)
        
        while(low <= high){

            int mid = low + (high-low)/2;
            int prev = (mid- 1 + n)%n , next = (mid +1)%n;
            
            if (nums[mid] <= nums[prev] && nums[mid] <= nums[next]) return nums[mid];   //Returning our value
            else if (nums[0] <= nums[mid]) low = mid +1;             //Checking for sorted array with element arr[0] not with arr[low]
            else if (nums[mid] <= nums[n-1]) high = mid-1;
       
        }
        return -1;
    }
             */

        }
    }
}
