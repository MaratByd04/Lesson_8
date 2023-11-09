using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson_8.Tumakov
{
    public class BankAccount : IDisposable
    {
        private static int nextAccountNumber = 1;

        private string accountNumber;
        private double balance;
        private BankAccountType accountType;
        private Queue<BankTransaction> transactionHistory;

        public BankAccount()
        {
            this.accountNumber = GenerateAccountNumber();
            this.transactionHistory = new Queue<BankTransaction>();
        }

        public BankAccount(double initialBalance) : this()
        {
            this.balance = initialBalance;
        }

        public BankAccount(BankAccountType accountType) : this()
        {
            this.accountType = accountType;
        }

        public BankAccount(double initialBalance, BankAccountType accountType) : this()
        {
            this.balance = initialBalance;
            this.accountType = accountType;
        }

        public string GetAccountNumber()
        {
            return accountNumber;
        }

        public double GetBalance()
        {
            return balance;
        }

        public BankAccountType GetAccountType()
        {
            return accountType;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                transactionHistory.Enqueue(new BankTransaction(amount));
                Console.WriteLine($"Внесено ${amount:C2}");
            }
            else
            {
                Console.WriteLine("Неверная сумма.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && balance >= amount)
            {
                balance -= amount;
                transactionHistory.Enqueue(new BankTransaction(-amount));
                Console.WriteLine($"Снято ${amount:C2}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств или неверная сумма вывода.");
            }
        }

        public void Transfer(BankAccount targetAccount, double amount)
        {
            if (amount > 0 && balance >= amount)
            {
                balance -= amount;
                targetAccount.Deposit(amount);
                transactionHistory.Enqueue(new BankTransaction(-amount));
                Console.WriteLine($"Переведено ${amount:C2} на счет {targetAccount.GetAccountNumber()}");
            }
            else
            {
                Console.WriteLine("Сбой перевода. Недостаточно средств или неверная сумма перевода.");
            }
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер Счета: {accountNumber}");
            Console.WriteLine($"Баланс: {balance:C2}");
            Console.WriteLine($"Тип счета: {accountType}");
        }

        private string GenerateAccountNumber()
        {
            string generatedNumber = $"Счет - {nextAccountNumber:D5}";
            nextAccountNumber++;
            return generatedNumber;
        }

        public void PrintTransactionHistory()
        {
            Console.WriteLine("История транзакций по счету " + accountNumber);
            foreach (var transaction in transactionHistory)
            {
                Console.WriteLine($"Дата: {transaction.TransactionDate}, Сумма: {transaction.Amount:C2}");
            }
        }
        /// <summary>
        /// Метод для упражнения 9.3
        /// </summary>
        public void Dispose()
        {
            using (StreamWriter writer = new StreamWriter("BankTransactionHistory.txt", true))
            {
                writer.WriteLine($"Transaction History for Account {accountNumber}");
                foreach (var transaction in transactionHistory)
                {
                    writer.WriteLine($"Date: {transaction.TransactionDate}, Amount: {transaction.Amount:C2}");
                }
            }

            GC.SuppressFinalize(this);
        }
    }
}
