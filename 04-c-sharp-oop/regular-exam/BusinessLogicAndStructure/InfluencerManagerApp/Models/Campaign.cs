using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Campaign : ICampaign
    {
        private string brand;
        private readonly HashSet<string> contributors;

        public Campaign(string brand, double budget)
        {
            Brand = brand;
            Budget = budget;
            contributors = new();   
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandIsrequired);
                }

                brand = value;
            }
        }

        public double Budget { get; private set; }

        public IReadOnlyCollection<string> Contributors =>
            contributors;

        public void Engage(IInfluencer influencer)
        {
            contributors.Add(influencer.Username);
            Budget -= influencer.CalculateCampaignPrice();
        }

        public void Gain(double amount) =>
            Budget += amount;

        public override string ToString() =>
            $"{GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {contributors.Count}";
    }
}
