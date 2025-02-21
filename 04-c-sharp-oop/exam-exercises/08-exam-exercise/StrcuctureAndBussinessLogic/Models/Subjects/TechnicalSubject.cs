﻿namespace UniversityCompetition.Models.Subjects
{
    public class TechnicalSubject : Subject
    {
        private const double TechnicalSubjectRate = 1.3;

        public TechnicalSubject(int id, string name)
            : base(id, name, TechnicalSubjectRate)
        {
        }
    }
}
