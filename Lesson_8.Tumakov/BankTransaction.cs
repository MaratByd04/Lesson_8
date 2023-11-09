using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8.Tumakov
{
    public class BankTransaction
    {

        public readonly DateTime TransactionDate;
        public readonly double Amount;

        public BankTransaction(double amount)
        {
            TransactionDate = DateTime.Now;
            Amount = amount;
        }

    }
}
