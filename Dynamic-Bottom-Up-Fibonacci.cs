// Bottom-Up Solution
// Time Complexity: O(n)
// Space Complexity: O(1)
public class Solution
{
	public int Fibonacci(int n)
	{
		int firstVal = 0;
		int secondVal = 1;
		int result = 0;
		
		if (n == 0)
			return firstVal;
		if (n == 1)
			return secondVal;

		for (int i = 2; i <= n; ++i)
		{
			result = secondVal + firstVal;
			firstVal = secondVal;
			secondVal = result;
		}

		return result;	
	}
}