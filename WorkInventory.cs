using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class WorkInventory : Inventory
    {
        //Виртуальное свойство
        public virtual string Otv_lico //Ответственное лицо
        {
            get; set;
        }
        public virtual string dostup //Список доступных лиц
        {
            get; set;
        }
        //

        public WorkInventory(string data_post, int srok_god, string type, string Otv_lico, string dostup): base(data_post,srok_god,type)
        {

            this.Otv_lico = Otv_lico;
            this.dostup = dostup;
        }

        public void reWriteWorkInventory()
        {
            Console.WriteLine("Дата поступления: {0}\nСрок годности: {1}\nТип инвентаря {2}\nОтветственное лицо: {3}\nДоступ: {4}\n", data_post, srok_god, type, Otv_lico, dostup);
        }

        // Переопределение для виртуального метода
        public override string InventoryInfo()
        {
            // Используется ссылка на метод, определенный в базовом классе Inventory
            return base.InventoryInfo() + "\nОтветственное лицо: " + Otv_lico + "\nДоступ: " + dostup + "\n";
        }


    }
}
