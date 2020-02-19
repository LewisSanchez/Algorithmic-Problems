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
		return Knapsack(items, w, 0);
	}

	private int Knapsack(Item[] items, int w, int i)
	{
		if (i == items.Length)
			return 0;

		if (w - items[i].Weight < 0)
			return Knapsack(items, w, i + 1);

		return Math.Max(Knapsack(items, w - items[i].Weight, i + 1) + items[i].Value,
					Knapsack(items, w, i + 1));
	}
}