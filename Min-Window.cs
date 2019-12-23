// Solution to: https://leetcode.com/problems/minimum-window-substring/
public class Solution
{
	public string MinWindow(string s, string t)
	{
		var minWindow = string.Empty;
		var freqTable = new Dictionary<char, int>();

		foreach (var letter in t)
		{
			if (!freqTable.ContainsKey(letter))
				freqTable[letter] = 0;

			freqTable[letter]++;
		}

		var start = 0;
		var end = 0;
		var count = freqTable.Count;
		var minLength = Int32.MaxValue;

		while (end < s.Length)
		{
			if (freqTable.ContainsKey(s[end]))
			{
				freqTable[s[end]]--;

				if (freqTable[s[end]] == 0)
					count--;
			}

			while (count == 0)
			{
				var length = end - start + 1;
				if (minLength > length)
				{
					minLength = length;
					minWindow = s.Substring(start, length);
				}

				if (freqTable.ContainsKey(s[start]))
				{
					freqTable[s[start]]++;

					if (freqTable[s[start]] == 1)
						count++;
				}

				start++;
			}

			end++;
		}

		return minWindow;
	}
}