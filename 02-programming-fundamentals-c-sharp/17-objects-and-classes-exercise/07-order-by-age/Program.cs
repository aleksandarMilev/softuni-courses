using System;
using System.Collections.Generic;
namespace _07OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> pList = new List<Person>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] info = command.Split();
                string name = info[0];
                string id = info[1];
                int age = int.Parse(info[2]);

                Person person = new Person();
                person.Name = name;
                person.ID = id;
                person.Age = age;

                Person eqalPerson = pList.Find(x => x.ID == id);
                if (eqalPerson is not null)
                {
                    person.Name = name;
                    person.Age = age;
                }

                pList.Add(person);
            }

            var orderedList = pList.OrderBy(a => a.Age).ToList();

            orderedList.ForEach(p => Console.WriteLine(p));
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}