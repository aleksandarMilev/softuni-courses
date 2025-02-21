using WildFarm.Models.Animals.Interfaces;
namespace WildFarm.Factories.interfaces
{
    public interface IAnimalFactory
    {
        IAnimal Create(string[] arguments);
    }
}
