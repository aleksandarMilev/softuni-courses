using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private readonly List<string> @catch;

        protected Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            @catch = new();
            CompetitionPoints = 0;
            HasHealthIssues = false;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }

                name = value;
            }
        }
        public int OxygenLevel { get; protected set; }
        public IReadOnlyCollection<string> Catch => @catch.AsReadOnly();
        public double CompetitionPoints { get; private set; }
        public bool HasHealthIssues { get; set; }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;

            if (OxygenLevel <= 0)
            {
                OxygenLevel = 0;

                HasHealthIssues = true;
            }

            @catch.Add(fish.Name);

            CompetitionPoints += fish.Points;
        }
        public abstract void Miss(int TimeToCatch);
        public abstract void RenewOxy();
        public void UpdateHealthStatus() => HasHealthIssues = !HasHealthIssues;

        public override string ToString()
        {
            string formattedCompetitionPoints = CompetitionPoints % 1 == 0
                ? CompetitionPoints.ToString("0")
                : CompetitionPoints.ToString("f1");

            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {formattedCompetitionPoints} ]";
        }
    }
}
