// Solution to: https://leetcode.com/problems/friend-circles/
public class Solution
{
	public int FindCircleNum(int[][] M)
	{
		int count = 0;
		var numStudents = M.Length;
		var friendZoned = new List<bool>(numStudents);
		var friendsList = new List<List<int>>(numStudents);
		var friends = new Stack<int>();

		for (int student = 0; student < numStudents; ++student)
		{
			friendZoned.Add(false);
			friendsList.Add(new List<int>());
		}

		for (int i = 0; i < numStudents; ++i)
		{
			for (int j = i + 1; j < numStudents; ++j)
			{
				if (M[i][j] == 1)
				{
					friendsList[i].Add(j);
					friendsList[j].Add(i);
				}
			}
		}

		for (int student = 0; student < numStudents; ++student)
		{
			if (!friendZoned[student])
			{
				++count;
				friends.Push(student);

				while (friends.Count != 0)
				{
					var curStudent = friends.Pop();
					friendZoned[curStudent] = true;
					var studentFriends = friendsList[curStudent];

					foreach (var friend in studentFriends)
					{
						if (!friendZoned[friend])
							friends.Push(friend);
					}
				}
			}
		}
		return count;
	}
}