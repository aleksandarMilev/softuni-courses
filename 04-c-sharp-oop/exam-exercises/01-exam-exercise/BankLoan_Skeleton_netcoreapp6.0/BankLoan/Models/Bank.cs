using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private readonly List<ILoan> loans;
        private readonly List<IClient> clients;

        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            loans = new();
            clients = new();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }

                name = value;
            }
        }
        public int Capacity { get; private set; }
        public IReadOnlyCollection<ILoan> Loans
            => loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients
            => clients.AsReadOnly();

        public double SumRates()
            => loans.Sum(l => l.InterestRate);

        public void AddClient(IClient Client)
        {
            if (Capacity > clients.Count)
            {
                clients.Add(Client);

                Capacity--;
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void RemoveClient(IClient Client)
            => clients.Remove(Client);

        public void AddLoan(ILoan loan)
            => loans.Add(loan);

        public string GetStatistics()
        {
            StringBuilder result = new();

            result.AppendLine($"Name: {Name}, Type: {GetType().Name}");

            string clientNames = "";

            if (clients.Any())
            {
                foreach (Client client in clients)
                {
                    clientNames += client.Name + ", ";
                }

                clientNames = clientNames.TrimEnd(',', ' ');
            }
            else
            {
                clientNames = "none";
            }

            result.AppendLine($"Clients: {clientNames}");

            double sumOfRates = SumRates();
            result.AppendLine($"Loans: {loans.Count}, Sum of Rates: {sumOfRates}");

            return result.ToString().TrimEnd();
        }

    }
}
