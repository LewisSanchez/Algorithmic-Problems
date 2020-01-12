// Solution to: https://leetcode.com/problems/combination-sum/
public class Solution
{
	public IList<IList<int>> CombinationSum(int[] candidates, int target)
	{
		var combinations = new List<IList<int>>();
		var combination = new List<int>();

		FindSums(candidates, target, 0, combinations, combination);

		return combinations;
	}

	private void FindSums(int[] candidates, int target, int start, IList<IList<int>> combinations, IList<int> combination)
	{
		if (target == 0)
			combinations.Add(new List<int>(combination));

		for (int i = start; target > 0 && i < candidates.Length; ++i)
		{
			combination.Add(candidates[i]);
			FindSums(candidates, target - candidates[i], i, combinations, combination);
			combination.RemoveAt(combination.Count - 1);
		}
	}
}