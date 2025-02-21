namespace Raiding.Models
{
    public class Warrior : Hero
    {
        private const int WarriorDefaultPower = 100;

        public Warrior(string name)
            : base(name, WarriorDefaultPower)
        {
        }

        public override string CastAbility()
            => $"{GetType().Name} - {Name} hit for {Power} damage";
    }
}
