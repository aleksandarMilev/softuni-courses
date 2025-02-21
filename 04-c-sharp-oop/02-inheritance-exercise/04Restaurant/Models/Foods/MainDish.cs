namespace Restaurant.Models.Foods
{
    public abstract class MainDish : Food
    {
        public MainDish(string name, decimal price, double grams)
            : base(name, price, grams)
        {
        }
    }
}
