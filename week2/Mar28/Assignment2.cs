public class Solution
{
    // leetcode 15
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        // sort the array
        Array.Sort(nums);
        // result is a list of list of integers
        var result = new List<IList<int>>();

        // loop through the array
        for (int i = 0; i < nums.Length - 2; i++)
        {
            // if the current number is greater than 0, then we can't find any triplets
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            // use two pointers to find the other two numbers
            int left = i + 1;
            int right = nums.Length - 1;

            // loop until the two pointers meet
            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];
                if (sum == 0)
                {
                    // add the triplet to the result
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });
                    left++;
                    right--;

                    // skip the duplicates
                    while (left < right && nums[left] == nums[left - 1])
                    {
                        left++;
                    }
                    while (left < right && nums[right] == nums[right + 1])
                    {
                        right--;
                    }
                }
                // if the sum is less than 0, then we need to increase the sum
                else if (sum < 0)
                {
                    left++;
                }
                // if the sum is greater than 0, then we need to decrease the sum
                else
                {
                    right--;
                }
            }
        }
        return result;
    }

}
