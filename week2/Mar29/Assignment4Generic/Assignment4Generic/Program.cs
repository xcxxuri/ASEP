namespace Assignment4
{

    public class Program
    {
        public static void Main()
        {

            // MyStack
            MyStack<int> stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine("MyStack");
            Console.WriteLine("Count: " + stack.Count());
            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine("Count: " + stack.Count());


            // MyList
            MyList<int> list = new MyList<int>();
            // Add
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            // InsertAt
            list.InsertAt(5, 0);
            list.InsertAt(6, 2);
            Console.WriteLine("MyList");
            // Remove
            Console.WriteLine("Remove 2: " + list.Remove(2));
            Console.WriteLine("Remove 0: " + list.Remove(0));
            // DeleteAt
            list.DeleteAt(0);
            // Remove
            list.Remove(2);
            // Contains
            Console.WriteLine("Contains 0: " + list.Contains(0));
            Console.WriteLine("Contains 6: " + list.Contains(6));
            // Clear
            list.Clear();
            Console.WriteLine("Contains 3: " + list.Contains(3));


        }
    }

}

