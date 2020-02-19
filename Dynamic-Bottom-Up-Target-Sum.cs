// Given an array of integer, nums and a target value T, find the number of
// ways that you can add and subtract the values in nums to add up to T.

// Time Complexity: O(n * sum(nums)): n is the number of sums * the range of sum(nums)
// Space Complexity: O(n * sum(nums)): n is the number of nums * the range sum(nums)
public class Solution 
{
	public int TargetSum(int[] nums, int T)
	{
		if (nums == null)
			return 0;

		int sum = 0;
		foreach (var num in nums)
			sum += nums;

		var cache = new int[nums.Length + 1][];
		for (int i = 0; i <= nums.Length; ++i)
			cache[i] = new int[2 * sum + 1];

		cache[0][num] = 1;

		for (int i = 1; i <= nums.Length; ++i)
		{
			for (int j = 0; j < 2 * sum + 1; ++j)
			{
				var prev = cache[i - 1][j];
				if (prev == 1)
				{
					cache[i][j - nums[i - 1]] += prev;
					cache[i][j + nums[i - 1]] += prev;
				}
			}
		}

		return cache[nums.Length][sum + T];
	}
}