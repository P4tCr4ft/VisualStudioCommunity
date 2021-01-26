using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBankExtended
{
    public class InterestEarningAccount : BankAccount
    {
        // Constructor
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                var interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }
        }
    }
}
