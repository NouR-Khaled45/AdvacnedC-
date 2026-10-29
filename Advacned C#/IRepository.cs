namespace Advacned_C_
{
    // Q6: a generic interface
    public interface IRepository<T>
    {
        void Add(T item);
        T? GetById(int id);
        IEnumerable<T> GetAll();
        bool Remove(int id);
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }

        public override string ToString() => $"#{Id} {Name} ({Price})";
    }

    public class ProductRepository : IRepository<Product>
    {
        private readonly List<Product> _products = new List<Product>();

        public void Add(Product item) => _products.Add(item);

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Product> GetAll() => _products;

        public bool Remove(int id)
        {
            Product? product = GetById(id);
            return product != null && _products.Remove(product);
        }
    }
}
