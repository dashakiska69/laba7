using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Ticket
    {
        public int summ
        {
            get; set;
        }
        public int id
        {
            get; set;
        }
        public string Status
        {
            get; set;
        }

        public override string ToString()
        {
            return summ.ToString();
        }
        Random rnd = new Random();

        //Конструктор
        public Ticket(int summ, int id, string Status) //Полный конструктор
        {
            this.summ = summ;
            this.id = id;
            this.Status = Status;
        }
        public void reWriteTicket()
        {
            Console.WriteLine("Сумма чека: {0}\nНомер чека: {1}\nСтатус: {2}\n", summ, id, Status);
        }
    }
}
