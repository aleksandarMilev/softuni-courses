﻿using Chainblock.Enums;

namespace Chainblock.Models.Contracts
{
    public interface ITransaction
    {
        int Id { get; set; }

        TransactionStatus Status { get; set; }

        string From { get; set; }

        string To { get; set; }

        decimal Amount { get; set; }
    }
}
