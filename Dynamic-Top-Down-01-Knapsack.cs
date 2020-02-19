// Given a list of items with values and weights, as well as a max weight,
// find the maximum value you can generate from items, where the sum of
// the weights is less than or equal to the max.

// Time Complexity: O(iw)
// Space Complexity: O(iw)

public class Item
{
	public int Weight { get; set; }
	public int Value { get; set; }

	public Item(int weight, int value)
	{
		Weight = weight;
		value = value;
	}
}

public class Solution
{
	public int Knapsack(Item[] items, int w)
	{
		if (items == null)
				return 0;

		var cache = new int[items.Length][];
		for (int i = 0; i < items.Length; ++i)
			cache[i] = new int[w + 1];

		for (int i = 0; i < items.Length; ++i)
		{
			for (int c = 1; c <= w; ++c)
				cache[i][c] = -1;
		}

		return Knapsack(items, w, 0, cache);
	}

	private int Knapsack(Item[] items, int w, int i, int[][] cache)
	{
		if (i == items.Length)
			return 0;

		if (cache[i][w] != -1)
			return cache[i][w];

		var maxValue = 0;
		if (w - items[i].Weight < 0)
			maxValue = Knapsack(items, w, i + 1, cache);
		else
			maxValue = Math.Max(Knapsack(items, w - items[i].Weight, i + 1, cache) + items[i].Value,
						Knapsack(items, w, i + 1, cache));

		cache[i][w] = maxValue;
		return cache[i][w];
	}
}