namespace Handball.Models
{
    public class Goalkeeper : Player
    {
        private const double GoalkeeperRating = 2.5;
        private const double GoalkeeperRatingIncreaseValue = 0.75;
        private const double GoalkeeperRatingDecreaseValue = 1.25;

        public Goalkeeper(string name)
            : base(name, GoalkeeperRating)
        {
        }

        public override void IncreaseRating()
        {
            Rating += GoalkeeperRatingIncreaseValue;

            if (Rating > 10)
            {
                Rating = 10;
            }
        }

        public override void DecreaseRating()
        {
            Rating -= GoalkeeperRatingDecreaseValue;

            if (Rating < 1)
            {
                Rating = 1;
            }
        }
    }
}
