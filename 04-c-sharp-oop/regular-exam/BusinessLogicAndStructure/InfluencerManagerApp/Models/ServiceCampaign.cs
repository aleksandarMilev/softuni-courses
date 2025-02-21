﻿namespace InfluencerManagerApp.Models
{
    public class ServiceCampaign : Campaign
    {

        private const double ServiceCampaignBudget = 30_000;

        public ServiceCampaign(string brand)
            : base(brand, ServiceCampaignBudget)
        {
        }
    }
}
