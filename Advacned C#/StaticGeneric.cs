namespace Advacned_C_
{
    // Q18: every closed type (Counter<int>, Counter<string>, ...) gets its OWN copy of static members
    public class Counter<T>
    {
        public static int InstanceCount { get; private set; }

        static Counter()
        {
            // the static constructor also runs once per closed type
            Console.WriteLine($"Static constructor <{typeof(T).Name}>");
        }

        public Counter()
        {
            InstanceCount++;
        }
    }
}
