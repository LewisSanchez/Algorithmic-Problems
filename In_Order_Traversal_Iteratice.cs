// Iterative solution to: https://leetcode.com/problems/binary-tree-inorder-traversal/
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
		Stack<TreeNode> nodes = new Stack<TreeNode>();

		while (root != null || nodes.Count != 0)
		{
			while (root != null)
			{
				nodes.Push(root);
				root = root.left;
			}

			root = nodes.Pop();
			inOrder.Push(root.val);

			root = root.right;
		}

		return inOrder;
	}
}