public class Solution
{
    // leetcode 1
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(target - nums[i]))
            {
                return new int[] { dict[target - nums[i]], i };
            }
            else
            {
                dict[nums[i]] = i;
            }
        }
        return new int[] { };
    }


    // leetcode 9 
    public bool IsPalindrome(int x)
    {
        if (x < 0)
        {
            return false;
        }
        var str = x.ToString();
        for (int i = 0; i < str.Length / 2; i++)
        {
            if (str[i] != str[str.Length - 1 - i])
            {
                return false;
            }
        }
        return true;
    }

    // leetcode 217
    public bool ContainsDuplicate(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {
                return true;
            }
            else
            {
                dict[nums[i]] = i;
            }
        }
        return false;
    }

    // leetcode 412
    public IList<string> FizzBuzz(int n)
    {
        var list = new List<string>();
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                list.Add("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                list.Add("Fizz");
            }
            else if (i % 5 == 0)
            {
                list.Add("Buzz");
            }
            else
            {
                list.Add(i.ToString());
            }
        }
        return list;
    }
    
}
