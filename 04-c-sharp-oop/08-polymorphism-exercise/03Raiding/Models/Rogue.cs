namespace Raiding.Models
{
    public class Rogue : Hero
    {
        private const int RogueDefaultPower = 80;

        public Rogue(string name)
            : base(name, RogueDefaultPower)
        {
        }

        public override string CastAbility()
            => $"{GetType().Name} - {Name} hit for {Power} damage";
    }
}
