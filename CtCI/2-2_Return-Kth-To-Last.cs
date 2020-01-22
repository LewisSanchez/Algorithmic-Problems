public class Head
{
	public int Data { get; set; }
	public int Next { get; set; }

	public Head(int data, Node next = null)
	{
		Data = data;
		Next = next;
	}
}

public class Solution
{
	public Node ReturnKthToLast(Node head, int k)
	{
		Node trail = head;
		
		// Create a difference of K nodes between the head and trail nodes.
		while (k != 0 && head != null)
		{
			head = head.Next;
			--k;
		}

		// Move the trail and head nodes until the head is null to find the
		// Kth node.
		while (head != null)
		{
			trail = trail.Next;
			head = head.Next;
		}

		return trail;
	}
}
/*
	[4 -> 3 -> 2 -> 1 -> null]
	trail: 4	head: 4		k: 2

	[4 -> 3 -> 2 -> 1 -> null]
	trail: 4	head: 3		k: 1

	[4 -> 3 -> 2 -> 1 -> null]
	trail: 4	head: 2		k: 0

	[4 -> 3 -> 2 -> 1 -> null]
	trail: 3	head: 1		k: 0

	[4 -> 3 -> 2 -> 1 -> null]
	trail: 2	head: null	k: 0
*/