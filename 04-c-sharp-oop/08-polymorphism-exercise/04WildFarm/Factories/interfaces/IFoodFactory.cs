using WildFarm.Models.Food.Interfaces;

namespace WildFarm.Factories.interfaces
{
    public interface IFoodFactory
    {
        IFood Create(string type, int quantity);
    }
}
