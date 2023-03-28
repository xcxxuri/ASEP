public class Solution
{
    // leetcode 1
    public int[] TwoSum(int[] nums, int target)
    {
        // create a dictionary to store the number and its index
        dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            // if the dictionary contains the key of target - nums[i],
            if (dict.ContainsKey(target - nums[i]))
            {
                // return the index of the key and the current index
                return new int[] { dict[target - nums[i]], i };
            }
            else
            {
                // otherwise, add the number and its index to the dictionary
                dict[nums[i]] = i;
            }
        }
        // if no solution found, return empty array
        return new int[] { };
    }


    // leetcode 9 
    public bool IsPalindrome(int x)
    {
        // if the number is negative, return false
        if (x < 0)
        {
            return false;
        }
        // convert the number to string
        string str = x.ToString();
        // compare the first and last character, second and second last character, etc.
        for (int i = 0; i < str.Length / 2; i++)
        {
            // if the characters are not the same, return false
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
        // create a dictionary to store the number and its index
        var dict = new Dictionary<int, int>();
        // iterate through the array
        for (int i = 0; i < nums.Length; i++)
        {
            // if the dictionary contains the number, return true
            if (dict.ContainsKey(nums[i]))
            {
                return true;
            }
            else
            {
                // otherwise, add the number and its index to the dictionary
                dict[nums[i]] = i;
            }
        }
        return false;
    }

    // leetcode 412
    public IList<string> FizzBuzz(int n)
    {
        // create a list to store the result
        var list = new List<string>();
        for (int i = 1; i <= n; i++)
        {
            // if the number is divisible by 3 and 5, add "FizzBuzz" to the list
            if (i % 3 == 0 && i % 5 == 0)
            {
                list.Add("FizzBuzz");
            }
            // if the number is divisible by 3, add "Fizz" to the list
            else if (i % 3 == 0)
            {
                list.Add("Fizz");
            }
            //  if the number is divisible by 5, add "Buzz" to the list
            else if (i % 5 == 0)
            {
                list.Add("Buzz");
            }
            // otherwise, add the number to the list
            else
            {
                list.Add(i.ToString());
            }
        }
        return list;
    }

}
