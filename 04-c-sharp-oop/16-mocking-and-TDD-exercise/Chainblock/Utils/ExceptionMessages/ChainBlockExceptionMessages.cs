namespace Chainblock.Utils.ExceptionMessages
{
    public static class ChainBlockExceptionMessages
    {
        public const string AddExistingTransaction = "Transaction with ID: {0} already exists!";
        public const string TransactionDoesNotExist = "Transaction with ID: {0} do not exist!";
        public const string NoTransactionsWithThisStatus = "There are no transactions with status: {0}!";
        public const string NoTransactionsFromThisSender = "There are no transactions from {0}!";
        public const string NoTransactionsForThisReceiver = "There are no transactions for {0}!";
        public const string NoTransactionsForThisReceiverOrInThisRange = "There are no transactions for {0} or in range {1} - {2}!";
        public const string NoTransactionsForThisReceiverOrGreaterThanGivenAmount = "There are no transactions for {0} or with amount bigger than {1}!";
    }
}
