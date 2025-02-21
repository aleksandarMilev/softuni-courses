using MilitaryElite.Models.Interfaces;
using System.Collections.Generic;
using System.Text;
namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int iD, string firstName, string lastName, decimal salary, IReadOnlyCollection<IPrivate> privates)
            : base(iD, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new();

            result.AppendLine(base.ToString());
            result.AppendLine($"Privates: ");

            foreach (IPrivate @private in Privates)
            {
                result.AppendLine("  " + @private.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
