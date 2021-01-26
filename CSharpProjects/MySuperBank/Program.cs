using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Steve", 5000);
            //var account = new BankAccount("Steve");
            Console.WriteLine($"Account {account.Number} was create for {account.Owner} with {account.Balance}");

            account.Owner = "Rach";
            //account.Number = "AB124"; // We are not permitted to change this, as it is read only, has no set method.
            Console.WriteLine($"Account {account.Number} was create for {account.Owner} with {account.Balance}");

            // create another account with a new account number
            //var account2 = new BankAccount("Sophie", 250);
            //Console.WriteLine($"Account {account2.Number} was create for {account2.Owner} with {account2.Balance}");

            // Let's purchase something
            account.MakeWithdrawal(120, DateTime.Now, "keyboard");
            Console.WriteLine($"Your current balance {account.Owner} is {account.Balance}");

            // Lets try doing something wrong
            //account.MakeDeposit(-50, DateTime.Now, "hmmmm");

            // Let's test doing something wrong, but not wreck the whole program, and continue program on after test
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


        }
    }
}
