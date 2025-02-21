using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        private readonly List<string> conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            conqueredPeaks = new();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }

                name = value;
            }
        }
        public int Stamina { get; set; }
        public IReadOnlyCollection<string> ConqueredPeaks
            => conqueredPeaks.AsReadOnly();

        public void Climb(IPeak peak)
        {
            if (!conqueredPeaks.Contains(peak.Name))
            {
                conqueredPeaks.Add(peak.Name);
            }

            switch (peak.DifficultyLevel)
            {
                case "Extreme":
                    Stamina -= 6;
                    break;
                case "Hard":
                    Stamina -= 4;
                    break;
                case "Moderate":
                    Stamina -= 2;
                    break;
            }

            if (Stamina < 0)
            {
                Stamina = 0;
            }
        }
        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            string peaks = ConqueredPeaks.Any()
               ? $"{ConqueredPeaks.Count}"
               : "no peaks conquered";
            
            return $"{GetType().Name} - Name: {Name}, Stamina: {Stamina}{Environment.NewLine}Peaks conquered: {peaks}";
        }
    }
}
