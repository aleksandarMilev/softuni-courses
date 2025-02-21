using System;
namespace _04Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split();
                string firstName = arguments[0];
                string lastName = arguments[1];
                string age = arguments[2];
                string homeTown = arguments[3];

                Student student = new Student(firstName, lastName, age, homeTown);
                list.Add(student);
            }

            string town = Console.ReadLine();

            foreach (Student student in list)
            {
                if (town == student.HomeTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    public class Student
    {
        public Student(string firstName, string lastName, string age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Age { get; set; }

        public string HomeTown { get; set; }
    }
}