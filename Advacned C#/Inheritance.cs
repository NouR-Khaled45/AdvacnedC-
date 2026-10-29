namespace Advacned_C_
{
    // Q19: inheriting from a generic class
    public class BaseRepository<T>
    {
        protected readonly List<T> Items = new List<T>();

        public virtual void Add(T item) => Items.Add(item);

        public int Count => Items.Count;
    }

   
    public class StringRepository : BaseRepository<string>
    {
        public override void Add(string item) => base.Add(item.Trim().ToUpper());

        public string Join() => string.Join(", ", Items);
    }

    
    }


