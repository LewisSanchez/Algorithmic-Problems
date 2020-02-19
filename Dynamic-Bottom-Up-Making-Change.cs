// Making Change - Given an integer representing a given amount of change,
// write a function to compute the minimum total number of coins required to make that
// amount of change. You can assume that there will always be a 1 cent coin.

// Dynamic Bottom-Up Solution
// Time Complexity: O(c * n) // The amount of change we're solving for times the number of coins we have available.
// Space Complexity: O(c) - Cache's memory usage to store answers from 0 to the amount of change we're solving for.
public class Solution
{
	public int CalculateChange(int c)
	{
		var coins = new int[] { 25, 10, 5, 1 };
		var cache = new int[c + 1];
	
		for (int i = 1; i <= c; ++i)
		{
			var minChange = Int32.MaxValue;

			foreach (var coin in coins)
			{
				if (i - coin < 0)
					continue;

				var change = cache[i - coin] + 1;
				if (minChange > change)
					minChange = change;
			}

			cache[i] = minChange;
		}

		return cache[c];
	}
}