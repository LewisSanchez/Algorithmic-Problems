// Given a 2D boolean array, find the largest square subarray of true values.
// The return value should be the side length of the largest square subarray
// in the 2D array.

// Time Complexity: O(r * c): First loop of r * second loop of c * 3 branches to recurse over raised to (r + c),
//					  which is the max distance from (0, 0) to (r, c)
// Space Complexity: O(r * c): Space to store recursive stack from (0, 0) down to (r, c)
public class Solution
{
	public int SquareSubmatrix(bool[][] arr)
	{
		int largestLength = 0;

		int[][] cache = new int[arr.Length][];
		for (int i = 0; i < arr.Length; ++i)
			cache[i] = new int[arr[0].Length];

		for (int r = 0; r < arr.Length; ++r)
		{
			if (arr[r][0] == true)
			{
				cache[r][0] = 1;
				if (cache[r][0] > largestLength)
					largestLength = cache[r][0];
			}
		}

		for (int c = 1; c < arr[0].Length; ++c)
		{
			if (arr[0][c] == true)
			{
				cache[0][c] = 1;
				if (cache[0][c] > largestLength)
					largestLength = cache[0][c];
			}
		}

		for (int r = 1; r < arr.Length; ++r)
		{
			for (int c = 1; c < arr[0].Length; ++c)
			{
				if (arr[r][c] == true)
				{
					cache[r][c] = Math.Min(cache[r - 1][c], Math.Min(cache[r][c - 1], cache[r - 1][c - 1]));
					if (largestLength < cache[r][c])
						largestLength = cache[r][c];
				}
			}
		}

		return largestLength;
	}
}