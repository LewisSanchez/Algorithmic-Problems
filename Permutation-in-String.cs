// Solution to: https://leetcode.com/problems/permutation-in-string/
public class Solution
{
	public bool CheckInclusion(string s1, string s2)
	{
		var table = new Dictionary<char, int>();

		if (s1 == null || s2 == null)
			return false;

		foreach (var letter in s1)
		{
			if (!table.ContainsKey(letter))
				table[letter] = 0;
			table[letter]++;
		}

		var permLength = s1.Length;
		var count = table.Count;
		var start = 0;
		var end = 0;
		while (end < s2.Length)
		{
			var curLetter = s2[end];
			if (table.ContainsKey(curLetter))
			{
				table[curLetter]--;
				if (table[curLetter] == 0)
					count--;
			}

			while (count == 0)
			{
				var length = end - start + 1;
				if (length == permLength)
					return true;

				var startLetter= s2[start];
				if (table.ContainsKey(startLetter))
				{
					table[startLetter]++;
					if (table[startLetter] == 1)
						count++;
				}
				start++;
			}
			end++;
		}

		return false;
	}
}