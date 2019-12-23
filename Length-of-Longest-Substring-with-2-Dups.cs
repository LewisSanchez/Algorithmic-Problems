// Solution to: https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/
public class Solution
{
	public int LengthOfLongestSubstringTwoDistinct(string s)
	{
		const int MAX_DISTINCT_COUNT = 2;

		var letterFreq = new Dictionary<char, int>();
		var longestLength = 0;
		var distinctCount = 0;
		var start = 0;
		var end = 0;

		while (s != null && end < s.Length)
		{
			var curLetter = s[end];
			if (!letterFreq.ContainsKey(curLetter))
				letterFreq[curLetter] = 0;
			letterFreq[curLetter]++;

			if (letterFreq[curLetter] == 1)
				distinctCount++;

			var length = end - start + 1;
			if (distinctCount <= MAX_DISTINCT_COUNT && longestLength < length)
				longestLength = length;

			while (distinctCount > MAX_DISTINCT_COUNT)
			{
				var startLetter = s[start];
				letterFreq[startLetter]--;
				if (letterFreq[startLetter] == 0)
					distinctCount--;

				start++;
			}

			end++;
		}

		return longestLength;
	}
}