using FoodShortage.Models.Interfaces;
namespace FoodShortage.Models
{
    public class Pet : INameable ,IBirthable
    {
        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }
        public string BirthDate { get; private set; }
    }
}
