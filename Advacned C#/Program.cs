using Advanced_C_;

namespace Advacned_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q2 - Container<T>
           
            var c = new Container<string>();
            c.Add("Start");
            c.Add("Generics");
            Console.WriteLine(c.Get(0));
            Console.WriteLine(c.Get(1));
            #endregion

            #region Q3 - Pair<TKey, TValue>
           
            var age = new Pair<string, int>("Age", 25);
            var point = new Pair<int, double>(1, 3.5);
            Console.WriteLine(age);
            Console.WriteLine(point);
            #endregion

            #region Q4 - Swap<T>
           
            int x = 10, y = 20;
            GenericMethods.Swap(ref x, ref y);
            Console.WriteLine($"x = {x}, y = {y}");
            string first = "A", second = "B";
            GenericMethods.Swap(ref first, ref second);
            Console.WriteLine($"first = {first}, second = {second}");
            #endregion

            #region Q5 - FindMax<T>
          
            Console.WriteLine(GenericMethods.FindMax(3, 9, 1, 7));
            Console.WriteLine(GenericMethods.FindMax(2.5, 1.1, 8.8));
            Console.WriteLine(GenericMethods.FindMax("apple", "pear", "banana"));
            #endregion

            #region Q6 - IRepository<T>
           
            IRepository<Product> repo = new ProductRepository();
            repo.Add(new Product { Id = 1, Name = "Laptop", Price = 25000 });
            repo.Add(new Product { Id = 2, Name = "Mouse", Price = 300 });
            repo.Remove(2);
            foreach (Product p in repo.GetAll())
                Console.WriteLine(p);
            Console.WriteLine($"GetById(2): {repo.GetById(2)?.ToString() ?? "null"}");
            #endregion

            #region Q7 - struct constraint
            
            var intHolder = new ValueHolder<int> { Value = 42 };
            Console.WriteLine($"Value = {intHolder.Value}, HasOptional = {intHolder.HasOptional}");
            
            #endregion

            #region Q8 - class constraint
         
            var stringHolder = new ReferenceHolder<string>();
            Console.WriteLine($"IsEmpty = {stringHolder.IsEmpty}");
            stringHolder.Item = "Now filled";
            Console.WriteLine($"IsEmpty = {stringHolder.IsEmpty}, Item = {stringHolder.Item}");
        
            #endregion

            #region Q9 - new() constraint
         
            var productFactory = new Factory<Product>();
            Product created = productFactory.Create();
            Console.WriteLine($"Created product with Id = {created.Id}, Name = '{created.Name}'");
            #endregion

            #region Q10 - interface constraint
           
            new ShapePrinter<Circle>().Print(new Circle { Radius = 2 });
            new ShapePrinter<Square>().Print(new Square { Side = 3 });
            #endregion

            #region Q11 - base class constraint
        
            var shelter = new AnimalShelter<Animal>();
            shelter.Admit(new Dog());
            shelter.Admit(new Cat());
            shelter.MakeNoise();
            #endregion

            #region Q12 - multiple constraints
            
            new ShapeFactory<Circle>().CreateAndPrint();
            ConstraintHelpers.Convert<int, Product>(5);
            #endregion

            #region Q13 / Q14 - default and SafeList<T>
           
            
            var numbers = new SafeList<int>();
            numbers.Add(5);
            numbers.Add(10);
            Console.WriteLine($"numbers[1] = {numbers[1]}, numbers[99] = {numbers[99]}");
            var names = new SafeList<string>();
            names.Add("Ali");
            Console.WriteLine($"names[0] = {names[0]}, names[-1] = {names[-1] ?? "null"}");
            #endregion

            #region Q15 - covariance (out)
           
            IProducer<Dog> dogProducer = new DogProducer();
            IProducer<Animal> animalProducer = dogProducer;   // allowed because of 'out'
            Console.WriteLine($"Produced: {animalProducer.Produce().Name}");
            
            #endregion

            #region Q16 - contravariance (in)
           
            IConsumer<Animal> animalConsumer = new AnimalConsumer();
            IConsumer<Dog> dogConsumer = animalConsumer;      // allowed because of 'in'
            dogConsumer.Consume(new Dog());
            Action<Animal> describe = a => Console.WriteLine($"Action<in T>: {a.Name}");
            Action<Cat> describeCat = describe;
            describeCat(new Cat());
            #endregion

            #region Q18 - static members in generic types
            
            new Counter<int>();
            new Counter<int>();
            new Counter<string>();
            Console.WriteLine($"Counter<int>.InstanceCount = {Counter<int>.InstanceCount}");
            Console.WriteLine($"Counter<string>.InstanceCount = {Counter<string>.InstanceCount}");
            #endregion

            #region Q19 - generic inheritance
            
            var stringRepo = new StringRepository();
            stringRepo.Add("  hello ");
            stringRepo.Add("world");
            Console.WriteLine(stringRepo.Join());
           
            #endregion

            #region Q20 - Cache<TKey, TValue>

            var cache = new Cache<string, string>();

            cache.Add("name", "Ahmed");
            cache.Add("token", "abc123", TimeSpan.FromSeconds(1));

            Console.WriteLine(cache.Get("name"));       // Ahmed
            Console.WriteLine(cache.Contains("token")); // True

            Thread.Sleep(1500);
            Console.WriteLine(cache.Contains("token")); // False (expired)

            cache.Remove("name");
            Console.WriteLine(cache.Count);             // 0
            #endregion
        }

        
    }
}