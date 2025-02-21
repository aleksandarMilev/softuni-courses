namespace WildFarm.Models.Animals.Interfaces
{
    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}
