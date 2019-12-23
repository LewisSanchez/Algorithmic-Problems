// Solution to: https://leetcode.com/problems/longest-substring-without-repeating-characters/
public class Solution
{
	public int LengthOfLongestSubstring(string s)
	{
		var maxLength = 0;
		var letterFreq = new Dictionary<char, int>();

		var dupCount = 0;
		var start = 0;
		var end = 0;
		while (end < s.Length)
		{
			var curLetter = s[end];
			if (!letterFreq.ContainsKey(curLetter))
				letterFreq[curLetter] = 0;
			letterFreq[curLetter]++;

			if (letterFreq[curLetter] == 2)
				dupCount++;

			var length = end - start + 1;
			if (dupCount == 0 && maxLength < length)
				maxLength = length;

			while (dupCount != 0)
			{
				var startLetter = s[start];
				letterFreq[startLetter]--;
				if (letterFreq[startLetter] == 1)
					dupCount--;

				start++;
			}

			end++;
		}

		return maxLength;
	}
}