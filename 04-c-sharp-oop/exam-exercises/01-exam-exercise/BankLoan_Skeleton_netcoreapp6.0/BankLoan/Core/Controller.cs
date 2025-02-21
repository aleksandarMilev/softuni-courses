using BankLoan.Core.Contracts;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using System;
using BankLoan.Utilities.Messages;
using BankLoan.Models;
using System.Linq;
using System.Text;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private IRepository<ILoan> loans; 
        private IRepository<IBank> banks;

        public Controller()
        {
            loans = new LoanRepository();
            banks = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            if (bankTypeName != "BranchBank" && bankTypeName != "CentralBank")
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }

            IBank bank = null;

            if (bankTypeName == "BranchBank")
            {
                bank = new BranchBank(name);
            }
            else
            {
                bank = new CentralBank(name);
            }

            banks.AddModel(bank);
            return string.Format(OutputMessages.BankSuccessfullyAdded, bank.GetType().Name);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            if (clientTypeName != "Adult" && clientTypeName != "Student")
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }

            IBank bank = banks.FirstModel(bankName);

            IClient client = null;

            if (clientTypeName == "Adult")
            {
                client = new Adult(clientName, id, income);

                if (bank.GetType().Name == "BranchBank")
                {
                    return string.Format(OutputMessages.UnsuitableBank);
                }
            }
            else
            {
                client = new Student(clientName, id, income);

                if (bank.GetType().Name == "CentralBank")
                {
                    return string.Format(OutputMessages.UnsuitableBank);
                }
            }

            bank.AddClient(client);
            return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
        }

        public string AddLoan(string loanTypeName)
        {
            if (loanTypeName != "MortgageLoan" && loanTypeName != "StudentLoan")
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }

            ILoan loan = null;

            if (loanTypeName == "MortgageLoan")
            {
                loan = new MortgageLoan();
            }
            else
            {
                loan = new StudentLoan();
            }

            loans.AddModel(loan);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loan.GetType().Name);
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = banks.FirstModel(bankName);

            double funds = bank.Loans.Sum(l => l.Amount) + 
                bank.Clients.Sum(c => c.Income);

            return string.Format(OutputMessages.BankFundsCalculated, bankName, $"{funds:f2}");
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            IBank bank = banks.FirstModel(bankName);

            ILoan loan = loans.FirstModel(loanTypeName);

            if (loan == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }

            bank.AddLoan(loan);

            loans.RemoveModel(loan);

            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string Statistics()
        {
            StringBuilder result = new();

            foreach (Bank bank in banks.Models)
            {
                result.AppendLine(bank.GetStatistics());
            }

            return result.ToString().TrimEnd();
        }
    }
}
