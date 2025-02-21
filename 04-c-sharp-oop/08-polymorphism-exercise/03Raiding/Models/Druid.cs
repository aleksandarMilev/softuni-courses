namespace Raiding.Models
{
    public class Druid : Hero
    {
        private const int DruidDefaultPower = 80;

        public Druid(string name)
            : base(name, DruidDefaultPower)
        {
        }

        public override string CastAbility()
            => $"{GetType().Name} - {Name} healed for {Power}";
    }
}
