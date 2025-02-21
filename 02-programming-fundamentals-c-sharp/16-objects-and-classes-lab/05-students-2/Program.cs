using System;
namespace _05Students2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split();
                string firstName = arguments[0];
                string lastName = arguments[1];
                string age = arguments[2];
                string homeTown = arguments[3];

                Student student = new Student(firstName, lastName, age, homeTown);

                int index = IndexValid(firstName, lastName, students);
                if (index != -1)
                {
                    students[index].Age = age;
                    students[index].HomeTown = homeTown;
                    continue;
                }

                students.Add(student);
            }

            string town = Console.ReadLine();

            foreach (Student student in students)
            {
                if (town == student.HomeTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        static int IndexValid(string firstName, string lastName, List<Student> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FirstName == firstName && list[i].LastName == lastName)
                {
                    return i;
                }
            }
            return -1;
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