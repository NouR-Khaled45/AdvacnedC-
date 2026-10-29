namespace Advanced_C_
{
    // Q2: generic container with Add and Get
    public class Container<T>
    {
        private readonly List<T> _items = new List<T>();

        public int Count => _items.Count;

        public void Add(T item)
        {
            _items.Add(item);
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _items.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

            return _items[index];
        }
    }
}
