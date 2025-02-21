using FoodShortage.Models.Interfaces;
namespace FoodShortage.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string iD)
        {
            Model = model;
            ID = iD;
        }

        public string Model { get; private set; }
        public string ID { get; private set; }
}
}
