namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        private const int ScubaDiverOxygenLevel = 540;

        public ScubaDiver(string name)
            : base(name, ScubaDiverOxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            double reductionPercentage = 0.3;
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
            => OxygenLevel = ScubaDiverOxygenLevel;
    }
}
