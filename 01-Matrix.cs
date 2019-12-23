// Solution to: https://leetcode.com/problems/01-matrix/
public class Solution
{
	public int[][] UpdateMatrix(int[][] matrix)
	{
		var bfs = new Queue<int[]>();
		var maxRow = matrix.Length;
		var maxCol = matrix[0].Length;

		for (int row = 0; row < maxRow; ++row)
		{
			for (int col = 0; col < maxCol; ++col)
			{
				if (matrix[row][col] == 0)
					bfs.Enqueue(new int[] { row, col });
				else
					matrix[row][col] = Int32.MaxValue;
			}
		}

		var directions = new int[][] { new int[] { 0, 1 },
						new int[] { 0, -1 },
						new int[] { 1, 0 },
						new int[] { -1, 0 } };

		while (bfs.Count != 0)
		{
			var cur = bfs.Dequeue();
			var row = cur[0];
			var col = cur[1];

			foreach (var direction in directions)
			{
				var adjRow = row + direction[0];
				var adjCol = col + direction[1];

				if (adjRow < 0 || adjRow >= maxRow || adjCol < 0 || adjCol > maxCol || matrix[adjRow][adjCol] <= matrix[row][col])
					continue;

				matrix[adjRow][adjCol] = matrix[row][col] + 1;
				dfs.Enqueue(new Int[] { adjRow, adjCol });
			}
		}

		return matrix;
	}
}