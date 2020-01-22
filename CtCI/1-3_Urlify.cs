public class Solution
{
	public string Urlify(char[] letters, int length)
	{
		for (int i = 0; i < length; ++i)
		{
			if (letters[i] == ' ')
			{
				ShiftLetters(letters, i, length);
				InsertSeparator(letters, i);
			}
		}

		return new string(letters); 
	}

	private void ShiftLetters(char[] letters, int spaceIndex, int length)
	{
		for (int i = length - 3; i > spaceIndex; --i)
			letters[i + 2] = letters[i]
	}

	private void InsertSeparator(char[] letters, int start)
	{
		var separator = "%20";
		for (int i = 0; i <= 2; ++i)
			letters[start + i] = separator[i];
	}
}