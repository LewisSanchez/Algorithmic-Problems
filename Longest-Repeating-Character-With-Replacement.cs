// Solution to: https://leetcode.com/problems/longest-repeating-character-replacement/
public class Solution
{
	public int CharacterReplacement(string s, int k)
	{
		var longestLength = 0;
		var table = new Dictionary<char, int>();
		var mostFreqCharCount = 0;
		var start = 0;
		var end = 0;

		while (s != null && end < s.Length)
		{
			var curLetter = s[end];
			if (!table.ContainsKey(curLetter))
				table[curLetter] = 0;
			table[curLetter]++;

			mostFreqCharCount = Math.Max(mostFreqCharCount, table[curLetter]);
			var length = end - start + 1;
			if (length <= mostFreqCharCount + k && longestLength < length)
				longestLength = length;

			while (length > mostFreqCharCount + k)
			{
				var startLetter = s[start];
				table[starLetter]--;
				start++;
				length--;
			}

			end++;
		}

		return longestLength;
	}
}