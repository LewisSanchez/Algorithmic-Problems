// Solution to: https://leetcode.com/problems/subsets-ii/
public class Solution
{
	public IList<IList<int>> SubsetsWithDup(int[] nums)
	{
		var powerset = new List<IList<int>>();
		var subset = new List<int>();

		if (nums != null)
		{
			Array.Sort(nums);
			FindSubsets(nums, 0, powerset, subset);
		}

		return powerset;
	}

	private void FindSubsets(int[] nums, int start, IList<IList<int>> powerset, IList<int> subset)
	{
		powerset.Add(new List<int>(subset));

		for (int i = start; i < nums.Length; ++i)
		{
			if (i > start && nums[i] == nums[i - 1])
				continue;

			subset.Add(nums[i]);
			FindSubsets(nums, i + 1, powerset, subset);
			subset.RemoveAt(subset.Count - 1);
		}
	}
}