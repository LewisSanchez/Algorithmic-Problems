// Top-Down Solution
// Time Complexity: O(n)
// Space Complexity: O(n)
public class Solution
{
	public int Fibonacci(int n)
	{
		if (n < 2)
			return n;

		var cache = new int[n + 1];
		cache[0] = 0;
		cache[1] = 1;
		for (int i = 2; i < cache.Length; ++i)
			cache[i] = -1;

		return Fibonacci(n, cache);
	}

	private int Fibonacci(int n, int[] cache)
	{
		if (cache[n] != -1)
			return cache[n];

		cache[n] = Fibonacci(n - 1, cache) + Fibonacci(n - 2, cache);
		return cache[n];
	}
}