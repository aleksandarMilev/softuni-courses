﻿using System.Collections.Generic;
using Chainblock.Enums;

namespace Chainblock.Models.Contracts
{
    public interface IChainblock
    {
        int Count { get; }

        void Add(ITransaction tx);

        bool Contains(int id);

        void ChangeTransactionStatus(int id, TransactionStatus newStatus);

        void RemoveTransactionById(int id);

        ITransaction GetById(int id);

        IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status);

        IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status);

        IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status);

        IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById();

        IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender);

        IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver);

        IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, decimal amount);

        IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, decimal amount);

        IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, decimal lo, decimal hi);

        IEnumerable<ITransaction> GetAllInAmountRange(decimal lo, decimal hi);
    }
}
