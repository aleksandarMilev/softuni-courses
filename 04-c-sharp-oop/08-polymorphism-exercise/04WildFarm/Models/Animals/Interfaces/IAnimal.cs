using WildFarm.Models.Food.Interfaces;
namespace WildFarm.Models.Animals.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        string ProduceSound();
        void Eat(IFood food);
    }
}
