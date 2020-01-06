// Solution to: https://leetcode.com/problems/subsets/
public class Solution
{
	public IList<IList<int>> Subsets(int[] nums)
	{
		var powerset = new List<IList<int>>();
		var subset = new List<int>();

		if (nums != null)
			FindSubsets(nums, 0, powerset, subset);

		return powerset;
	}

	private void FindSubsets(int[] nums, int start, IList<IList<int>> powerset, IList<int> subset)
	{
		powerset.Add(new List<int>(subset));

		for (int i = start; i < nums.Length; ++i)
		{
			subset.Add(nums[i]);
			FindSubsets(nums, i + 1, powerset, subset);
			subset.RemoveAt(subset.Count - 1);
		}
	}
}