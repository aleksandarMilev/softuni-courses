namespace Handball.Models
{
    public class CenterBack : Player
    {
        private const double CenterBackRating = 4;
        private const double CenterBackRatingIncreaseValue = 1;
        private const double CenterBackRatingDecreaseValue = 1;

        public CenterBack(string name)
            : base(name, CenterBackRating)
        {
        }

        public override void IncreaseRating()
        {
            Rating += CenterBackRatingIncreaseValue;

            if (Rating > 10)
            {
                Rating = 10;
            }
        }

        public override void DecreaseRating()
        {
            Rating -= CenterBackRatingDecreaseValue;

            if (Rating < 1)
            {
                Rating = 1;
            }
        }
    }
}
