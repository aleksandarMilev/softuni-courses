using System;

namespace People.Models
{
    public class Person
    {
        private const int FirstAndLastNameMinimumLength = 3;

        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firsName, string lastName, int age, decimal salary)
        {
            FirstName = firsName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }


        public string FirstName
        {
            get => firstName;
            private set
            {
                if (value.Length < FirstAndLastNameMinimumLength)
                {
                    throw new ArgumentException($"{nameof(FirstName)} cannot contains fewer than {FirstAndLastNameMinimumLength} symbols!");
                }

                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            private set
            {
                if (value.Length < FirstAndLastNameMinimumLength)
                {
                    throw new ArgumentException($"{nameof(LastName)} cannot contains fewer than {FirstAndLastNameMinimumLength} symbols!");
                }

                lastName = value;
            }
        }
        public int Age
        {
            get => age;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Age)} value cannot be zero or negative!");
                }

                age = value;
            }
        }
        public decimal Salary
        {
            get => salary;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(Salary)} cannot be less than 0 leva!");
                }

                salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                Salary += Salary * percentage / 200;
            }
            else
            {
                Salary += Salary * percentage / 100;
            }
        }

        public override string ToString()
            => $"{FirstName} {LastName} receives {Salary:f2} leva.";
    }
}
