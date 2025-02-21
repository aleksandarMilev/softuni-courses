using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;
using System.Collections.Generic;
using System.Text;
namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int iD, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IMission> missions)
            : base(iD, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new();

            result.AppendLine(base.ToString());
            result.AppendLine($"Missions: ");

            foreach (IMission mission in Missions)
            {
                result.AppendLine(mission.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
