namespace simply_connected_list
{
	public class Node
	{
		public int id { get; set; }
		public int value { get; set; }
		public Node? next { get; set; }

		public Node()
		{
			id = 0;
			value = 0;
			next = null;
		}

		public Node(int id, int value, Node next)
		{
			this.id = id;
			this.value = value;
			this.next = next;
		}

		public Node(int id, int value)
		{
			this.id = id;
			this.value = value;
			next = null;
		}

		public static void print(Node node)
		{
            Console.Write($"{node.id}:{node.value} -> ");
        }

		public static Node incId(Node node)
		{
			Node p = node;
			while (p.next is not null)
			{
                p.id += 1;
                p = p.next;
			}

			return p;
		}
	}
}

