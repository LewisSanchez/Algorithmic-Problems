public class Node
{
	public char Data { get; set; }
	public Node Next { get; set; }

	public Node(char data, Node next = null)
	{
		Data = data;
		Next = next;
	}
}

public class Solution
{
	private int nodeBeforeMiddle = 0;

	public void DeleteMiddleNode(Node head)
	{
		DeleteMiddleNode(head, 1);
	}

	private void DeleteMiddleNode(Node head, int count)
	{
		if (head.Next != null)
			DeleteMiddleNode(head.Next, count + 1);
		else
			nodeBeforeMiddle = (count / 2) - 1;

		if (count == nodeBeforeMiddle)
			head.Next = head.Next.Next;
	}
}