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

		var cache = new Dictionary<int, Dictionary<int, int>>();

		return TargetSum(nums, T, 0, 0, cache);
	}

	private int TargetSum(int[] nums, int T, int i, int sum, Dictionary<int, Dictionary<int, int>> cache)
	{
		if (i == nums.Length)
			return sum == T ? 1 : 0;

		if (!cache.ContainsKey(i))
			cache[i] = new Dictionary<int, int>();
		else if (cache[i].ContainsKey(sum))
			return cache[i][sum];

		cache[i][sum] = TargetSum(nums, T, i + 1, sum + nums[i], cache) + TargetSum(nums, T, i + 1, sum - nums[i], cache);

		return cache[i][sum];
	}
}