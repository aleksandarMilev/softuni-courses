namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private const double ForwardWingRating = 5.5;
        private const double ForwardWingRatingIncreaseValue = 1.25;
        private const double ForwardWingRatingDecreaseValue = 0.75;

        public ForwardWing(string name)
            : base(name, ForwardWingRating)
        {
        }

        public override void IncreaseRating()
        {
            Rating += ForwardWingRatingIncreaseValue;

            if (Rating > 10)
            {
                Rating = 10;
            }
        }

        public override void DecreaseRating()
        {
            Rating -= ForwardWingRatingDecreaseValue;

            if (Rating < 1)
            {
                Rating = 1;
            }
        }
    }
}
