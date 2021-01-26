﻿using System;

namespace SuperBankExtended
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Steve", 5000);
            Console.WriteLine($"Account {account.Number} was create for {account.Owner} with {account.Balance}");

            // Let's purchase something
            account.MakeWithdrawal(120, DateTime.Now, "keyboard");
            Console.WriteLine($"Your current balance {account.Owner} is {account.Balance}");

            // Let's test doing something wrong, but not wreck the whole program, and continue program after test,
            // Test that the initial balances must be positive.
            try
            {
                var invalidAccount = new BankAccount("Invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }

            // Test for a negative balance.
            try
            {
                account.MakeWithdrawal(75000, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }

            // purchase still occurs as wrong behaviour above caught and handled
            account.MakeWithdrawal(130, DateTime.Now, "bike gear");
            Console.WriteLine($"Your current balance {account.Owner} is {account.Balance}");

            // Get account transaction history
            Console.WriteLine(account.GetAccountHistory());

            // Test the 3 new accounts, derived from base class BankAccount
            var giftCard = new GiftCardAccount("gift card", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
            giftCard.PerformMonthEndTransactions();
            // can make additional deposits:
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount("savings account", 10000);
            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());

            var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
            // How much is too much to borrow?
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
            lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());
        }
    }
}