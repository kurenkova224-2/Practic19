using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic19_1
{
    public class NotEnoughMoney : Exception
    {
        public decimal Balance { get; }
        public decimal Amount { get; }

        public NotEnoughMoney(decimal balance, decimal amount) :
            base($"Недостаточно средств. Баланс : {balance}. Нужно : {amount}")
        { Balance = balance; Amount = amount; }

    }

    public class PIN : Exception
    {
        public int Attempts { get; }
        public PIN(int attempts) : base($"Неверный PIN. Осталось попыток : {attempts}")
        {
            Attempts = attempts;
        }
    }

    class Bank
    {
        private decimal balance;
        private int CorrectPIN = 2288;
        private int attempts = 3;
        private bool isCardBlocked = false;

        public Bank(decimal initialBalance)
        {
            balance = initialBalance;
            Console.WriteLine($"Банкомат с балансом : {initialBalance}");
        }

        public void Withdraw(decimal amount)
        {
            if (isCardBlocked)
            {
                throw new InvalidOperationException("Карта заблокирована");
            }
            Console.WriteLine($"Баланас : {balance}");
            Console.WriteLine($"Снимаем : {amount}");

            if (amount > balance)
            {
                throw new NotEnoughMoney(balance, amount);
            }
            balance -= amount;
            Console.WriteLine($"Снято : {amount}. Баланс : {balance}");
        }

        public void EnterPIN(int pin)
        {
            if (isCardBlocked)
            {
                Console.WriteLine("Карта заблокирована");
                throw new InvalidOperationException("Карта заблокирована");
            }

            if (pin == CorrectPIN)
            {
                Console.WriteLine("Верный PIN. Доступ разрешен");
                attempts = 3;
            }
            else
            {
                attempts--;
                Console.WriteLine($"Неверный PIN. Осталось попыток: {attempts}");
                if (attempts <= 0)
                {
                    isCardBlocked = true;
                    Console.WriteLine("Карта заблокирована");
                    throw new InvalidOperationException("Карта заблокирована");
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank(5000);

            try
            {
                bank.Withdraw(10000);
            }
            catch (NotEnoughMoney ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine();


            Bank bank1 = new Bank(10000);
            Console.WriteLine("Ввод PIN: 2288");
            try
            {
                bank1.EnterPIN(0000);
            }
            catch (PIN ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("Ввод PIN: 1111");
            try
            {
                bank1.EnterPIN(1111);
            }
            catch (PIN ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("Ввод PIN: 9999");
            try
            {
                bank1.EnterPIN(9999);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    
    }
}
