﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBankExtended
{
    public class GiftCardAccount : BankAccount
    {
        private decimal _monthlyDeposit = 0m;

        // Constructor
        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance) =>
            _monthlyDeposit = monthlyDeposit;

        public override void PerformMonthEndTransactions()
        {
            if (_monthlyDeposit != 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
            }
        }
    }
}