// Iterative solution to: https://leetcode.com/problems/binary-tree-postorder-traversal/
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
		Stack<TreeNode> input = new Stack<TreeNode>();
		Stack<TreeNode> output = new Stack<TreeNode>();

		if (root == null)
			return postOrder;

		input.Push(root);

		while (input.Count != 0)
		{
			root = input.Pop();
			output.Push(root);

			if (root.left != null)
				input.Push(root.left);
			if (root.right != null)
				input.Push(root.right);
		}

		while (output.Count != 0)
			postOrder.Add(output.Pop().val);

		return postOrder;
	}
}