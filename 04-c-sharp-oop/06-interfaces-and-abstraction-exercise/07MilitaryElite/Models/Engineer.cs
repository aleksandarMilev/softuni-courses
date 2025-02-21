﻿using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;
using System.Collections.Generic;
using System.Text;
namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int iD, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IRepair> repairs)
            : base(iD, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new();

            result.AppendLine(base.ToString());
            result.AppendLine($"Repairs: ");

            foreach (IRepair repair in Repairs)
            {
                result.AppendLine("  " + repair.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
