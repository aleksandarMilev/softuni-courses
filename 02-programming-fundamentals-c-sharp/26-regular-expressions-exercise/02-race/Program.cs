using System;
using System.Text;
using System.Text.RegularExpressions;
namespace _02Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] namesArr = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Person> personsList = new List<Person>();

            for (int i = 0; i < namesArr.Length; i++)
            {
                Person person = new Person();
                person.Name = namesArr[i];
                person.Distance = 0;
                personsList.Add(person);
            }

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                StringBuilder name = new StringBuilder();
                string namePattern = @"[A-Za-z]";

                foreach (Match match in Regex.Matches(input, namePattern))
                {
                    name.Append(match.Value);
                }

                string digitsPattern = @"\d";
                int distance = 0;

                foreach (Match match in Regex.Matches(input, digitsPattern))
                {
                    distance += int.Parse(match.Value);
                }

                Person foundPerson = personsList.FirstOrDefault(n => n.Name == name.ToString());
                if (foundPerson is not null)
                {
                    foundPerson.Distance += distance;
                }
            }

            List<Person> orderedList = personsList
                .OrderByDescending(d => d.Distance)
                .Take(3)
                .ToList();

            if (orderedList.Count >= 3)
            {
                Console.WriteLine($"1st place: {orderedList[0].Name}");
                Console.WriteLine($"2nd place: {orderedList[1].Name}");
                Console.WriteLine($"3rd place: {orderedList[2].Name}");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Distance { get; set; }
    }
}