using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;
using System;
namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int iD, string firstName, string lastName, decimal salary, Corps corps)
            : base(iD, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get; private set; }

        public override string ToString()
            => $"{base.ToString()}{Environment.NewLine}Corps: {Corps}";
    }
}
