using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountWithTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountWithTests.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        [TestMethod()]
        public void Deposit_PositiveValue_AddsToBalance()
        {
            //Arrange - create objects and variables
            BankAccount acc = new BankAccount("U030043664");
            double depositAmount = 100.00;
            double expectedBalance = 100.00;

            //Act - Call the method under test
            acc.Deposite(depositAmount);

            //Assert - Did what we want happen?
            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        public void Deposit_PosititveAmountWithCents_AddsToBalance()
        {
            // Arrange
            BankAccount acc = new BankAccount("U030043664");
            double depositAmount = 10.55;
            double expectedBalance = 10.55;

            // Act
            acc.Deposite(depositAmount);

            // Assert
            Assert.AreEqual(expectedBalance, acc.Balance);
        }


        [TestMethod]
        [DataRow(100.00)]
        [DataRow(100.99)]
        [DataRow(0.01)]
        [DataRow(9999999999.99)]
        public void Deposit_PosititveAmount_ReturnsUpdatedBalance(double depositAmount)
        {
            // Arrange
            BankAccount acc = new BankAccount("U030043664");
            double initialBalance = 0;
            double expectedBalance = initialBalance + depositAmount;

            // Act
            double retrunedBalance = acc.Deposite(depositAmount);

            // Assert
            Assert.AreEqual(expectedBalance, retrunedBalance);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-1.99)]
        [DataRow(0)]
        [DataRow(-0.01)]
        public void Deposit_NegativeAmount_ThrowsArgumentOutOfRangeException(double depositAmount)
        {
            // Arrange
            BankAccount acc = new BankAccount("U030043664");

            // Act => Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Deposite(depositAmount));
        }

        [TestMethod]
        [DataRow("123")]
        [DataRow("a")]
        [DataRow("1234567890")]
        [DataRow("1dD")]
        [DataRow("`~!@#$%^&*()_+-={}|[]\\:\";'<>?,./")]
        [DataRow("(╯°□°)╯︵ ┻━┻")]
        public void Constructor_ValidAccountNumber_SetsAccountNumber(string accountNumber)
        {
            // Arrange / Act
            BankAccount acc = new BankAccount(accountNumber);

            // Assert
            Assert.AreEqual(accountNumber, acc.AccountNumber);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void Constructor_InValidAccountNumber_ThrowsArgumentException(string accountNumber)
        {
            // Arrange / Act / Assert
            Assert.ThrowsException<ArgumentException>(() => new BankAccount(accountNumber));
        }
    }
}