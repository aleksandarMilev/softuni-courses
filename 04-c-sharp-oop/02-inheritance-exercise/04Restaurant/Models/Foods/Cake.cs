namespace Restaurant.Models.Foods
{
    public sealed class Cake : Dessert
    {
        private const decimal CakeDefaultPrice = 5m;
        private const double CakeDefaultGrams = 250;
        private const double CakeDefaultCalories = 1_000;

        public Cake(string name)
            : base(name, CakeDefaultPrice, CakeDefaultGrams, CakeDefaultCalories)
        {
        }
    }
}
