namespace Animals.Models
{
    public class Cat : Animal
    {
        public Cat(string name, string favoriteFood)
            : base(name, favoriteFood)
        {
        }

        public override string ExplainSelf()
            => $"I am {Name} and my favorite food is {FavoriteFood} MEEOW";
    }
}
