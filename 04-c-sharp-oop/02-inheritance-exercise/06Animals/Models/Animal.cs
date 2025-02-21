using System;

namespace Animals.Models
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(Name)} can not be null or white space!");
                }

                name = value;
            }
        }
        public int Age
        {
            get => age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Age)} can not be zero or negative!");
                }

                age = value;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(Gender)} can not be null or white space!");
                }

                gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
            => $"{Name} {Age} {Gender}{Environment.NewLine}{ProduceSound()}";
    }
}
