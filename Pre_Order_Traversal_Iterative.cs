// Iterative solution to: https://leetcode.com/problems/binary-tree-preorder-traversal/
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
	public IList<int> PreorderTraversal(TreeNode root)
	{
		List<int> preOrder = new List<int>();
		Stack<TreeNode> nodes = new Stack<TreeNode>();

		while (root != null || nodes.Count != 0)
		{
			while (root != null)
			{
				preOrder.Add(root.val);
				nodes.Push(root);
				root = root.left;
			}

			root = nodes.Pop();
			root = root.right;
		}

		return preOrder;
	}
}