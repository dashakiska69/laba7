using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    //Производный класс 2 уровня
    class WorkInventoryForClients : WorkInventory
    {
        public string dopusk_age //Допустимый возвраст
        {
            get; set;
        }
        public string safety_regulations //Правила безопасности
        {
            get; set;
        }
        public WorkInventoryForClients(string data_post, int srok_god, string type, string Otv_lico, string dostup, string dopusk_age, string safety_regulations) : base(data_post, srok_god, type,Otv_lico ,dostup)
        {
            this.dopusk_age = dopusk_age;
            this.safety_regulations = safety_regulations;
        }
        //Переопределяем виртуальный метод
        public override string InventoryInfo()
        {
            //Ccskrf yf vtnjl jghtltktyysq d ghjbpdjlyjv rkfcct ЦщклШтмутещкн
            return base.InventoryInfo() + "\nДопустимый возвраст: " + dopusk_age + "\nПравила безопасности: " + safety_regulations + "\n\n";
        }
    }
}
