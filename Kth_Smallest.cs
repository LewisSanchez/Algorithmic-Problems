// SOlution to https://leetcode.com/problems/kth-smallest-element-in-a-bst/
/**
* Definition for a binary tree node
* public class TreeNode {
* 	public int val;
*	public TreeNode left;
*	public TreeNode right;
*	public TreeNode(int x) { val = x; }
* }
*/
public class Solution
{
	public int KthSmallest(TreeNode root, int k)
	{
		int kthValue = -1;
		Stack<TreeNode> nodes = new Stack<TreeNode>();

		while (root != null || nodes.Count != 0 && k != 0)
		{
			while (root != null)
			{
				nodes.Push(root);
				root = root.left;
			}

			root = nodes.Pop();
			if (--k == 0)
				kthValue = root.val;
				
			root = root.right;
		}
		return kthValue;
	}
}