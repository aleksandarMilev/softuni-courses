using System;

namespace Person.Models
{
    public class Person
    {
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }


        public string Name { get; set; }
        public virtual int Age
        {
            get => age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Age)} can not be zero or negative value!");
                }

                age = value;
            }
        }


        public override string ToString()
            => $"Name: {Name}, Age: {Age}";
    }
}
