// Solution to: https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/
public class Solution
{
	public int CountComponents(int n, int[][] edges)
	{
		var count = 0;
		var visitedNodes = new List<bool>(n);
		var adjNodes = new List<List<int>>(n);
		var nodes = new Stack<int>();

		for (var i = 0; i < n; ++i)
		{
			visitedNodes.Add(false);
			adjNodes.Add(new List<int>());
		}

		foreach (var edge in edges)
		{
			var from = edge[0];
			var to = edge[1];

			adjNodes[from].Add(to);
			adjNodes[to].Add(from);
		}

		for (var node = 0; node < n; ++node)
		{
			if (!visitedNodes[node])
			{
				++count;
				nodes.Push(node);

				while (nodes.Count != 0)
				{
					var curNode = nodes.Pop();
					visitedNodes[curNode] = true;
					var neighbors = adjNodes[curNode];

					foreach (var neighbor in neighbors)
					{
						if (!visitedNodes[neighbor])
							nodes.Push(neighbor);
					}
				}
			}
		}
		return count;
	}
}