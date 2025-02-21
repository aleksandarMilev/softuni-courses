using Chainblock.Models;
using NUnit.Framework;
using Chainblock.Enums;
using System;
using Chainblock.Utils.ExceptionMessages;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private Transaction transaction;

        [SetUp]
        public void Setup()
        {
            transaction = new(1, TransactionStatus.Successfull, "RobinZoKruzo", "Petkan", 100.245M);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            transaction = new(1, TransactionStatus.Successfull, "RobinZoKruzo", "Petkan", 100.245M);

            Assert.IsNotNull(transaction);
            Assert.AreEqual(1, transaction.Id);
            Assert.AreEqual(TransactionStatus.Successfull, transaction.Status);
            Assert.AreEqual("RobinZoKruzo", transaction.From);
            Assert.AreEqual("Petkan", transaction.To);
            Assert.AreEqual(100.245, transaction.Amount);
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void IdSetterShouldThrowExceptionIfValueIsNegative(int id)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => transaction.Id = id);

            Assert.AreEqual(TransactionExceptionMessages.TransactionIdNegative, exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void FromSetterShouldThrowExceptionIfValueIsNullOrWhiteSpace(string from)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => transaction.From = from);

            Assert.AreEqual(TransactionExceptionMessages.FromNameNullOrWhiteSpace, exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ToSetterShouldThrowExceptionIfValueIsNullOrWhiteSpace(string to)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => transaction.To = to);

            Assert.AreEqual(TransactionExceptionMessages.ToNameNullOrWhiteSpace, exception.Message);
        }

        [TestCase(0)]
        [TestCase(-0.00001)]
        [TestCase(-100)]
        public void AmountSetterShouldThrowExceptionIfValueIsZeroOrNegative(decimal amount)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => transaction.Amount = amount);

            Assert.AreEqual(TransactionExceptionMessages.TransactionAmountZeroOrNegative, exception.Message);
        }
    }
}