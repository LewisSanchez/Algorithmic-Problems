// Recursive solution to: https://leetcode.com/problems/binary-tree-inorder-traversal/
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
	public IList<int> InOrderTraversal(TreeNode root)
	{
		List<int> inOrder = new List<int>();
		Traverse(root, inOrder);
		
		return inOrder;
	}

	private void Traverse(TreeNode root, IList<int> inOrder)
	{
		if (root == null)
			return;

		Traverse(root.left, inOrder);
		inOrder.Add(root.val);
		Traverse(root.right, inOrder);
	}
}