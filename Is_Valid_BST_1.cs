// First attempt solution to: https://leetcode.com/problems/validate-binary-search-tree/
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
		bool isValid = true;
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
			inOrder.Add(root.val);
			root = root.right;
		}

		for (int i = 1; i < inOrder.Count; ++i)
		{
			if (inOrder[i -1] >= inOrder[i])
				isValid = false;
		}
        
		return isValid;
	}
}