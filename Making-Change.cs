// Making Change - Given an integer representing a given amount of change,
// write a function to compute the minimum total number of coins required to make that
// amount of change. You can assume that there will always be a 1 cent coin.

// Time Complexity: O(c^n): c = number of coins, and n = depth of the recursive call stack
// Space Complexity: O(n): n = max height of the call stack
public class Solution
{
	public int MakeChange(int c)
	{
		var coins = new int[] { 25, 10, 5, 1 };

		return CalculateChange(c, coins);
	}

	private int CalculateChange(int c, int[] coins)
	{
		if (c == 0)
			return 0;

		var minChange = Int32.MaxValue;
		foreach (var coin in coins)
		{
			if (c - coin < 0)
				continue;

			int change = CalculateChange(c - coin, coins);
			if (minChange > change)
				minChange = change;
		}

		return minChange + 1;
	}
}