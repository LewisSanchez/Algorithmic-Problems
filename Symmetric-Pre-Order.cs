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
	public bool IsSymmetric(TreeNode root)
	{
		var preOrder = new List<int>();

		PreOrder(preOrder, root);
		var symmetricPreOrder = SymmetricPreOrder(root);

		if (preOrder.Count != symmetricPreOrder.Count)
			return false;

		for (int i = 0; i < preOrder.Count; ++i)
		{
			if (preOrder[i] != symmetricPreOrder[i])
				return false;
		}

		return true;
	}

	private void PreOrder(List<int> preOrder, TreeNode root)
	{
		if (root == null)
			return;

		preOrder.Add(root.val);

		if (root.left != null)
			PreOrder(preOrder, root.left);
		else
			preOrder.Add(Int32.MinValue);

		if (root.right != null)
			PreOrder(preOrder, root.right);
		else
			preOrder.Add(Int32.MinValue);
	}

	private List<int> SymmetricPreOrder(TreeNode root)
	{
		var symmetricPre = new List<int>();
		var nodes = new Stack<TreeNode>();

		if (root == null)
			return symmetricPre;

		nodes.Push(root);

		while (nodes.Count != 0)
		{
			var cur = nodes.Pop();

			if (cur != null)
			{
				symmetricPre.Add(cur.val);
				nodes.Push(cur.left);
				nodes.Push(cur.right);
			}
			else
				symmetricPre.Add(Int32.MinValue);
		}

		return symmetricPre;
	}
}