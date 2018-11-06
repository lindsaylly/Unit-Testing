using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;
using Xunit;

/* Sep.2018
 * Author: Lindsay
 * Purpose: code challenge for eComplaince
 */
namespace DemoLibrary.tests
{
    public class CheckingAccountTests
    { 
        public static IEnumerable<object[]> Data1 =>
        new List<object[]>
        {
            new object[] { "001", "1", 100m, 300m, "USD", 700m },//nomal input
            new object[] { "002", "2", -50m, 300m, "CAD", 300m },//bad input
            new object[] { "003", "3", 100m, -50m, "MXN", 100m },//bad input
            new object[] { "004", "4", 30m, 300m, "RMB", 30m }, //bad input
            new object[] { "005", "5", 0m, 0m, null, 0m }//bad input
        };

        public static IEnumerable<object[]> Data2 =>
        new List<object[]>
        {
            new object[] { "006", "6", 700m, 300m, "USD", 100m },//nomal input
            new object[] { "007", "7", -50m, 300m, "CAD", 0m },//bad input
            new object[] { "008", "8", 100m, -50m, "MXN", 100m },//bad input
            new object[] { "009", "9", 10000000m, 600m, "RMB", 10000000m }, //bad input
            new object[] { "010", "10", 0m, 0m, null, 0m }//bad input
        };

        [Theory]
        [MemberData(nameof(Data1))]
        public void Deposite_TestSimpleGoodAndBadInput(string accountNo, string ownerId, decimal initBalance, decimal amount, string currency, decimal expected)
        {
            // Arrange
            CheckingAccount account = new CheckingAccount(accountNo, ownerId, initBalance);            

            // Act
            account.Deposit(amount, currency);
            decimal actual = account.Balance;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Deposit_TestMultipleDeposit()
        {
            // Arrange
            CheckingAccount account = new CheckingAccount("011", "11", 100m);
            decimal expected = 730;

            // Act
            account.Deposit(300m, "USD");
            account.Deposit(300m, "MXN");
            decimal actual = account.Balance;

            // Assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [MemberData(nameof(Data2))]
        public void Withdraw_TestSimpleGoodAndBadInput(string accountId, string ownerId, decimal initBalance, decimal amount, string currency, decimal expected)
        {
            // Arrange
            CheckingAccount account = new CheckingAccount(accountId, ownerId, initBalance);

            // Act
            account.Withdraw(amount, currency);
            decimal actual = account.Balance;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Withdraw_TestMultipleWithdraw()
        {
            // Arrange
            CheckingAccount account = new CheckingAccount("012", "12", 1000m);
            decimal expected = 570;

            // Act
            account.Withdraw(400m, "CAD");
            account.Withdraw(300m, "MXN");
            account.Withdraw(300m, "USD");//ignore
            decimal actual = account.Balance;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToString_Test()
        {
            //Arrange
            CheckingAccount accout = new CheckingAccount("0", "0", 10m);
            string expected = "Account Number:0 Balance:$10.00 CAD";

            //Act
            string actual = accout.ToString();

            //Assert
            Assert.Equal(expected, actual);

        }

        
    }
}
