﻿namespace InfluencerManagerApp.Models
{
    public class BusinessInfluencer : Influencer
    {
        private const double BusinessInfluencerEngagementRate = 3;
        private const double BusinessInfluencerFactor = 0.15;

        public BusinessInfluencer(string username, int followers)
            : base(username, followers, BusinessInfluencerEngagementRate)
        {
        }

        public override int CalculateCampaignPrice() =>
            (int)Math.Floor(Followers * EngagementRate * BusinessInfluencerFactor);
    }
}
