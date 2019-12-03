public class Solution
{
	public int NumIslands(char[][] grid)
	{
		var count = 0;
        
		for (int row = 0; row < grid.Length; ++row)
		{
			for (int col = 0; col < grid[0].Length; ++col)
			{
				if (grid[row][col] == '1')
				{
					++count;
					DFS(grid, row, col);
				}
			}
		}
		return count;
	}

	private void DFS(char[][] grid, int row, int col)
	{
		if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length || grid[row][col] != '1')
			return;

		grid[row][col] = '*';

		DFS(grid, row + 1, col);
		DFS(grid, row - 1, col);
		DFS(grid, row, col + 1);
		DFS(grid, row, col - 1);
	}
}