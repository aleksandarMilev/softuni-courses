namespace BankLoan.Models
{
    public class MortgageLoan : Loan
    {
        private const int MortgageLoanInterestRate = 3;
        private const int MortgageLoanAmount = 50_000;

        public MortgageLoan()
            : base(MortgageLoanInterestRate, MortgageLoanAmount)
        {
        }
    }
}
