// Ch 1. Prob 1.
public class Solution
{
	public bool IsUnique(string str)
	{
		if (str == null)
			return true;

		var charFrequencies = new Dictionary<char, int>();

		foreach (var letter in str)
		{
			if (!charFrequencies.ContainsKey(letter))
				charFrequencies[letter] = 0;

			charFrequencies[letter]++;

			if (charFrequencies[letter] > 1)
				return false;
		}

		return true;
	}
}