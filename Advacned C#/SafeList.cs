namespace Advacned_C_
{
    
    public class SafeList<T>
    {
        private readonly List<T> _items = new List<T>();

        public int Count => _items.Count;

        public void Add(T item) => _items.Add(item);

        public T? Get(int index)
        {
            if (index < 0 || index >= _items.Count)
                return default;   // 0 for int, null for string/classes, false for bool ...

            return _items[index];
        }

        public T? this[int index] => Get(index);
    }
}
