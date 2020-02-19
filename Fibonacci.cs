// Fibonacci Sequence: 0 1 1 2 3 5 8
// Time Complexity: O(2^n) - 2 additional recursive calls each time
// Space Complexity: O(n): Depth of the recursive call
public class Solution
{
	public int Fibonacci(int n)
	{
		if (n == 0)
			return 0;

		if (n == 1)
			return 1;

		return Fibonacci(n - 1) + Fibonacci(n - 2);
	}
}