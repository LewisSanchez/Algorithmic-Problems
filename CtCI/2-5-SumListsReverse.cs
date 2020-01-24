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
	public Node SumLists(Node list1, Node list2)
	{
		Node result = null;

		var len1 = Length(list1);
		var len2 = Length(list2);
		if (len1 > len2)
			PadList(ref list2, len1 - len2);
		else
			PadList(ref list1, len2 - len1);

		var carry = SumLists(list1, list2, ref result);

		if (carry != 0)
		{
			var newHead = new Node(carry, result);
			result = newHead;
		}
s
		return result;
	}

	private int Length(Node list)
	{
		int count = 0;

		while (list != null)
		{
			list = list.Next;
			count++;
		}

		return count;
	}

	private void PadList(ref Node list, int length)
	{
		while (length != 0)
		{
			var pad = new Node(0, list);
			list = pad;
			length--;
		}
	}

	private int SumLists(Node list1, Node list2, ref Node result)
	{
		if (list1 == null && list2 == null)
			return 0;

		
		var carry = SumLists(list1 != null ? list1.Next : null,
					list2 != null ? list2.Next : null,
					ref result);

		var firstVal = list1 != null ? list1.Data : 0;
		var secondVal = list2 != null ? list2.Data : 0;
		var total = firstVal + secondVal + carry;
		var remainder = total % 10;
		var carry = total / 10;

		if (result == null)
			result = new Node(remainder);
		else
		{
			var newHead = new Node(remainder, result);
			result = newHead;   
		}

		return carry;
	}
}