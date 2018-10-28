using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkatLibrary
{
    interface IAccount
    {
        //Вернуть ченить
        void Put(decimal sum);
        //Заплатить за аренду
        decimal Withdraw(decimal sum);

    }
}
