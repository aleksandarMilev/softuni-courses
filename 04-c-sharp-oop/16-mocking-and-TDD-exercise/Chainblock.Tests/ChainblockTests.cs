using Chainblock.Models;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Collections.Generic;
using Chainblock.Models.Contracts;
using Chainblock.Enums;
using Chainblock.Utils.ExceptionMessages;
using System.Linq;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainBlock;
        private ITransaction transaction;

        [SetUp]
        public void SetUp()
        {
            chainBlock = new ChainBlock();
            transaction = new Transaction(1, TransactionStatus.Successfull, "RobinzoKruzo", "Petkan", 100);
        }

        [Test]
        public void TransactionsCollectionShouldInitialize()
        {
            chainBlock = new ChainBlock();

            Type chainBlockType = chainBlock.GetType();

            FieldInfo transactionsField = chainBlockType
                .GetField("transactions", (BindingFlags)36);

            IDictionary<int, ITransaction> transactionsFieldValue = transactionsField
                .GetValue(chainBlock) as IDictionary<int, ITransaction>;

            Assert.IsNotNull(transactionsFieldValue);
        }

        [Test]
        public void CountGetterShouldReturnZeroIfCollectionIsEmpty()
        {
            int expectedResult = 0;

            Assert.AreEqual(expectedResult, chainBlock.Count);
        }

        [Test]
        public void CountGetterShouldReturnTheCorrectValueIfCollectionIsNotEmpty()
        {
            chainBlock.Add(transaction);
            chainBlock.Add(new Transaction(2, TransactionStatus.Successfull, "RobinzoKruzo", "Petkan", 100));

            int expectedResult = 2;

            Assert.AreEqual(expectedResult, chainBlock.Count);
        }

        [Test]
        public void AddMethodShouldAddTheCorrectTransactionIfSuchDoesNotExist()
        {
            ITransaction expectedResult = transaction;

            chainBlock.Add(transaction);

            ITransaction actualResult = chainBlock.GetById(transaction.Id);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfSuchTransactionAlreadyExists()
        {
            chainBlock.Add(transaction);

            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => chainBlock.Add(transaction));

            Assert.AreEqual(string.Format
                (ChainBlockExceptionMessages.AddExistingTransaction, transaction.Id), exception.Message);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfTransactionWithSameIdAlreadyExists()
        {
            chainBlock.Add(transaction);

            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => chainBlock.Add(new Transaction(1, TransactionStatus.Failed, "Pesho", "Ivan", 200.523M)));

            Assert.AreEqual(string.Format
                (ChainBlockExceptionMessages.AddExistingTransaction, transaction.Id), exception.Message);
        }

        [Test]
        public void ContainsMethodShouldReturnTrueIfTransactionWithTheGivenIdIsAlreadyAdded()
        {
            chainBlock.Add(transaction);

            Assert.IsTrue(chainBlock.Contains(transaction.Id));
        }

        [Test]
        public void ContainsMethodShouldReturnFalseIfTransactionWithTheGivenIdDoesNotExist()
        {
            chainBlock.Add(transaction);

            Assert.IsFalse(chainBlock.Contains(23));
        }

        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorised)]
        [TestCase(TransactionStatus.Successfull)]
        public void ChangeStatusMethodShouldChangeTheTransactionStatusIfSuchExist(TransactionStatus status)
        {
            chainBlock.Add(transaction);

            chainBlock.ChangeTransactionStatus(1, status);

            Assert.AreEqual(status, transaction.Status);
        }

        [Test]
        public void ChangeStatusMethodShouldThrowExceptionIfTransactionWithTheGivenIdDoesNotExist()
        {
            chainBlock.Add(transaction);

            int transactionChangeTryId = 2;

            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => chainBlock.ChangeTransactionStatus(transactionChangeTryId, TransactionStatus.Unauthorised));

            Assert.AreEqual(string.Format
                (ChainBlockExceptionMessages.TransactionDoesNotExist, transactionChangeTryId), exception.Message);
        }

        [Test]
        public void RemoveTransactionByIdMethodShouldRemoveTheGivenTransactionIfTransactionWithTheGivenIdExists()
        {
            int expectedResult = 0;

            chainBlock.Add(transaction);
            chainBlock.RemoveTransactionById(1);

            Assert.AreEqual(expectedResult, chainBlock.Count);
        }

        [Test]
        public void RemoveTransactionByIdMethodShouldThrowExceptionIfTransactionWithTheGivenIdDoesNotExist()
        {
            chainBlock.Add(transaction);

            int transactionRemoveTryId = 2;

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainBlock.RemoveTransactionById(transactionRemoveTryId));

            Assert.AreEqual(string.Format
                (ChainBlockExceptionMessages.TransactionDoesNotExist, transactionRemoveTryId), exception.Message);
        }

        [Test]
        public void GetByIdMethodShouldReturnTheGivenTransactionIfTransactionWithTheGivenIdExists()
        {
            ITransaction expectedResult = transaction;

            chainBlock.Add(transaction);

            ITransaction actualResult = chainBlock.GetById(1);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByIdMethodShouldThrowExceptionIfTransactionWithTheGivenIdDoesNotExist()
        {
            chainBlock.Add(transaction);

            int transactionTryToGetId = 2;

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainBlock.GetById(transactionTryToGetId));

            Assert.AreEqual(string.Format
                (ChainBlockExceptionMessages.TransactionDoesNotExist, transactionTryToGetId), exception.Message);
        }

        [Test]
        public void GetByTransactionStatusMethodShouldReturnAllTransactionsWithTheGivenStatus()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "RobinzoKruzo", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            IEnumerable<ITransaction> expectedResult = transactionsAdd
                .Where(tx => tx.Status == TransactionStatus.Successfull)
                .OrderByDescending(tx => tx.Amount);

            CollectionAssert.AreEqual(expectedResult, chainBlock.GetByTransactionStatus(TransactionStatus.Successfull));
        }

        [Test]
        public void GetByTransactionStatusMethodShouldThrowExceptionIfTransactionsWithTheGivenStatusDoNotExist()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "RobinzoKruzo", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainBlock.GetByTransactionStatus(TransactionStatus.Failed));

            CollectionAssert.AreEqual(string.Format
                (ChainBlockExceptionMessages.NoTransactionsWithThisStatus, TransactionStatus.Failed), exception.Message);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusMethodShouldReturnSenderNamesWithTheGivenStatus()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "RobinzoKruzo", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            IEnumerable<string> expectedResult = new List<string>() { "RobinzoKruzo", "Pesho" };
            IEnumerable<string> actualResult = chainBlock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusMethodShouldReturnSenderNamesWithTheGivenStatusIfSenderNamesDuplicate()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "RobinzoKruzo", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "RobinzoKruzo", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            IEnumerable<string> expectedResult = new List<string>() { "RobinzoKruzo", "RobinzoKruzo" };
            IEnumerable<string> actualResult = chainBlock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusMethodShouldThrowExceptionIfTransactionsWithTheGivenStatusDoNotExist()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "RobinzoKruzo", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainBlock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed));

            Assert.AreEqual(string.Format
                (ChainBlockExceptionMessages.NoTransactionsWithThisStatus, TransactionStatus.Failed), exception.Message);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusMethodShouldReturnReceiversNamesWithTheGivenStatus()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "RobinzoKruzo", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            IEnumerable<string> expectedResult = new List<string>() { "Petkan", "Ivan" };
            IEnumerable<string> actualResult = chainBlock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetAllReceiverWithTransactionStatusMethodShouldReturnReceiversNamesWithTheGivenStatusIfSenderNamesDuplicate()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "RobinzoKruzo", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "RobinzoKruzo", "Petkan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            IEnumerable<string> expectedResult = new List<string>() { "Petkan", "Petkan" };
            IEnumerable<string> actualResult = chainBlock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusMethodShouldThrowExceptionIfTransactionsWithTheGivenStatusDoNotExist()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "RobinzoKruzo", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainBlock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed));

            Assert.AreEqual(string.Format
                (ChainBlockExceptionMessages.NoTransactionsWithThisStatus, TransactionStatus.Failed), exception.Message);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdMethodShouldReturnTheProperCollection()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "RobinzoKruzo", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            IEnumerable<ITransaction> expectedResult = transactionsAdd
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            IEnumerable<ITransaction> actualResult = chainBlock.GetAllOrderedByAmountDescendingThenById();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingMethodShouldReturnTheProperCollection()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "Pesho", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300),
                 new Transaction(5, TransactionStatus.Aborted, "Pesho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            IEnumerable<ITransaction> expectedResult = transactionsAdd
                .Where(t => t.From == "Pesho")
                .OrderByDescending(t => t.Amount);

            IEnumerable<ITransaction> actualResult = chainBlock.GetBySenderOrderedByAmountDescending("Pesho");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingMethodShouldThrowExceptionIfTransactionsWithThisSenderDoNotExist()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "Pesho", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300),
                 new Transaction(5, TransactionStatus.Aborted, "Pesho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainBlock.GetBySenderOrderedByAmountDescending("Strahil"));

            Assert.AreEqual(string.Format
                (ChainBlockExceptionMessages.NoTransactionsFromThisSender, "Strahil"), exception.Message);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldReturnTheProperCollection()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "Pesho", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300),
                 new Transaction(5, TransactionStatus.Aborted, "Pesho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }


            IEnumerable<ITransaction> expectedResult = transactionsAdd
                .Where(t => t.To == "Dragan")
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            IEnumerable<ITransaction> actualResult = chainBlock.GetByReceiverOrderedByAmountThenById("Dragan");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdMethodShouldThrowExceptionIfTransactionsWithThisReceiverDoNotExist()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "Pesho", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300),
                 new Transaction(5, TransactionStatus.Aborted, "Pesho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainBlock.GetByReceiverOrderedByAmountThenById("Strahil"));

            Assert.AreEqual(string.Format
                (ChainBlockExceptionMessages.NoTransactionsForThisReceiver, "Strahil"), exception.Message);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnTheProperCollection()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "Pesho", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300),
                 new Transaction(5, TransactionStatus.Aborted, "Pesho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            IEnumerable<ITransaction> expectedResult = transactionsAdd
                .Where(t => t.Status == TransactionStatus.Successfull && t.Amount <= 200)
                .OrderByDescending(t => t.Amount);

            IEnumerable<ITransaction> actualResult = 
                chainBlock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 200);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingMethodShouldReturnTheProperCollection()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "Pesho", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300),
                 new Transaction(5, TransactionStatus.Aborted, "Pesho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            IEnumerable<ITransaction> expectedResult = transactionsAdd
                .Where(t => t.From == "Pesho" && t.Amount > 200)
                .OrderByDescending(t => t.Amount);

            IEnumerable<ITransaction> actualResult =
                chainBlock.GetBySenderAndMinimumAmountDescending("Pesho", 200);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingMethodShouldThrowExceptionIfNoSuchTransactionsFound()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "Pesho", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300),
                 new Transaction(5, TransactionStatus.Aborted, "Pesho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainBlock.GetBySenderAndMinimumAmountDescending("Strahil", 300));

            Assert.AreEqual(string.Format
                (ChainBlockExceptionMessages.NoTransactionsForThisReceiverOrGreaterThanGivenAmount, "Strahil", 300), exception.Message);
        }

        [Test]
        public void GetByReceiverAndAmountRangeMethodShouldReturnTheProperCollection()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "Pesho", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 100),
                 new Transaction(5, TransactionStatus.Aborted, "Pesho", "Dragan", 198)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            IEnumerable<ITransaction> expectedResult = transactionsAdd
                .Where(t => t.To == "Dragan" && t.Amount >= 100 && t.Amount < 199)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            IEnumerable<ITransaction> actualResult =
                chainBlock.GetByReceiverAndAmountRange("Dragan", 100, 199);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByReceiverAndAmountRangeMethodShouldThrowExceptionIfNoSuchTransactionsFound()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "Pesho", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 300),
                 new Transaction(5, TransactionStatus.Aborted, "Pesho", "Dragan", 300)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainBlock.GetByReceiverAndAmountRange("Dragan", 301, 500));

            Assert.AreEqual(string.Format
                (ChainBlockExceptionMessages.NoTransactionsForThisReceiverOrInThisRange, "Dragan", 301, 500), exception.Message);
        }

        [Test]
        public void GetAllInAmountRangeMethodShouldReturnTheProperCollection()
        {
            IEnumerable<ITransaction> transactionsAdd = new List<ITransaction>()
            {
                 new Transaction(2, TransactionStatus.Successfull, "Pesho", "Petkan", 150),
                 new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 200),
                 new Transaction(4, TransactionStatus.Aborted, "Gosho", "Dragan", 100),
                 new Transaction(5, TransactionStatus.Aborted, "Pesho", "Dragan", 198)
            };

            foreach (ITransaction transaction in transactionsAdd)
            {
                chainBlock.Add(transaction);
            }

            IEnumerable<ITransaction> expectedResult = transactionsAdd
                .Where(t => t.Amount >= 100 && t.Amount <= 198);

            IEnumerable<ITransaction> actualResult =
                chainBlock.GetAllInAmountRange(100, 198);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
