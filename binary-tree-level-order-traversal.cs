// Solution to: https://leetcode.com/problems/binary-tree-level-order-traversal/
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution
{
	public IList<IList<int>> LevelOrder(TreeNode root)
	{
		var nodes = new Queue<TreeNode>();
		var levels = new List<IList<int>>();
		var level = new List<int>();
		var marker = new TreeNode(Int32.MinValue);

		if (root == null)
			return levels;

		nodes.Enqueue(root);
		nodes.Enqueue(marker);

		while (nodes.Count != 0)
		{
			var curNode = nodes.Dequeue();

			if (curNode != null)
			{
				if (curNode.val == marker.val)
				{
					if (level.Count != 0)
					{
						levels.Add(level);
						level = new List<int>();
					}

					if (nodes.Count != 0)
						nodes.Enqueue(marker);
				}
				else
				{
					level.Add(curNode.val);
					nodes.Enqueue(curNode.left);
					nodes.Enqueue(curNode.right);
				}
			}
		}

		return levels;
	}
}