// Solution to: https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/
public class Solution
{
	public int LengthOfLongestSubstringKDistinct(string s, int k)
	{
		var longestLength = 0;

		var table = new Dictionary<char, int>();
		var distinctCount = 0;
		var start = 0;
		var end = 0;
		while (end < s.Length)
		{
			var curLetter = s[end];

			if (!table.ContainsKey(curLetter))
				table[curLetter] = 0;
			table[curLetter]++;

			if (table[curLetter] == 1)
				distinctCount++;

			var length = end - start + 1;
			if (distinctCount <= k && longestLength < length)
				longestLength = length;

			while (distinctCount > k)
			{
				var startLetter = s[start];
				table[startLetter]--;
				if (table[startLetter] == 0)
					distinctCount--;

				start++;
			}
			end++;
		}

		return longestLength;
	}
}