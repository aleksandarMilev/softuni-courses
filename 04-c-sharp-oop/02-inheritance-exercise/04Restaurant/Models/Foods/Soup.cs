namespace Restaurant.Models.Foods
{
    public sealed class Soup : Starter
    {
        public Soup(string name, decimal price, double grams)
            : base(name, price, grams)
        {
        }
    }
}
