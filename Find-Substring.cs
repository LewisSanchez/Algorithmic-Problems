// Solution to: https://leetcode.com/problems/substring-with-concatenation-of-all-words/
public class Solution
{
	public IList<int> FindSubstring(string s, string[] words)
	{
		var indices = new List<int>();
		var wordFreq = new Dictionary<string, int>();

		if (s == null || s.Length == 0 || words == null || words.Length == 0)
			return indices;

		foreach (var word in words)
		{
			if (!wordFreq.ContainsKey(word))
				wordFreq[word] = 0;

			wordFreq[word]++;
		}

		var wordLength = words[0].Length;
		var maxNumWords = words.Length;

		for (var i = 0; i < wordLength; ++i)
		{
			var start = i;
			var end = i;
			var wordFreqCopy = new Dictionary<string, int>(wordFreq);
			var count = wordFreqCopy.Count;

			while (end + wordLength - 1 < s.Length)
			{
				var endWord = s.Substring(end, wordLength);
				if (wordFreqCopy.ContainsKey(endWord))
				{
					wordFreqCopy[endWord]--;

					if (wordFreqCopy[endWord] == 0)
						count--;
				}

				while (count == 0)
				{
					var numWords = (end + wordLength - start) / wordLength;
					if (numWords == maxNumWords)
						indices.Add(start);

					var startWord = s.Substring(start, wordLength);
					if (wordFreqCopy.ContainsKey(startWord))
					{
						wordFreqCopy[startWord]++;

						if (wordFreqCopy[startWord] == 1)
							count++;
					}

					start += wordLength;
				}

				end += wordLength;
			}
		}

		return indices;
	}
}