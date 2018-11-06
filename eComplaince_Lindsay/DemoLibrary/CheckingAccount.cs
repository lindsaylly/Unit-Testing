using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Sep.2018
 * Author: Lindsay
 * Purpose: code challenge for eComplaince
 */
namespace DemoLibrary
{
    public class CheckingAccount
    {
        //balance is always tracked in Canadian currency
        public const double RATE_USD_CAD = 2.0; // the exchange rate of US dollars to CAD dolloars
        public const double RATE_MXN_CAD = 0.1; // the exchange rate of Mexican Pesos to CAD dolloars

        private string accountNo;
        private string ownerId;
        private decimal balance;
        public string AccountNo
        {
            get
            {
                return accountNo;
            }
            set
            {
                if (value is null)
                    throw new ArgumentNullException("AccountNo");
                accountNo = value;
            }
        }

        public string OwnerId
        {
            get
            {
                return ownerId;
            }
            set
            {
                if (value is null)
                    throw new ArgumentNullException("OwnerId");
                ownerId = value;
            }
        }
        public decimal Balance { get { return balance; } } // read only

        //instructor
        public CheckingAccount(string accountNum, string custId, decimal initBalance)
        {
            AccountNo = accountNum;
            OwnerId = custId;
            if (initBalance < 0)
                balance = 0;
            else
                balance = initBalance;
        }

        /// <summary>
        /// The method is to calculate the balance when depositing.
        /// </summary>
        /// <param name="amount">amount should be positive</param>
        /// <param name="currency">currency could be "MXN", "USD", or "CAD"</param>
        /// <returns>a boolean value</returns>
        public bool Deposit(decimal amount, string currency)
        {
            bool result = false;
            if (amount > 0) // ignore if negative or zero
            {
                //exchange to Candadian dollars when depositing a foreign currency
                if (currency != "CAD")
                    amount = CurrencyExchange(amount, currency);
                balance += amount;
                result = true;
            }
            return result;
        }

        /// <summary>
        /// The method is to calculate the balance when withdrawing.
        /// </summary>
        /// <param name="amount">amount should be positive</param>
        /// <param name="currency">currency could be "MXN", "USD", or "CAD"</param>
        /// <returns>a boolean value</returns>
        public bool Withdraw(decimal amount, string currency)
        {
            bool result = false;
            if (amount > 0) // ignore if negative or zero
            {
                //exchange to Candadian dollars when withdrawing a foreign currency
                if (currency != "CAD")
                    amount = CurrencyExchange(amount, currency);

                if (amount <= Balance)
                {
                    balance -= amount;
                    result = true;
                }
            }
            return result;
        }

        //exchange foreign currency to Cananidan currency
        private decimal CurrencyExchange(decimal amount, string currency)
        {
            decimal exAmount;
            switch (currency)
            {
                case "MXN": //Mexican Pesos
                    exAmount = amount * (decimal)RATE_MXN_CAD;
                    break;
                case "USD":  //USD dollars
                    exAmount = amount * (decimal)RATE_USD_CAD;
                    break;
                default: return 0; //when withdrawing other currency
            }
            return exAmount;
        }

        // return string for display
        public override string ToString()
        {
            return "Account Number:" + AccountNo +
                " Balance:" + balance.ToString("c") + " CAD";
        }
    }
}
