// Basic Node definition
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
	public void RemoveDups(Node head)
	{
		Node prev = null;
		var processedValues = new List<int>();

		while (head != null)
		{
			// If a duplicate doesn't exist, add the value to the list of processed
			// values, set the previous node to the current head node and move the
			// head to the next node. Otherwise, skip the duplicate and move
			// the head to the next node.
			if (!processedValues.Contains(head.Data))
			{
				processedValues.Add(head.Data);
				prev = head;
			}
			else
				prev.Next = head.Next;

			head = head.Next;
		}
	}
}
/*
	[5 -> 4 -> 5 -> 3 -> null]

	prev: null -> 5		head: 5	-> 4		processedValues: [5]


	[5 -> 4 -> 5 -> 3 -> null]

	prev: 5 -> 4		head: 4 -> 5		processedValues: [5, 4]


	[5 -> 4 -> 5 -> 3 -> null] -> [5 -> 4 -> 3 -> null]

	prev: 4			head: 5 -> 3		processedValues: [5, 4]


	[5 -> 4 -> 3 -> null]

	prev: 4 -> 3		head: 3 -> null		processedValues: [5, 4, 3]
*/