public class Solution
{
	public bool CheckPermutation(string str1, string str2)
	{
		if (str1 == null || str2 == null || str1.Length != str2.Length)
			return false;

		var letterFreqs = new Dictionary<char, int>();

		foreach (var letter in str1)
		{
			if (!letterFreqs.ContainsKey(letter))
				letterFreqs[letter] = 0;

			letterFreqs[letter]++;
		}

		foreach (var letter in str2)
		{
			if (letterFreqs.ContainsKey(letter))
				letterFreqs[letter]--;
		}

		var frequencies = letterFreqs.Values.ToArray();
		foreach (var freq in frequencies)
		{
			if (freq != 0)
				return false;
		}

		return true;
	}
}