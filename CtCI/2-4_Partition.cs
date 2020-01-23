public class Node
{
	public int Data { get; set; }
	public Node Next { get; set; }

	public Node(int data, Node next = null)
	{
		Data = data;
		Next = next;
	}
}

public class Solution
{
	public Node Partition(Node head, int partition)
	{
		// Return immediately if head is null
		if (head == null)
			return null;

		/*
		 Initialize the partitioned head with a deep copy of the head in
		 the original linked list and move on to the next unvisited node
		 in the original list.
		*/
		var paritionedHead = new Node(head.Data);
		head = head.Next;

		/*
		 Traverse the original list while appending or prepending nodes to the
		 the partitioned list.
		*/
		while (head != null)
		{
			if (head.Data >= partition)
				Append(partitionedHead, head);
			else
				partitionedHead = Prepend(partitionedHead, head);

			head = head.Next;
		}

		return partitionedHead;
	}

	private void Append(Node partitionedHead, Node head)
	{
		while (partitionedHead.Next != null)
			partitionedHead = partitionedHead.Next;

		partitionedHead.Next = new Node(head.Data);
	}

	private Node Prepend(Node partitionedHead, Node head)
	{
		var newHead = new Node(head.Data, partitionedHead);
		return newHead;
	}
}

/*
Case where head is [3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 -> null]

	head: [3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 -> null]
	partitionedHead: [3 -> null]

	head: [5 -> 8 -> 5 -> 10 -> 2 -> 1 -> null]
	partitionedHead: [3 -> 5 -> null]

	head: [8 -> 5 -> 10 -> 2 -> 1 -> null]
	partitionedHead: [3 -> 5 -> 8 -> null]

	head: [5 -> 10 -> 2 -> 1 -> null]
	partitionedHead: [3 -> 5 -> 8 -> 5 -> null]

	head: [10 -> 2 -> 1 -> null]
	partitionedHead: [3 -> 5 -> 8 -> 5 -> 10 -> null]

	head: [2 -> 1 -> null]
	partitionedHead: [2 -> 3 -> 5 -> 8 -> 5 -> 10 -> null]

	head: [1 -> null]
	partitionedHead: [1 -> 2 -> 3 -> 5 -> 8 -> 5 -> 10 -> null]

	head: [null]
	partitionedHead: [1 -> 2 -> 3 -> 5 -> 8 -> 5 -> 10 -> null]

Output: partitionedHead: [1 -> 2 -> 3 -> 5 -> 8 -> 5 -> 10 -> null]


Case where head is [null]

Output: [null]
*/