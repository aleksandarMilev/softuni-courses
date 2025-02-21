using BirthdayCelebrations.Models.Interfaces;
namespace BirthdayCelebrations.Models
{
    public class Citizen : INameable, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string iD, string birthDate)
        {
            Name = name;
            Age = age;
            ID = iD;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string ID { get; private set; }
        public string BirthDate { get; private set; }
    }
}
