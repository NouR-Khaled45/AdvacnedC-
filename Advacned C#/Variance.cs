namespace Advacned_C_
{
    // Q15: covariance - 'out' means T is only returned (output position)
    // so IProducer<Dog> can be used as IProducer<Animal>
    public interface IProducer<out T>
    {
        T Produce();
    }

    public class DogProducer : IProducer<Dog>
    {
        public Dog Produce() => new Dog();
    }

    // Q16: contravariance - 'in' means T is only accepted (input position)
    // so IConsumer<Animal> can be used as IConsumer<Dog>
    public interface IConsumer<in T>
    {
        void Consume(T item);
    }

    public class AnimalConsumer : IConsumer<Animal>
    {
        public void Consume(Animal item) => Console.WriteLine($"Feeding {item.Name}");
    }
}
