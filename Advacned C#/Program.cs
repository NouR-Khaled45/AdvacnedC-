namespace Advacned_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Q2: Container<T>
            Title("Q2 - Container<T>");
            var c = new Container<string>();
            c.Add("Hello");
            c.Add("Generics");
            Console.WriteLine(c.Get(0));
            Console.WriteLine(c.Get(1));

            // Q3: Pair<TKey, TValue>
            Title("Q3 - Pair<TKey, TValue>");
            var age = new Pair<string, int>("Age", 25);
            var point = new Pair<int, double>(1, 3.5);
            Console.WriteLine(age);
            Console.WriteLine(point);

            // Q4: Swap<T>
            Title("Q4 - Swap<T>");
            int x = 10, y = 20;
            GenericMethods.Swap(ref x, ref y);
            Console.WriteLine($"x = {x}, y = {y}");
            string first = "A", second = "B";
            GenericMethods.Swap(ref first, ref second);
            Console.WriteLine($"first = {first}, second = {second}");

            // Q5: FindMax<T>
            Title("Q5 - FindMax<T>");
            Console.WriteLine(GenericMethods.FindMax(3, 9, 1, 7));
            Console.WriteLine(GenericMethods.FindMax(2.5, 1.1, 8.8));
            Console.WriteLine(GenericMethods.FindMax("apple", "pear", "banana"));

            // Q6: IRepository<T>
            Title("Q6 - IRepository<T>");
            IRepository<Product> repo = new ProductRepository();
            repo.Add(new Product { Id = 1, Name = "Laptop", Price = 25000 });
            repo.Add(new Product { Id = 2, Name = "Mouse", Price = 300 });
            repo.Remove(2);
            foreach (Product p in repo.GetAll())
                Console.WriteLine(p);
            Console.WriteLine($"GetById(2): {repo.GetById(2)?.ToString() ?? "null"}");

            // Q7: struct constraint
            Title("Q7 - struct constraint");
            var intHolder = new ValueHolder<int> { Value = 42 };
            Console.WriteLine($"Value = {intHolder.Value}, HasOptional = {intHolder.HasOptional}");
            // var bad = new ValueHolder<string>();   // compile error: string is not a struct

            // Q8: class constraint
            Title("Q8 - class constraint");
            var stringHolder = new ReferenceHolder<string>();
            Console.WriteLine($"IsEmpty = {stringHolder.IsEmpty}");
            stringHolder.Item = "Now filled";
            Console.WriteLine($"IsEmpty = {stringHolder.IsEmpty}, Item = {stringHolder.Item}");
            // var bad = new ReferenceHolder<int>();   // compile error: int is not a reference type

            // Q9: new() constraint
            Title("Q9 - new() constraint");
            var productFactory = new Factory<Product>();
            Product created = productFactory.Create();
            Console.WriteLine($"Created product with Id = {created.Id}, Name = '{created.Name}'");

            // Q10: interface constraint
            Title("Q10 - interface constraint");
            new ShapePrinter<Circle>().Print(new Circle { Radius = 2 });
            new ShapePrinter<Square>().Print(new Square { Side = 3 });

            // Q11: base class constraint
            Title("Q11 - base class constraint");
            var shelter = new AnimalShelter<Animal>();
            shelter.Admit(new Dog());
            shelter.Admit(new Cat());
            shelter.MakeNoise();

            // Q12: multiple constraints
            Title("Q12 - multiple constraints");
            new ShapeFactory<Circle>().CreateAndPrint();
            ConstraintHelpers.Convert<int, Product>(5);

            // Q13 / Q14: default + SafeList<T>
            Title("Q13/Q14 - default and SafeList<T>");
            Console.WriteLine($"default(int) = {default(int)}, default(bool) = {default(bool)}, default(string) = {default(string) ?? "null"}");
            var numbers = new SafeList<int>();
            numbers.Add(5);
            numbers.Add(10);
            Console.WriteLine($"numbers[1] = {numbers[1]}, numbers[99] = {numbers[99]}");
            var names = new SafeList<string>();
            names.Add("Ali");
            Console.WriteLine($"names[0] = {names[0]}, names[-1] = {names[-1] ?? "null"}");

            // Q15: covariance
            Title("Q15 - covariance (out)");
            IProducer<Dog> dogProducer = new DogProducer();
            IProducer<Animal> animalProducer = dogProducer;   // allowed because of 'out'
            Console.WriteLine($"Produced: {animalProducer.Produce().Name}");
            IEnumerable<object> objects = new List<string> { "IEnumerable<out T> is covariant" };
            Console.WriteLine(objects.First());

            // Q16: contravariance
            Title("Q16 - contravariance (in)");
            IConsumer<Animal> animalConsumer = new AnimalConsumer();
            IConsumer<Dog> dogConsumer = animalConsumer;      // allowed because of 'in'
            dogConsumer.Consume(new Dog());
            Action<Animal> describe = a => Console.WriteLine($"Action<in T>: {a.Name}");
            Action<Cat> describeCat = describe;
            describeCat(new Cat());

            // Q18: static members in generic types
            Title("Q18 - static members");
            new Counter<int>();
            new Counter<int>();
            new Counter<string>();
            Console.WriteLine($"Counter<int>.InstanceCount = {Counter<int>.InstanceCount}");
            Console.WriteLine($"Counter<string>.InstanceCount = {Counter<string>.InstanceCount}");

            // Q19: inheriting from a generic class
            Title("Q19 - generic inheritance");
            var stringRepo = new StringRepository();
            stringRepo.Add("  hello ");
            stringRepo.Add("world");
            Console.WriteLine(stringRepo.Join());
            var logRepo = new LoggingRepository<double>();
            logRepo.Add(3.14);
            var keyed = new KeyedRepository<string, int>();
            keyed.Add("one", 1);
            Console.WriteLine($"Find(\"one\") = {keyed.Find("one")}, Count = {keyed.Count}");

            // Q20: Cache<TKey, TValue>
            Title("Q20 - Cache<TKey, TValue>");
            var cache = new Cache<string, string>(defaultExpiration: TimeSpan.FromMinutes(10));
            cache.Add("user:1", "Ahmed");
            cache.Add("token", "abc123", TimeSpan.FromMilliseconds(500));
            Console.WriteLine($"Get(user:1) = {cache.Get("user:1")}");
            Console.WriteLine($"Contains(token) = {cache.Contains("token")}");
            Thread.Sleep(600);
            Console.WriteLine($"After 600ms, Contains(token) = {cache.Contains("token")}");
            Console.WriteLine($"Remove(user:1) = {cache.Remove("user:1")}, Contains(user:1) = {cache.Contains("user:1")}");
            Console.WriteLine($"Get(missing) = {cache.Get("missing") ?? "null"}, Count = {cache.Count}");
        }

        static void Title(string text)
        {
            Console.WriteLine();
            Console.WriteLine($"===== {text} =====");
        }
    }
}
