// Given a list of items with values and weights, as well as a max weight,
// find the maximum value you can generate from items, where the sum of
// the weights is less than or equal to the max.

// Time Complexity: O(2^n)
// Space Complexity: O(n)

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
		for (var i = 0; i < items.Length; ++i)
			cache[i] = new int[w + 1];

		for (int curWeight = 0; curWeight <= w; ++curWeight)
		{
			if (items[0].Weight <= curWeight)
				cache[0][curWeight] = items[0].Value;
		}

		for (var i = 1; i < items.Length; ++i)
		{
			var itemWeight = items[i].Weight;
			var itemValue = items[i].Value;

			for (int curWeight = 0; curWeight <= w; ++curWeight)
			{
				if (itemWeight <= curWeight)
				{
					cache[i][curWeight] = Math.Max(itemValue + cache[i - 1][curWeight - itemWeight], cache[i - 1][curWeight]);
				}
			}
		}

		return cache[items.Length - 1][w];
	}
}