namespace FoodShortage.Models.Interfaces
{
    public interface IBuyer : INameable
    {
        void BuyFood();

        int Food { get; }
    }
}
