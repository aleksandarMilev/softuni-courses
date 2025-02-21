namespace _06EqualityLogic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<Person> hashSet = new();
            SortedSet<Person> sortedSet = new();

            int peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = arguments[0];
                int age = int.Parse(arguments[1]);

                hashSet.Add(new(name, age));
                sortedSet.Add(new(name, age));
            }

            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);
        }
    }
}
