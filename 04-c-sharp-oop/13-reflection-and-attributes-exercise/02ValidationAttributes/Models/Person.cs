using ValidationAttributes.Attributes;
using ValidationAttributes.Models.Interfaces;
namespace ValidationAttributes.Models
{
    public class Person : IPerson
    {
        private const int MinAge = 12;
        private const int MaxAge = 90;

        public Person(string name, int age)
        {
            FullName = name;
            Age = age;
        }
        

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(MinAge, MaxAge)]
        public int Age { get; private set; }
    }
}