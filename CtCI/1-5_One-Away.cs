public class Solution
{
	public bool OneAway(string str1, string str2)
	{
		// Identify the longest of the 2 strings, so that we're always checking
		// if we're a single removal or replacement away and not an add away.
		var bigString = string.Empty;
		var shortString = string.Empty;
		if (str1.Length > str2.Length)
		{
			bigString = str1;
			shortString = str2;
		}
		else
		{
			bigString = str2;
			shortString = str1;
		}

		bigString = bigString.ToUpper();
		shortString = shortString.ToUpper();

		if (bigString.Length - shortString.Length > 1)
			return false;

		// Increment the frequency of each letter in bigString.
		var table = new Dictionary<char, int>();
		foreach (var letter in bigString)
		{
			if (!table.ContainsKey(letter))
				table[letter] = 0;
			table[letter]++;
		}

		// Decrement the frequency of letters in the table as we process them
		// in shortString.
		foreach (var letter in shortString)
		{
			if (table.ContainsKey(letter))
				table[letter]--;
		}

		int editsNeeded = 0;
		var frequencies = table.Values.ToArray();
		foreach (var frequency in frequencies)
		{
			if (frequency == 1)
				editsNeeded++;	
		}

		return editsNeeded <= 1 ? true : false;
	}
}
/*
	str1 aka bigString: PALE	Table:  P: 1		Output: True, one edit away
	str2 aka shortString: BALE		A: 1 -> 0
						L: 1 -> 0
						E: 1 -> 0

	str1 aka bigString: PALES		P: 1 -> 0	Output: True, one edit away
	str2 aka shortString: PALE		A: 1 -> 0
						L: 1 -> 0
						E: 1 -> 0
						S: 1
*/