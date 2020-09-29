using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBH
{
    class Program
    {
        static Bok[] bok = new Bok[8];
        static Bok[] korg = new Bok[8];
        static Order ord = new Order("");
        static double totalkartong;
        static double  FraktPris;
        static Order orderNr = new Order("");
        static int rst;

       
        static void Main(string[] args)
        {
           
            Start();
        }
        public static void Start()
        {

            try
            {

                Console.Write("Välkommen till Newtons Bokhandel!");
                Console.WriteLine("\t\n\n\tMENU\n\nTryck 1 för att beställa.\nTryck 2 för att hantera leverans. \nTryck 3 för att avsluta.");

                int val1 = int.Parse(Console.ReadLine());
                switch (val1)
                {
                    case 1:
                        Console.Clear();
                        Böcker();
                        break;
                    case 2:
                        Leverans();
                        break;
                    case 3:
                        break;
                    default:
                        Console.Clear();
                        Start();
                        Console.WriteLine("Ange ett nummer mellan 1-3");
                        break;
                }

            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Ange ett nummer mellan 1-3");
                Start();
            }
            

        }
        static void Leverans()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Leveranshantering \n\nTryck 1 för att få leverasen hemskickad.\ntryck 2 för att hämta din order i kassan.");

                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Ange din adress");
                        Order.Adress(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Tack för din beställning!");
                        Console.WriteLine("Varan skickas till" + " " + Order.Choise + " " + "leveransen kan ta 1-2 arbetsdagar");
                        Console.WriteLine("Ditt order ordernummer är:"); Order.Ordernummer();
                        Console.WriteLine("Antal katong:{0}", Kartonguträkning());
                        Console.WriteLine("Vikten på din beställning är :" + Viktpris() + "g");
                        Console.WriteLine("Frakten kostar:{0} kr", Fraktpris());
                        Console.WriteLine("Antal böcker kvar :{0} ", rest());
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Tack för din beställning!");
                        Console.WriteLine("Paketerna hämtas på Newtons bokhandel.");
                        Console.WriteLine("ange:"); Order.Ordernummer();
                        Console.WriteLine("Antal katong : {0}", Kartonguträkning());
                        Console.WriteLine("Antal böcker kvar :{0} ", rest());

                        break;
                    default:

                        Console.WriteLine("Ange ett nummer mellan 1-2");
                        Leverans();

                        break;
                }
            }
            catch (OverflowException)
            {
                Console.Clear();
                Console.WriteLine("Ange ett nummer mellan 1-2");
                Leverans();
            }
        } 

         public static void Böcker()
         {
            bok[0] = new Bok("Små eldar överallt", "Celeste Ng", 105, 250, 223, 0);
            bok[1] = new Bok("Skönhetens väg", "Martha Hall Kelly", 95, 293, 390,0);
            bok[2] = new Bok("Resten av allt är vårt", "Emma Hamberg", 249, 493, 201, 0);
            bok[3] = new Bok("Tidlös skönhet", "Emma Wiklund", 394, 437, 291,0);
            bok[4] = new Bok("Texter", "Thåström,", 304, 230, 321,0);
            bok[5] = new Bok("Hon som måste dö", "David Lagercrantz", 203, 463, 329 ,0);
            bok[6] = new Bok("Resten av allt är vårt", "Emma Hamberg", 290, 372, 216 ,0);
            bok[7] = new Bok("Your best life", "Kartonnage", 273, 478, 216,0);

            int val = 0;
            while (val!=9)
            {
                try
                {


                    int a = 1;

                    foreach (Bok b in bok)
                    {
                        Console.WriteLine(a + " " + b.Titel + " " + b.Förfatare + " " + b.Pris + "kr" + " " + b.Sidor + "sidor" + " " + b.Vikt + "g");
                        a++;

                    }
                    Console.WriteLine("\nVilken bok vill du köpa? \nTryck 9 för att avsluta din beställning.");

                    val = int.Parse(Console.ReadLine());

                    if (1 <= val && val <= 8)
                        
                       
                    {
                        Console.Clear();
                        int svar1 = FrågaAntal(bok[val-1]);
                        Console.WriteLine("Du har köpt " + svar1 + " st " + bok[val-1].Titel + "\nTryck enter för att köpa fler böcker eller fortsätta");
                        Console.ReadLine();
                        Console.Clear();
                        Adderabok(bok[val-1]);
                        Console.WriteLine();
                    }


                    if (val == 9)
                    {
                        string val1 = " ";
                        Console.Clear();
                        Console.WriteLine("vill du avsluta ditt köp ja/nej?");
                        
                        val1 = (Console.ReadLine());
                       
                        if (val1 == "ja")
                        {
                            Console.Clear();
                            Console.WriteLine("Du har valt att köpa:"); PrintautBok();
                            Console.WriteLine("Priset på din beställning är :" + Totalpris() + "kr");
                            Console.WriteLine("Tryck enter för att gå till huvudmenyn");
                            Console.ReadLine();
                            Console.Clear();
                            Start();
                        }
                        if (val1 == "nej")
                        {
                            Console.Clear();
                            Böcker();

                        }
                    }
                }
                catch(Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Ange ett nummer mellan 1-8");
                    Böcker();
                }
                

            }
            


         }
       

        public static void Adderabok(Bok bok)
        {
            for (int i = 0; i < korg.Length; i++)
            {
                if (korg[i] == null)
                {

                    korg[i] = new Bok(bok.Titel, bok.Förfatare, bok.Pris, bok.Sidor, bok.Vikt, bok.Antal);
                    break;
                }
            }
        }

        public static int FrågaAntal(Bok valbok)
        {
            Console.WriteLine("Hur många böcker vill du köpa?");
            int svar1 = int.Parse(Console.ReadLine());
            valbok.Antal = svar1;
            return svar1;
        }
        public static void PrintautBok()
        {
            try
            {
                for (int i = 0; i < korg.Length; i++)
                {
                    if (korg[i] != null)
                    {
                        Console.WriteLine(korg[i].Titel);
                    }
                    else
                    {
                        break;
                    }

                }

            }
            catch (NullReferenceException)
            {

            }
        }
        public static double Fraktpris()
        {
            if (Math.Ceiling(totalkartong) == 0)
            {
                totalkartong++;
            }
            if (Math.Ceiling(totalkartong) <= 5)

            {
                FraktPris = Math.Ceiling(totalkartong) * 8;
            }
            else if (Math.Ceiling(totalkartong) >= 6 && Math.Ceiling(totalkartong) <= 50)
            {
                FraktPris = Math.Ceiling(totalkartong) * 5;
            }
            return FraktPris;
        }
        public static double Viktpris()
        {
            double totalVikt = 0;
            try
            {

                foreach (Bok nybok in korg)
                {
                    totalVikt += nybok.Vikt * nybok.Antal;
                }
            }
            catch (NullReferenceException)
            {

            }
            return totalVikt;

        }
        public static double Kartonguträkning()
        {
            try
            {
                foreach (Bok nybok in korg)
                {
                    Math.Ceiling(totalkartong += (nybok.Antal) / 5);

                }

            }
            catch (NullReferenceException)
            {

            }
            return Math.Ceiling(totalkartong);
        }
        public static double Totalpris()
        {
            double totalPris = 0;
            try
            {
                foreach (Bok nybok in korg)
                {
                    totalPris += nybok.Pris * nybok.Antal;
                }

            }
            catch (NullReferenceException)
            {

            }
            return totalPris;
        }
        public static int rest()
        {
          try
             {
             for (int i = 0; i < korg.Length; i++)



             {
                    rst += korg[i].Antal % 5;
             }
                
          }catch (NullReferenceException)
            {

            }
            return rst;
        }
    }   


}
