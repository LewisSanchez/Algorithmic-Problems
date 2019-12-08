// Improved solution to: https://leetcode.com/problems/friend-circles/
public class Solution
{
	public int FindCircleNum(int[][] M)
	{
		var count = 0;
		var numStudents = M.Length;
		var friendZoned = new List<bool>(numStudents);
		var friends = new Stack<int>();

		for (int i = 0; i < numStudents; ++i)
			friendZoned.Add(false);

		for (int i = 0; i < numStudents; ++i)
		{
			if (!friendZoned[i])
			{
				++count;
				friends.Push(i);

				while (friends.Count != 0)
				{
					var currentStudent = friends.Pop();
					friendZoned[currentStudent] = true;

					for (int j = 0; j < numStudents; ++j)
					{
						if (!friendZoned[j] && M[currentStudent][j] == 1)
							friends.Push(j);
					}
				}
			}
		}

		return count;
	}
}