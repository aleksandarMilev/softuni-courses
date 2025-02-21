using System;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models.Subjects
{
    public abstract class Subject : ISubject
    {
        private string name;

        protected Subject(int id, string name, double rate)
        {
            Id = id;
            Name = name;
            Rate = rate;
        }

        public int Id { get; private set; }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }
        public double Rate { get; private set; }
    }
}
