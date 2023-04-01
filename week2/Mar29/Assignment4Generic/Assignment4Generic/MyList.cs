namespace Assignment4
{
    internal class MyList<T>
    {
        private T[] items;
        private int count;

        public MyList()
        {
            items = new T[4];
            count = 0;
        }

        public void Add(T element)
        {
            if (count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
            items[count] = element;
            count++;
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            T element = items[index];
            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            count--;
            return element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            items = new T[4];
            count = 0;
        }

        public void InsertAt(T element, int index)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            if (count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
            for (int i = count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
            items[index] = element;
            count++;
        }

        public void DeleteAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            count--;
        }

        public T Find(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            return items[index];
        }
    }
}
