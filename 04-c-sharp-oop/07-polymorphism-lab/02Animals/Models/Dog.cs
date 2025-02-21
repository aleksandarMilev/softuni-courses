namespace Animals.Models
{
    public class Dog : Animal
    {
        public Dog(string name, string favoriteFood)
            : base(name, favoriteFood)
        {
        }

        public override string ExplainSelf()
            => $"I am {Name} and my favorite food is {FavoriteFood} DJAAF";
    }
}
