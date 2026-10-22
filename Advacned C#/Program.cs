

using Advacned_C_;

internal class Program
    {
    // ================= Task 01  =================
    // Delegate used: Func<Product, bool>
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
    // =================  Print List =================
    static void PrintList<T>(string title, List<T> items, Func<T, string> format)
    {
        Console.WriteLine($"--- {title} ---");

        foreach (var item in items)
        {
            Console.WriteLine(format(item));
        }

        Console.WriteLine();
    }
    // =================  Print Report =================
    // Delegate used: Action<Product>

    static void PrintReport<T>(List<T> items, Action<T> action)
    {
        foreach (var item in items)
        {
            action(item);
        }
    }
    static List<string> TransformProducts(List<Product> products, Func<Product, string> transform)
    {
        var result = new List<string>();
        foreach (var product in products)
            result.Add(transform(product));
        return result;
    }
    static List<Product> FilterProducts(List<Product> products, Predicate<Product> condition)
    {
        var result = new List<Product>();
        foreach (var product in products)
        {
            if (condition(product))
                result.Add(product);
        }
        return result;
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
        // --------------------------------
        Console.WriteLine("--- Short Report ---");
        PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));
        Console.WriteLine();

        Console.WriteLine("--- Detailed Report ---");
        PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));
        Console.WriteLine();
        // ----------------TransformProducts ----------------
        Console.WriteLine("--- Summary List ---");
        List<string> summaries = TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
        foreach (var summary in summaries)
            Console.WriteLine(summary);
        Console.WriteLine();
        // --------------------------------
        Console.WriteLine("--- Price Labels ---");
        List<string> labels = TransformProducts(catalog, p => p.Price > 100 ? "Expensive!" : "Affordable");

        for (int i = 0; i < catalog.Count; i++)
            Console.WriteLine($"{catalog[i].Name}: {labels[i]}");
        Console.WriteLine();

        // ---------------- FilterProducts ----------------
        Console.WriteLine("--- Low-Stock Alert ---");
        List<Product> lowStock = FilterProducts(catalog, p => p.Stock < 20);
        foreach (var product in lowStock)
            Console.WriteLine($"[LOW STOCK] {product.Name}: only {product.Stock} left!");
    }

}


