namespace BankLoan.Models
{
    public class StudentLoan : Loan
    {
        private const int StudentLoanInterestRate = 1;
        private const int StudentLoanAmount = 10_000;

        public StudentLoan()
            : base(StudentLoanInterestRate, StudentLoanAmount)
        {
        }
    }
}
