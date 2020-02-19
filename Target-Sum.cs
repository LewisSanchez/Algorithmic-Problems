// Given an array of integer, nums and a target value T, find the number of
// ways that you can add and subtract the values in nums to add up to T.

// Time Complexity: O(2^n): 2^n because the recursive tree branches by 2 each time
// Space Complexity: O(n): n is the height of the recursive tree or call stack
public class Solution 
{
	public int TargetSum(int[] nums, int T)
	{
		if (nums == null)
			return 0;

		return TargetSum(nums, T, 0, 0);
	}

	private int TargetSum(int[] nums, int T, int i, int sum)
	{
		if (i == nums.Length)
		{
			return sum == T ? 1 : 0;
		}

		return TargetSum(nums, T, i + 1, sum + nums[i]) + TargetSum(nums, T, i + 1, sum - nums[i]);
	}
}