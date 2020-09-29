using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBH
{
    class Order
    {
        private static string choise;

        
        public  Order(string Choise)
        {
            choise = Choise;
        }
        public static string Choise
        {
            get
            {
                return choise;
            }
            set
            {
                choise = value;
            }
        }
        public static int Ordernummer()
        {
            Random r = new Random();
            int tal = r.Next(1000, 9999);
            Console.WriteLine(tal);


            return tal;

        }
        public static void Adress(string svar)
        {

            Order.Choise = svar;
        }

    }
   
}
