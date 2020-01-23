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
	public Node SumLists(Node list1, Node list2, int carry)
	{
		if (list1 == null && list2 == null && carry == 0)
			return null;

		var firstVal = list1 != null ? list1.Data : 0;
		var secondVal = list2 != null ? list2.Data : 0;

		var total = firstVal + secondVal + carry;
		var remainder = total % 10;
		var carry = total / 10;

		var result = new Node(remainder);

		if (list1 != null || list2 != null)
		{
			var nextResult = SumLists(list1 != null ? list1.Next : null,
						list2 != null ? list2.Next : null,
						carry);

			result.Next = nextResult;
		}

		return result;
	}
}