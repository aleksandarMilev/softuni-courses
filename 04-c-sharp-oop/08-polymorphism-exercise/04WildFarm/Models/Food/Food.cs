using WildFarm.Models.Food.Interfaces;
namespace WildFarm.Models.Food
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            Quantity = quantity;

        }
        public int Quantity { get; private set; }
    }
}
