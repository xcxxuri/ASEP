namespace Assignment4
{
    internal class MyStack<T>
    {
        private T[] items;
        private int top;

        public MyStack()
        {
            items = new T[4];
            top = -1;
        }

        public int Count()
        {
            return top + 1;
        }

        public T Pop()
        {
            if (top < 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            T item = items[top];
            items[top] = default(T); // to avoid memory leaks
            top--;
            return item;
        }
        public void Push(T item)
        {
            if (top == items.Length - 1)
            {
                Array.Resize(ref items, items.Length * 2);
            }
            top++;
            items[top] = item;
        }
    }
}
