﻿namespace _05ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }


        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        
        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result != 0)
            {
                return result;
            }

            result = Age.CompareTo(other.Age);
            if (result != 0)
            {
                return result;
            }

            return Town.CompareTo(other.Town);
        }
    }
}
