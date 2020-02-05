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
            double depositAmount = 100.0;
            double expectedBalance = 100.0;

            //Act - Call the method under test
            acc.Deposite(depositAmount);

            //Assert - Did what we want happen?
            Assert.AreEqual(expectedBalance, acc.Balance);
        }
    }
}