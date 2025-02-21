using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private string username;
        private int followers;
        private readonly HashSet<string> participations;

        public Influencer(string username, int followers, double engagementRate)
        {
            Username = username;
            Followers = followers;
            EngagementRate = engagementRate;
            Income = 0;
            participations = new();
        }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
                }

                username = value;
            }
        }

        public int Followers
        {
            get => followers;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
                }

                followers = value;
            }
        }

        public double EngagementRate { get; private set; }

        public double Income { get; set; }

        public IReadOnlyCollection<string> Participations =>
            participations;

        public abstract int CalculateCampaignPrice();

        public void EarnFee(double amount) =>
            Income += amount;

        public void EndParticipation(string brand) =>
            participations.Remove(brand);

        public void EnrollCampaign(string brand) =>
            participations.Add(brand);

        public override string ToString() =>
            $"{Username} - Followers: {Followers}, Total Income: {Income}";
    }
}
