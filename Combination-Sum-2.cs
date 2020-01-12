// Solution to: https://leetcode.com/problems/combination-sum-ii/
public class Solution
{
	public IList<IList<int>> CombinationSum2(int[] candidates, int target)
	{
		var combinations = new List<IList<int>>();
		var combination = new List<int>();

		if (candidates != null)
		{
			Array.Sort(candidates);
			FindSums(candidates, target, 0, combinations, combination);
		}

		return combinations;
	}

	private void FindSums(int[] candidates, int target, int start, IList<IList<int>> combinations, IList<int> combination)
	{
		if (target == 0)
			combinations.Add(new List<int>(combination));

		for (int i = start; target > 0 && i < candidates.Length; ++i)
		{
			if (i > start && candidates[i] == candidates[i - 1])
				continue;

			combination.Add(candidates[i]);
			FindSums(candidates, target - candidates[i], i + 1, combinations, combination);
			combination.RemoveAt(combination.Count - 1);
		}
	}
}