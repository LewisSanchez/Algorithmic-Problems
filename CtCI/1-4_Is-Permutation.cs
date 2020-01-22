public class Solution
{
	public bool IsPermutation(string str)
	{
		var charTable = new Dictionary<char, int>();

		// Find the frequecies for each letter in the string
		foreach (var letter in str)
		{
			if (letter != ' ')
			{
				if (!charTable.ContainsKey(letter))
					charTable[letter] = 0;
				charTable[letter]++;
			}
		}

		// Extract the frequencies and count the number of unpaired letters
		var frequencies = charTable.Values.ToArray();
		var singleLetterCount = 0;

		foreach (var frequency in frequencies)
		{
			if (frequency % 2 != 0)
				singleLetterCount++;
		}

		return singleLetterCount <= 1 ? true : false;
	}
}