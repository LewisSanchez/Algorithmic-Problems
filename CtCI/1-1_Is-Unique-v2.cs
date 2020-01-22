// Ch. 1 Prob. 1
public class Solution
{
	public bool IsUnique(string str)
	{
		if (str == null)
			return true;

		for (int i = 0; i < str.Length - 1; ++i)
		{
			for (int j = i + 1; j < str.Length; j++)
			{
				if (str[i] == str[j])
					return false;
			}
		}

		return true;
	}
}