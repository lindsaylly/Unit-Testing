using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;

/* Sep.2018
 * Author: Lindsay
 * Purpose: code challenge for eComplaince
 */
namespace Demo
{
    public class Program
    {
        /// <summary>
        /// Transferring between two different accounts
        /// </summary>
        /// <param name="amount">the amount to transfer</param>
        /// <param name="currency">the currency of transfer</param>
        /// <param name="TransferFromAccount">the checking account that fransferring from</param>
        /// <param name="TransferToAccount">the checking account that fransferring to</param>
        static void Transfer(decimal amount, string currency, CheckingAccount TransferFromAccount, CheckingAccount TransferToAccount)
        {
            TransferFromAccount.Withdraw(amount, currency);
            TransferToAccount.Deposit(amount, currency);
        }

        /// <summary>
        /// get the customer object by customer name
        /// </summary>
        /// <param name="custs">the array of existing customers</param>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <returns></returns>
        static Customer findCustomerbyName(Customer[] custs, string fName, string lName)
        {
            foreach(var cust in custs)
            {
                if ((cust.FirstName == fName) && (cust.LastName == lName))
                {
                    return cust;
                }
            }
            return null;
        }

        /// <summary>
        /// get the checking account object by account number
        /// </summary>
        /// <param name="accts">the array of existing checking accounts</param>
        /// <param name="accountNo"></param>
        /// <returns></returns>
        static CheckingAccount findAccountbyAccountNo(CheckingAccount[] accts, string accountNo)
        {
            foreach(var acct in accts)
            {
                if (acct.AccountNo == accountNo)
                {
                    return acct;
                }
            }
            return null;
        }

        static void Main(string[] args)
        {
            Customer[] custs = new Customer[5];
            custs[0] = new Customer("777", "Stewie", "Griffin");
            custs[1] = new Customer("504", "Glenn", "Quagmire");
            custs[2] = new Customer("002", "Joe", "Swanson");
            custs[3] = new Customer("123", "Peter", "Griffin");
            custs[4] = new Customer("456", "Lois", "Griffin");

            CheckingAccount[] accounts = new CheckingAccount[6];
            accounts[0] = new CheckingAccount("1234", "777", 100m);
            accounts[1] = new CheckingAccount("2001", "504", 35000m);
            accounts[2] = new CheckingAccount("1010", "002", 7425m);
            accounts[3] = new CheckingAccount("5500", "002", 15000m);
            accounts[4] = new CheckingAccount("0123", "123", 150m);
            accounts[5] = new CheckingAccount("0456", "456", 65000m);

            CheckingAccount acct1, acct2, acct3, acct4, acct5, acct6;
            Customer cust2, cust3, cust4, cust5;
            //case1
            Console.WriteLine("Output 1:");
            acct1 = findAccountbyAccountNo(accounts, "1234");
            if (acct1 != null)
            {
                acct1.Deposit(300m, "USD"); 
                Console.WriteLine(acct1);
            }
            else Console.WriteLine("Invalid Customer Name or Accout Number");

            //case2
            Console.WriteLine("Output 2:");
            cust2 = findCustomerbyName(custs, "Glenn", "Quagmire");
            acct2 = findAccountbyAccountNo(accounts, "2001");
            // if the customer is the owner, do withdrawing
            if ((cust2 != null) && (acct2 != null))
            {
                if (cust2.CustId == acct2.OwnerId)
                {
                    acct2.Withdraw(5000m, "MXN");
                    acct2.Withdraw(12500m, "USD");
                }
                acct2.Deposit(300m, "CAD");
                Console.WriteLine(acct2);
            }
            else Console.WriteLine("Invalid Customer Name or Accout Number");

            //case3
            Console.WriteLine("Output 3:");
            cust3 = findCustomerbyName(custs, "Joe", "Swanson");
            acct3 = findAccountbyAccountNo(accounts, "1010");
            acct4 = findAccountbyAccountNo(accounts, "5500");
            //check idenfity when withdrawing
            if ((cust3 != null) && (acct3 != null) && (acct4 != null))
            {
                if (cust3.CustId == acct4.OwnerId)
                    acct4.Withdraw(5000m, "CAD");
                //check idenfity when transferring
                if ((cust3.CustId == acct3.OwnerId) && (cust3.CustId == acct4.OwnerId))
                    Transfer(7300m, "CAD", acct3, acct4);
                acct3.Deposit(13726m, "MXN");               
                Console.WriteLine(acct3);
                Console.WriteLine(acct4);
            }
            else Console.WriteLine("Invalid Customer Name or Accout Number");

            //case4
            Console.WriteLine("Output 4:");
            cust4 = findCustomerbyName(custs, "Peter", "Griffin");
            cust5 = findCustomerbyName(custs, "Lois", "Griffin");
            acct5 = findAccountbyAccountNo(accounts, "0123");
            acct6 = findAccountbyAccountNo(accounts, "0456");
            if ((cust4 != null) && (cust5 != null) && (acct5 != null) && (acct6 != null))
            {
                if (cust4.CustId == acct5.OwnerId)
                    acct5.Withdraw(70m, "USD");
                acct6.Deposit(23789m, "USD");
                if (cust5.CustId == acct6.OwnerId)
                    Transfer(23.75m, "CAD", acct6, acct5);
                Console.WriteLine(acct5);
                Console.WriteLine(acct6);
            }
            else Console.WriteLine("Invalid Customer Name or Accout Number");


            Console.WriteLine("\n\nPress any key to finish");
            Console.ReadKey();

        }
    }
}
