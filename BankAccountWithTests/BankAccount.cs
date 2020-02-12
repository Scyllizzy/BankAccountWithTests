using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountWithTests
{
    public class BankAccount
    {
        private string accountNumber;

        public BankAccount(string accNum) : this(accNum, 0.00) { }

        public BankAccount(string accNum, double initialBal)
        {
            AccountNumber = accNum;
            Balance = initialBal;
        }

        public string AccountNumber 
        { 
            get => accountNumber;
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("AccountNumber cannot be null or whitespace");
                }

                accountNumber = value; 
            }
        }

        public string Owner { get; set; }

        public double Balance { get; private set; }

        /// <summary>
        /// Deposits a positive amount of money into the account and returns the new balance
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="depositAmount"/> is 0 or less</exception>
        /// <param name="depositAmount">The amount of money to deposite into the bank account</param>
        public double Deposite(double depositAmount)
        {
            if (depositAmount <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be greater than 0.");
            }

            Balance += depositAmount;
            return Balance;
        }

        public double Withdraw(double withdrawAmt)
        {
            if (withdrawAmt <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be greater than 0.");
            }

            Balance -= withdrawAmt;
            return Balance;
        }
    }
}
