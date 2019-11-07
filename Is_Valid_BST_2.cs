// improved solution to: https://leetcode.com/problems/validate-binary-search-tree/
// because it doesn't make use of a list
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
	public bool IsValidBST(TreeNode root)
	{
		TreeNode prev = null;
		Stack<TreeNode> nodes = new Stack<TreeNode>();

		while (root != null || nodes.Count != 0)
		{
			while (root != null)
			{
				nodes.Push(root);
				root = root.left;
			}
            
			root = nodes.Pop();

			if (prev != null && prev.val >= root.val)
				return false;

			prev = root;
			root = root.right;
		}

		return true;
	}
}