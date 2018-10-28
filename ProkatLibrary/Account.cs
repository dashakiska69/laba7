using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkatLibrary
{
    public abstract class Account : IAccount
    {
        //Событие, возникающее при возврате денег
        protected internal event AccountStateHandler Withdrawed;
        // Событие возникающее при добавление денег на счет
        protected internal event AccountStateHandler Added;
        // Событие возникающее при открытии нового дня
        protected internal event AccountStateHandler Opened;
        // Событие возникающее при закрытии дня
        protected internal event AccountStateHandler Closed;


        protected int _id;
        static int counter = 0;

        protected decimal _sum; // Переменная для хранения суммы
        protected int _percentage; // Переменная для хранения процента

        protected int _days = 0; // время с момента открытия счета

        public Account(decimal sum, int percentage)
        {
            _sum = sum;
          
            _id = ++counter;
        }

        // Текущая сумма на счету
        public decimal CurrentSum
        {
            get { return _sum; }
        }

        public int Percentage
        {
            get { return _percentage; }
        }

        public int Id
        {
            get { return _id; }
        }
        // вызов событий
        private void CallEvent(AccountEventArgs e, AccountStateHandler handler)
        {
            if (handler != null && e != null)
                handler(this, e);
        }
        // вызов отдельных событий. Для каждого события определяется свой витуальный метод
        protected virtual void OnOpened(AccountEventArgs e)
        {
            CallEvent(e, Opened);
        }
        protected virtual void OnWithdrawed(AccountEventArgs e)
        {
            CallEvent(e, Withdrawed);
        }
        protected virtual void OnAdded(AccountEventArgs e)
        {
            CallEvent(e, Added);
        }
        protected virtual void OnClosed(AccountEventArgs e)
        {
            CallEvent(e, Closed);
        }
    
        public virtual void Put(decimal sum)
        {
            _sum += sum;
            OnAdded(new AccountEventArgs("Оплата за заказ" + sum, sum));
        }
        public virtual decimal Withdraw(decimal sum)
        {
            decimal result = 0;
            if (sum <= _sum)
            {
                _sum -= sum;
                result = sum;
                OnWithdrawed(new AccountEventArgs("Сумма " + sum + " возвращена за заказ" + _id, sum));
            }
            else
            {
                OnWithdrawed(new AccountEventArgs("Недостаточно денег в кассе" + _id, 0));
            }
            return result;
        }
        // открытие счета
        protected internal virtual void Open()
        {
            OnOpened(new AccountEventArgs("Открыт новый отчёт за день !Id рабочего дня: " + this._id, this._sum));
        }
        // закрытие счета
        protected internal virtual void Close()
        {
            OnClosed(new AccountEventArgs("день № " + _id + " закрыт.  Итоговая прибыль за день составляет: " + CurrentSum, CurrentSum));
        }

        protected internal void IncrementDays()
        {
            _days++;
        }
       
    }
}
