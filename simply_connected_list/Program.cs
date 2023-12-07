namespace simply_connected_list
{
    public class Program
    {
        public static void Main()
        {
            Node head = new Node();
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("В данный момент список выглядит следующим образом: ");
                printList(head);
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Создать новый список");
                Console.WriteLine("2 - Добавить элемент в конец списка");
                Console.WriteLine("3 - Добавить элемент в произвольное место списка");
                Console.WriteLine("4 - Удалить элемент из произвольного места в списке");
                Console.WriteLine("0 - Выход");

                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '0':
                        isRunning = false;
                        break;
                    case '1':
                        Console.Clear();
                        head = new Node();
                        Console.WriteLine("Новый список создан!");
                        break;
                    case '2':
                        Console.Clear();
                        Program.addToTheEnd(head);
                        break;
                    case '3':
                        Console.Clear();
                        head = Program.addToInput(head);
                        break;
                    case '4':
                        Console.Clear();
                        head = Program.deleteFromId(head);
                        break;
                }

                Console.WriteLine("Нажмите любую кнопку чтобы выйти...");
                Console.ReadKey();
            }

        }

        public static void printList(Node head)
        {
            Node p = head;

            Node.print(p);

            while (p.next is not null)
            {
                p = p.next;
                Node.print(p);
            }

            Console.WriteLine();
        }

        public static void addToTheEnd(Node head)
        {
            Console.WriteLine("Введите значение: ");
            int value = Convert.ToInt32(Console.ReadLine());

            Node p = head;
            while (p.next is not null)
                p = p.next;

            p.next = new Node(p.id+1,value);

            Console.WriteLine($"Узел с id: {p.next.id} и значением: {p.next.value} добавлен!");
        }

        public static Node addToInput(Node head)
        {
            Console.WriteLine("Введите значение: ");
            int value = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите место: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Node new_node = new Node(id, value);

            // Если id головы меньше чем введённый id, то новый узел - и есть голова
            if (id < head.id)
            {
                new_node.next = head;
                return new_node;
            }

            // иначе находим подходящий узел
            Node p = head;

            while (p.next is not null && p.next.id < id)
                p = p.next;

            new_node.next = p.next;
            p.next = new_node;

            return head;
        }

        public static Node deleteFromId(Node head)
        {
            Console.WriteLine("Введите место: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (head.id == id)
            {
                if (head.next is null)
                {
                    Console.WriteLine("Список был уничтожен!");
                    head = new Node();
                    return head;
                }
                else
                    return head.next;
            }

            Node p = head;
            while (p.next is not null && p.next.id != id)
                p = p.next;

            if (p.next is not null)
                p.next = p.next.next;

            return head;
        }
    }
}