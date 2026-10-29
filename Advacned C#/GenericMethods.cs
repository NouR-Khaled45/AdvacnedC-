namespace Advacned_C_
{
    public static class GenericMethods
    {
        // Q4: swaps two values of any type
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        // Q5: T must be comparable so we can use CompareTo
        public static T FindMax<T>(params T[] items) where T : IComparable<T>
        {
            if (items == null || items.Length == 0)
                throw new ArgumentException("At least one item is required.", nameof(items));

            T max = items[0];
            foreach (T item in items)
            {
                if (item.CompareTo(max) > 0)
                    max = item;
            }
            return max;
        }
    }
}
