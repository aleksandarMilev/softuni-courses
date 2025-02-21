namespace _05ComparingObjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] arguments = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = arguments[0];
                int age = int.Parse(arguments[1]);
                string town = arguments[2];

                people.Add(new(name, age, town));
            }

            int comparableIndex = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = people[comparableIndex];

            int equalCount = 0;
            int differentCount = 0;

            foreach (Person person in people)
            {
                if (personToCompare.CompareTo(person) == 0)
                {
                    equalCount++;
                }
                else
                {
                    differentCount++;
                }
            }

            if (equalCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {differentCount} {people.Count}");
            }
        }
    }
}
