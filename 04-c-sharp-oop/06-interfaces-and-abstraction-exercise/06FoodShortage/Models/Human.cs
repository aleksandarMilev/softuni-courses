using FoodShortage.Models.Interfaces;
namespace FoodShortage.Models
{
    public class Human : INameable, IIdentifiable, IBirthable, IBuyer
    {
        public Human(string name, int age, string iD, string birthDate)
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
        public int Food { get; private set; }

        public void BuyFood()
            => Food += 10;
    }
}
