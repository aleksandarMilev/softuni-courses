using System;

namespace Person.Models
{
    public class Child : Person
    {
        private const int ChildMaxAge = 15;

        public Child(string name, int age)
            : base(name, age)
        {
        }

        public override int Age
        {
            get => base.Age;
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException($"{nameof(Age)} can not be greater than {ChildMaxAge}!");
                }

                base.Age = value;
            }
        }
    }
}
