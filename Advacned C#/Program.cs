

using Advacned_C_;

internal class Program
    {
    static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
    {
        var result = new List<Product>();

        foreach (var product in products)
        {
            if (filter(product))
            {
                result.Add(product);
            }
        }

        return result;
    }
    static void PrintList<T>(string title, List<T> items, Func<T, string> format)
    {
        Console.WriteLine($"--- {title} ---");

        foreach (var item in items)
        {
            Console.WriteLine(format(item));
        }

        Console.WriteLine();
    }
    public static void Main()
    {
        List<Product> catalog = new()
        {
            new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
            new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
            new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
            new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
            new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
            new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
            new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
            new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
            new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
            new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
        };
        Func<Product, string> line = p => $"{p.Name} - ${p.Price} (Stock: {p.Stock})";

        PrintList("Electronics", SearchProducts(catalog, p => p.Category == "Electronics"), line);
        PrintList("Under $50", SearchProducts(catalog, p => p.Price < 50), line);
        PrintList("In Stock", SearchProducts(catalog, p => p.Stock > 0), line);
        PrintList("Clothing Under $100", SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100), line);
    }
}

