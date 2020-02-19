// Given a 2D boolean array, find the largest square subarray of true values.
// The return value should be the side length of the largest square subarray
// in the 2D array.
// Time Complexity: O(r * c): First loop of r * second loop of c, thus we visit each cell once
// Space Complexity: O(r * c): Space to store all cell results in cache
public class Solution
{
	public int SquareSubmatrix(bool[][] arr)
	{
		int largestLength = 0;

		var cache = new int[arr.Length][];
		for (int r = 0; r < arr.Length; ++r)
			cache[r] = new int[arr[0].Length];

		for (int row = 0; row < arr.Length; ++row)
		{
			for (int col = 0; col < arr.Length; ++col)
			{
				if (arr[row][col] == true)
				{
					int length = FindLength(arr, row, col, cache);
					if (largestLength < length)
						largestLength = length;
				}
			}
		}

		return largestLength;
	}

	private int FindLength(int[][] arr, int row, int col, Dictionary<int, int[][] cache)
	{
		if (row == arr.Length || col == arr[0].Length || arr[row][col] == false)
			return 0;

		if (cache[row][col] > 0)
			return cache[row][col];

		cache[row][col] = Math.Min(FindLength(arr, row + 1, col, cache),
				Math.Min(FindLength(arr, row, col + 1, cache), FindLength(arr, row + 1, col + 1, cache))) + 1;

		return cache[row][col];
	}
}