using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System.Text;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IInfluencer> influencers = new InfluencerRepository();
        private readonly IRepository<ICampaign> campaigns = new CampaignRepository();

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (typeName != typeof(BusinessInfluencer).Name &&
                typeName != typeof(FashionInfluencer).Name &&
                typeName != typeof(BloggerInfluencer).Name)
            {
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            if (influencers.FindByName(username) != null)
            {
                return string.Format(OutputMessages.UsernameIsRegistered, username, typeof(InfluencerRepository).Name);
            }

            IInfluencer influencer = typeName switch
            {
                "BusinessInfluencer" => new BusinessInfluencer(username, followers),
                "FashionInfluencer" => new FashionInfluencer(username, followers),
                "BloggerInfluencer" => new BloggerInfluencer(username, followers),
            };

            influencers.AddModel(influencer);
            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            if (typeName != typeof(ProductCampaign).Name && typeName != typeof(ServiceCampaign).Name)
            {
                return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }

            if (campaigns.FindByName(brand) != null)
            {
                return string.Format(OutputMessages.CampaignDuplicated, brand);
            }

            ICampaign campaign = typeName switch
            {
                "ProductCampaign" => new ProductCampaign(brand),
                "ServiceCampaign" => new ServiceCampaign(brand),
            };

            campaigns.AddModel(campaign);
            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer influencer = influencers.FindByName(username);   
            ICampaign campaign = campaigns.FindByName(brand);

            if (influencer == null)
            {
                return string.Format(OutputMessages.InfluencerNotFound, typeof(InfluencerRepository).Name, username);
            }

            if (campaign == null)
            {
                return string.Format(OutputMessages.CampaignNotFound, brand);
            }

            if (campaign.Contributors.Contains(username))
            {
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            if ((campaign.GetType().Name == "ProductCampaign" && influencer.GetType().Name == "BloggerInfluencer") ||
                (campaign.GetType().Name == "ServiceCampaign" && influencer.GetType().Name == "FashionInfluencer"))
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if (campaign.Budget < influencer.CalculateCampaignPrice())
            {
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            influencer.EnrollCampaign(brand);
            influencer.EarnFee(influencer.CalculateCampaignPrice()); //?

            campaign.Engage(influencer);

            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string FundCampaign(string brand, double amount)
        {
            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToFund);
            }

            if (amount <= 0)
            {
                return string.Format(OutputMessages.NotPositiveFundingAmount);
            }

            campaign.Gain(amount);
            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }
        public string CloseCampaign(string brand)
        {
            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToClose);
            }

            if (campaign.Budget <= 10_000)
            {
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }

            foreach (string inflName in campaign.Contributors)
            {
                Influencer influencer = (Influencer)influencers.FindByName(inflName);
                influencer.Income += 2_000;
                influencer.EndParticipation(brand);
            }

            campaigns.RemoveModel(campaign);
            return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = influencers.FindByName(username);

            if (influencer == null)
            {
                return string.Format(OutputMessages.InfluencerNotSigned, username);
            }

            foreach (var campName in influencer.Participations)
            {
                ICampaign campaign = campaigns.FindByName(campName);
                if (campaign != null)
                {
                    return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
                }
            }

            influencers.RemoveModel(influencer);
            return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string ApplicationReport()
        {
            var result = new StringBuilder();

            var influcencersOrdered = influencers
                .Models
                .OrderByDescending(i => i.Income)
                .ThenByDescending(i => i.Followers);

            foreach (var infl in influcencersOrdered)
            {
                result.AppendLine(infl.ToString());

                if(infl.Participations.Any())
                {
                    result.AppendLine("Active Campaigns:");

                    foreach (var campName in infl.Participations.OrderBy(x => x))
                    {
                        var campaign = campaigns.FindByName(campName);
                        result.AppendLine("--" + campaign.ToString());
                    }
                }
            }

            return result.ToString().Trim();
        }
    }
}
