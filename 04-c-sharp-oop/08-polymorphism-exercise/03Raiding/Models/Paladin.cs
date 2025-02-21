namespace Raiding.Models
{
    public class Paladin : Hero
    {
        private const int PaladinDefaultPower = 100;

        public Paladin(string name)
            : base(name, PaladinDefaultPower)
        {
        }

        public override string CastAbility()
            => $"{GetType().Name} - {Name} healed for {Power}";
    }
}
