namespace Animals.Models
{
    public abstract class Animal
    {
        private string name;
        private string favoriteFood;

        protected Animal(string name, string favoriteFood)
        {
            Name = name;
            FavoriteFood = favoriteFood;
        }


        public string Name
        {
            get => name;
            private set => name = value;
        }
        public string FavoriteFood
        {
            get => favoriteFood;
            private set => favoriteFood = value;
        }

        public abstract string ExplainSelf();
    }
}
