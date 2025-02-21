namespace UniversityCompetition.Models.Subjects
{
    public class HumanitySubject : Subject
    {
        private const double HumanitySubjectRate = 1.15;

        public HumanitySubject(int id, string name)
            : base(id, name, HumanitySubjectRate)
        {
        }
    }
}
