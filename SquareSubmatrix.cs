// Given a 2D boolean array, find the largest square subarray of true values.
// The return value should be the side length of the largest square subarray
// in the 2D array.

// Time Complexity: O(r * c * 3^(r + c)): First loop of r * second loop of c * 3 branches to recurse over raised to (r + c),
//					  which is the max distance from (0, 0) to (r, c)
// Space Complexity: O(r + c): Space to store recursive stack from (0, 0) down to (r, c)
public class Solution
{
	public int SquareSubmatrix(bool[][] arr)
	{
		int largestLength = 0;

		for (int row = 0; row < arr.Length; ++row)
		{
			for (int col = 0; col < arr.Length; ++col)
			{
				if (arr[row][col] == true)
				{
					int length = FindLength(arr, row, col);
					if (largestLength < length)
						largestLength = length;
				}
			}
		}

		return largestLength;
	}

	private int FindLength(int[][] arr, int row, int col)
	{
		if (row == arr.Length || col == arr[0].Length || arr[row][col] == false)
			return 0;

		return Math.Min(FindLength(arr, row + 1, col),
				Math.Min(FindLength(arr, row, col + 1), FindLength(arr, row + 1, col + 1))) + 1;
	}
}