// Solution to: https://leetcode.com/problems/find-all-anagrams-in-a-string/
public class Solution
{
	public IList<int> FindAnagrams(string s, string p)
	{
		var indices = new List<int>();

		if (s == null)
			return indices;

		var maxLength = p.Length;
		var freqTable = new Dictionary<char, int>();

		foreach (var letter in p)
		{
			if (!freqTable.ContainsKey(letter))
				freqTable[letter] = 0;

			freqTable[letter]++;
		}

		var count = freqTable.Count;
		var start = 0;
		var end = 0;

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
				if (length == maxLength)
					indices.Add(start);

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

		return indices;
	}
}