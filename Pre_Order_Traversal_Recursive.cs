// Recursive solution to: https://leetcode.com/problems/binary-tree-preorder-traversal/
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

		PreorderTraversal(root, preOrder);

		return preOrder;
	}

	private void PreorderTraversal(TreeNode root, IList<int> preOrder)
	{
		if (root == null)
			return;

		preOrder.Add(root.val);
		PreorderTraversal(root.left, preOrder);
		PreorderTraversal(root.right, preOrder);
	}
}