namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private const int FreeDiverOxygenLevel = 120;

        public FreeDiver(string name)
            : base(name, FreeDiverOxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            double reductionPercentage = 0.6;
            double oxygenReduction = TimeToCatch * reductionPercentage;
            int roundedReduction = (int)Math.Round(oxygenReduction, MidpointRounding.AwayFromZero);
            OxygenLevel -= roundedReduction;

            if (OxygenLevel < 0)
            {
                OxygenLevel = 0;

                HasHealthIssues = true;
            }
        }

        public override void RenewOxy()
            => OxygenLevel = FreeDiverOxygenLevel;
    }
}
