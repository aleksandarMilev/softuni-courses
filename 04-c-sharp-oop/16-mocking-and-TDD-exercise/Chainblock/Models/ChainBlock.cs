using Chainblock.Enums;
using Chainblock.Models.Contracts;
using System;
using System.Collections.Generic;
using Chainblock.Utils.ExceptionMessages;
using System.Linq;

namespace Chainblock.Models
{
    public class ChainBlock : IChainblock
    {
        private IDictionary<int, ITransaction> transactions;

        public ChainBlock()
        {
            transactions = new Dictionary<int, ITransaction>();
        } 

        public int Count
            => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (Contains(tx.Id))
            {
                throw new ArgumentException(
                    string.Format(ChainBlockExceptionMessages.AddExistingTransaction, tx.Id));
            }

            transactions.Add(tx.Id, tx);
        }

        public bool Contains(int id)
            => transactions.ContainsKey(id);

        public bool Contains(ITransaction tx)
            => Contains(tx.Id);

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction tx = transactions
                .Values
                .FirstOrDefault(t => t.Id == id);

            if (tx == null)
            {
                throw new ArgumentException(
                    string.Format(ChainBlockExceptionMessages.TransactionDoesNotExist, id));
            }

            tx.Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            ITransaction tx = transactions.
                FirstOrDefault(t => t.Value.Id == id)
                .Value;

            if (tx == null)
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionMessages.TransactionDoesNotExist, id));
            }

            transactions.Remove(id);
        }

        public ITransaction GetById(int id)
        {
            ITransaction tx = transactions.
                FirstOrDefault(t => t.Value.Id == id)
                .Value;

            if (tx == null)
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionMessages.TransactionDoesNotExist, id));
            }

            return tx;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> transactionsFilter = 
                transactions
                .Values
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount);

            if (!transactionsFilter.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionMessages.NoTransactionsWithThisStatus, status));
            }

            return transactionsFilter;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> transactionsSendersNames = 
                transactions
                .Values
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.From);

            if (!transactionsSendersNames.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionMessages.NoTransactionsWithThisStatus, status));
            }

            return transactionsSendersNames;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> transactionsSendersNames =
                transactions
                .Values
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.To);

            if (!transactionsSendersNames.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionMessages.NoTransactionsWithThisStatus, status));
            }

            return transactionsSendersNames;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
            => transactions
            .Values
            .OrderByDescending(t => t.Amount)
            .ThenBy(t => t.Id);

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> transactionsFilter = 
                transactions
                .Values
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount);

            if (!transactionsFilter.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionMessages.NoTransactionsFromThisSender, sender));
            }

            return transactionsFilter;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> transactionsFilter =
                transactions
                .Values
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id); 

            if (!transactionsFilter.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionMessages.NoTransactionsForThisReceiver, receiver));
            }

            return transactionsFilter;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, decimal amount)
            => transactions
            .Values
            .Where(t => t.Status == status && t.Amount <= amount)
            .OrderByDescending(t => t.Amount);

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, decimal amount)
        {
            IEnumerable<ITransaction> transactionsFilter = transactions
                .Values
                .Where(t => t.From == sender && t.Amount > amount)
                .OrderByDescending(t => t.Amount);

            if (!transactionsFilter.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionMessages.NoTransactionsForThisReceiverOrGreaterThanGivenAmount, sender, amount));
            }

            return transactionsFilter;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, decimal lo, decimal hi)
        {
            IEnumerable<ITransaction> transactionsFilter = transactions
                .Values
                .Where(t => t.To == receiver && t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            if (!transactionsFilter.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionMessages.NoTransactionsForThisReceiverOrInThisRange, receiver, lo, hi));
            }

            return transactionsFilter;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(decimal lo, decimal hi)
            => transactions
                .Values
                .Where(t => t.Amount >= lo && t.Amount <= hi);
    }
}
