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

        public BankAccount(string AccountNumber)
        {
            this.AccountNumber = AccountNumber;
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
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="amount"/> is 0 or less</exception>
        /// <param name="amount">The amount of money to deposite into the bank account</param>
        public double Deposite(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be greater than 0.");
            }

            Balance += amount;
            return Balance;
        }
    }
}
