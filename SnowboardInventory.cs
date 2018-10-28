using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class SnowboardInventory : Inventory
    {
        public int height //Ростовка сноуборда
        {
            get; set;
        }
        public string typeProgib //Тип прогиба
        {
            get; set;
        }

        public SnowboardInventory(string data_post, int srok_god, string type, int height, string typeProgib): base(data_post,srok_god,type)
        {

            this.height = height;
            this.typeProgib = typeProgib;
        }

        public void reWriteSnowboardInventory()
        {
            Console.WriteLine("Дата поступления: {0}\nСрок годности: {1}\nТип инвентаря {2}\nДлинна сноуборда: {3}\nТип прогиба: {4}\n", data_post, srok_god, type, height, typeProgib);
        }
    }
}
