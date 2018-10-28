using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkatLibrary
{
    interface IAccount
    {
        // зачисление денег за заказ
        void Put(decimal sum);
        // возврат средств
        decimal Withdraw(decimal sum);
    }
}
