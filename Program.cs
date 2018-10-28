using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProkatLibrary;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Prokat<Account> prokat = new Prokat<Account>("Прокат СнежКом");
            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen; // выводим список команд зеленым цветом
                Console.WriteLine("1. Открыть день \n 2. оформить возврат  \n 3. Добавить оплату");
                Console.WriteLine("4. Закрыть день \n 5. Пропустить день \n 6. Выйти из программы");
                Console.WriteLine("Введите номер пункта:");
                Console.ForegroundColor = color;
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            OpenAccount(prokat);
                            break;
                        case 2:
                            Withdraw(prokat);
                            break;
                        case 3:
                            Put(prokat);
                            break;
                        case 4:
                            CloseAccount(prokat);
                            break;
                        case 5:
                            break;
                        case 6:
                            alive = false;
                            continue;
                    }
                    
                }
                catch (Exception ex)
                {
                    // выводим сообщение об ошибке красным цветом
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }

        private static void OpenAccount(Prokat<Account> prokat)
        {
            Console.WriteLine("Укажите сумму для создания счета:");

            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Введите 1");
            AccountType accountType;

            int type = Convert.ToInt32(Console.ReadLine());

            if (type == 2)
                accountType = AccountType.Deposit;
            else
                accountType = AccountType.Ordinary;

            prokat.Open(accountType,
                sum,
                AddSumHandler,  // обработчик добавления средств на счет
                WithdrawSumHandler, // обработчик вывода средств
                (o, e) => Console.WriteLine(e.Message), // обработчик начислений процентов в виде лямбда-выражения
                CloseAccountHandler, // обработчик закрытия счета
                OpenAccountHandler); // обработчик открытия счета
        }

        private static void Withdraw(Prokat<Account> prokat)
        {
            Console.WriteLine("Укажите сумму для возврата средств:");

            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Введите id дня:");
            int id = Convert.ToInt32(Console.ReadLine());

            prokat.Withdraw(sum, id);
        }

        private static void Put(Prokat<Account> prokat)
        {
            Console.WriteLine("Укажите сумму, оплаченного заказа:");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Введите Id дня:");
            int id = Convert.ToInt32(Console.ReadLine());
            prokat.Put(sum, id);
        }

        private static void CloseAccount(Prokat<Account> prokat)
        {
            Console.WriteLine("Введите id дня, который надо закрыть:");
            int id = Convert.ToInt32(Console.ReadLine());

            prokat.Close(id);
        }
        // обработчики событий класса Account
        // обработчик открытия счета
        private static void OpenAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // обработчик добавления денег на счет
        private static void AddSumHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // обработчик вывода средств
        private static void WithdrawSumHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
            if (e.Sum > 0)
                Console.WriteLine("Все круто!");
        }
        // обработчик закрытия счета
        private static void CloseAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}