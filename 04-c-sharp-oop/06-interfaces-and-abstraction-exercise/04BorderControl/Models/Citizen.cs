using BorderControl.Models.Interfaces;
namespace BorderControl.Models
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string iD)
        {
            Name = name;
            Age = age;
            ID = iD;
        }


        public string Name { get; private set; }
        public int Age { get; private set; }
        public string ID { get; private set; }
    }
}
