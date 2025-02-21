using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] accountsInput = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, double> accounts = new();

            foreach (string account in accountsInput)
            {
                string[] currentAccount = account.Split("-");

                int accountNumber = int.Parse(currentAccount[0]);
                double accountBalance = double.Parse(currentAccount[1]);

                accounts.Add(accountNumber, accountBalance);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = arguments[0];
                int accountNumber = int.Parse(arguments[1]);
                double sum = double.Parse(arguments[2]);

                try
                {
                    if (!accounts.ContainsKey(accountNumber))
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    switch (action)
                    {
                        case "Deposit":
                            accounts[accountNumber] += sum;
                            break;
                        case "Withdraw":
                            if (sum > accounts[accountNumber])
                            {
                                throw new ArgumentException("Insufficient balance!");
                            }

                            accounts[accountNumber] -= sum;
                            break;
                        default:
                            throw new ArgumentException("Invalid command!");
                    }

                    Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
