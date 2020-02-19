// Making Change - Given an integer representing a given amount of change,
// write a function to compute the minimum total number of coins required to make that
// amount of change. You can assume that there will always be a 1 cent coin.

// Dynamic Top-Down Solution
// Time Complexity: O(c * n): The call stack height to go from 0 to c times the number of coins available.
// Space Complexity: O(c): Max call stack stack height, and also includes the cache's memory usage.
public class Solution
{
	public int MakeChange(int c)
	{
		var coins = new int[] { 25, 10, 5, 1 };

		var cache = new int[c + 1];
		for (int i = 1; i < cache.Length; ++i)
			cache[i] = -1;

		return CalculateChange(c, coins, cache);
	}

	private int CalculateChange(int c, int[] coins, int[] cache)
	{
		if (cache[c] != -1)
			return cache[c];

		var minChange = Int32.MaxValue;
		foreach (var coin in coins)
		{
			if (c - coin < 0)
				continue;

			int change = CalculateChange(c - coin, coins, cache);
			if (minChange > change)
				minChange = change;
		}

		cache[c] = minChange + 1;
		return cache[c];
	}
}