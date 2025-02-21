namespace _02IntroductionToEFCore.Models
{
    public class EmployeeProject
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; } = null!;

    }
}
