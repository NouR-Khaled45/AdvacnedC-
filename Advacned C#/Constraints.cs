namespace Advacned_C_
{
    // Q7: struct constraint - T must be a non-nullable value type (int, double, DateTime, ...)
    public class ValueHolder<T> where T : struct
    {
        public T Value { get; set; }
        public T? Optional { get; set; }   // T? is Nullable<T> here because T is a struct

        public bool HasOptional => Optional.HasValue;
    }

    // Q8: class constraint - T must be a reference type
    public class ReferenceHolder<T> where T : class
    {
        public T? Item { get; set; }

        public bool IsEmpty => Item == null;   // comparing to null is allowed for reference types
    }

    // Q9: new() constraint - T must have a public parameterless constructor
    public class Factory<T> where T : new()
    {
        public T Create() => new T();
    }

    // Q10: interface constraint - T must implement IShape
    public interface IShape
    {
        double Area();
        string Name { get; }
    }

    public class Circle : IShape
    {
        public double Radius { get; set; } = 1;
        public string Name => "Circle";
        public double Area() => Math.PI * Radius * Radius;
    }

    public class Square : IShape
    {
        public double Side { get; set; } = 1;
        public string Name => "Square";
        public double Area() => Side * Side;
    }

    public class ShapePrinter<T> where T : IShape
    {
        public void Print(T shape) => Console.WriteLine($"{shape.Name} area = {shape.Area():F2}");
    }

    // Q11: base class constraint - T must be Animal or derive from it
    public class Animal
    {
        public string Name { get; set; } = "Animal";
        public virtual string Speak() => "...";
    }

    public class Dog : Animal
    {
        public Dog() { Name = "Dog"; }
        public override string Speak() => "Woof";
    }

    public class Cat : Animal
    {
        public Cat() { Name = "Cat"; }
        public override string Speak() => "Meow";
    }

    public class AnimalShelter<T> where T : Animal
    {
        private readonly List<T> _animals = new List<T>();

        public void Admit(T animal) => _animals.Add(animal);

        public void MakeNoise()
        {
            foreach (T animal in _animals)
                Console.WriteLine($"{animal.Name}: {animal.Speak()}");
        }
    }

    // Q12: multiple constraints - order is: class/struct/base class, then interfaces, then new() last
    public class ShapeFactory<T> where T : class, IShape, new()
    {
        public T CreateAndPrint()
        {
            T shape = new T();
            Console.WriteLine($"Created {shape.Name} with area {shape.Area():F2}");
            return shape;
        }
    }

    // Multiple constraints on multiple type parameters
    public static class ConstraintHelpers
    {
        public static TOut Convert<TIn, TOut>(TIn input)
            where TIn : struct, IComparable<TIn>
            where TOut : class, new()
        {
            Console.WriteLine($"Converting {input} to a new {typeof(TOut).Name}");
            return new TOut();
        }
    }
}
