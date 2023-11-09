using System;

namespace Lesson_8.Tumakov
{
    public enum BankAccountType
    {
        Savings,
        Checking,
        Credit
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Упражнение 9.2 и 9.3");
            BankAccount account1 = new BankAccount(1000.00, BankAccountType.Checking);

            Console.WriteLine("Информация о счете (Счет 1):");
            account1.PrintAccountInfo();

            account1.Deposit(500.00);
            account1.Withdraw(200.00);

            Console.WriteLine("Обновленная информация о счете (Счет 1):");
            account1.PrintAccountInfo();

            Console.WriteLine("\nИстория транзакций (Счет 1):");
            account1.PrintTransactionHistory();
        }
    }
}


