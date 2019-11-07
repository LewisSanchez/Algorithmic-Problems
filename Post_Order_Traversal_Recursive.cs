// Recursive solution to: https://leetcode.com/problems/binary-tree-postorder-traversal/
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
	public IList<int> PostorderTraversal(TreeNode root)
	{
		List<int> postOrder = new List<int>();
		Postorder(root, postOrder);

		return postOrder;
	}

	private void Postorder(TreeNode root, IList<int> postOrder)
	{
		if (root == null)
			return;

		Postorder(root.left, postOrder);
		Postorder(root.right, postOrder);
		postOrder.Add(root.val);
	}
}