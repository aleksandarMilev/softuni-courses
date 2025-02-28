﻿namespace HighwayToPeak.Models
{
    public class NaturalClimber : Climber
    {
        private const int NaturalClimberStamina = 6;
        public NaturalClimber(string name)
            : base(name, NaturalClimberStamina)
        {
        }

        public override void Rest(int daysCount)
        {
            for (int i = 0; i < daysCount; i++)
            {
                Stamina += 2;
                if (Stamina >= 10)
                {
                    Stamina = 10;
                    break;
                }
            }
        }
    }
}
