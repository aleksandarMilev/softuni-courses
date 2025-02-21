namespace Restaurant.Models.Beverages
{
    public sealed class Coffee : HotBeverage
    {
        private const decimal CoffeeDefaultPrice = 3.50m;
        private const double CoffeeDefaultMilliliters = 50;

        public Coffee(string name, double caffeine)
            : base(name, CoffeeDefaultPrice, CoffeeDefaultMilliliters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; private set; }
    }
}
