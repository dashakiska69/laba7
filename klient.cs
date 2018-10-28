using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class klient
    {
        private Ticket _Klientsiy_Ticket;
        
        // Поля класса
        private string Name {
            get; set;
        }
        public string Gender
        {
            get; set;
        }
        public Ticket Klientsiy_Ticket
        {
            get
            {
                if (_Klientsiy_Ticket == null)
                {
                    Console.WriteLine("Нет билета у клиента:с");
                    return null;
                }
                else  return _Klientsiy_Ticket;

            }
             set
            {
                this._Klientsiy_Ticket = value;
            }
        }
        public int Age
        {
            get; set;
        }



        // Метод, выводящий в консоль контактную информацию
       

        //Конструктор
        public klient(string Name, string Gender, Ticket Klientsiy_Ticket, int Age) //Полный конструктор
        {
            this.Name = Name;
            this.Gender = Gender;
            this.Klientsiy_Ticket = Klientsiy_Ticket;

            this.Age = Age;
            
        }
        //public void reWrite()
        //{
        //    Console.WriteLine("Имя: {0}\nПол: {1}\nИнформация в чеке: {2}\nВозраст: {3}\n", Name, Gender, Klientsiy_Ticket, Age);
        //    Klientsiy_Ticket.reWriteTicket();
        //}

        public void reWrite()
        {
            Console.WriteLine("Имя: {0}\nПол: {1}\nИнформация в чеке {2}", Name, Gender,Klientsiy_Ticket);
            Console.WriteLine("Возраст: {0}\n", Age);
        }



        //Деструктор
        ~klient()
        {
            Console.WriteLine("Клиент:");
    }
    }

    
}
