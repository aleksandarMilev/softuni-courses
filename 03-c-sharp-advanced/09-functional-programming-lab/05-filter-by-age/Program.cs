using System.Threading.Channels;

namespace _05FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new();
            int inputsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputsCount; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = arguments[0];
                int age = int.Parse(arguments[1]);

                people.Add(new(name, age));
            }

            string filterType = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string formatType = Console.ReadLine();

            Func<Person, bool> filter = GetFilter(filterType, ageFilter);
            people = people.Where(filter).ToList();

            Action<Person> printer = GetPrinter(formatType);

            foreach (var person in people)
            {
                printer(person);
            }
        }

        static Func<Person, bool> GetFilter(string filterType, int agefilter)
        {
            switch (filterType)
            {
                case "younger":
                    return p => p.Age < agefilter;
                case "older":
                    return p => p.Age >= agefilter;
                default:
                    return default;
            }
        }

        static Action<Person> GetPrinter(string formatType)
        {
            switch (formatType)
            {
                case "name age":
                    return p => Console.WriteLine($"{p.Name} - {p.Age}");
                case "name":
                    return p => Console.WriteLine($"{p.Name}");
                case "age":
                    return p => Console.WriteLine($"{p.Age}");
                default:
                    return default;
            }
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}