// Solution to: https://leetcode.com/problems/n-queens/
public class Solution
{
	public IList<IList<string>> SolveNQueens(int n)
	{
		var solutions = new List<IList<string>>();
		var board = new List<string>();

		SetBoard(board, n);
		FindSolutions(0, n, solutions, board);

		return solutions;
	}

	private void SetBoard(IList<string> board, int n)
	{
		for (int row = 0; row < n; ++row)
			board.Add(new string('.', n));
	}

	private void FindSolutions(int row, int n, IList<IList<string>> solutions, IList<string> board)
	{
		if (row == n)
			solutions.Add(new List<string>(board));
		else
		{
			var rowChars = board[row].ToCharArray();

			for (int col = 0; row < n && col < n; ++col)
			{
				if (IsQueenPlacementValid(row, col, board))
				{
					rowChars[col] = 'Q';
					board[row] = new string(rowChars);

					FindSolutions(row + 1, n, solutions, board);

					rowChars[col] = '.';
					board[row] = new string(rowChars);
				}
			}
		}
	}

	private bool IsQueenPlacementValid(int row, int col, IList<string> board)
	{
		for (int x = 1; row - x >= 0; ++x)
		{
			if (board[row - x][col] == 'Q')
				return false;
		}

		for (int x = 1; row - x >= 0 && col - x >= 0; ++x)
		{
			if (board[row - x][col - x] == 'Q')
				return false;
		}

		var n = board.Count;
		for (int x = 1; row - x >= 0 && col + x < n; ++x)
		{
			if (board[row - x][col + x] == 'Q')
				return false;
		}

		return true;
	}
}