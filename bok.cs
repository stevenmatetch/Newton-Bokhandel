using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBH
{
    class Bok
    {

        private string titel;
        private int pris;
        private string förfatare;
        private int sidor;
        private int vikt;
       
        private int antal;
        public Bok()
        {
        }

        public Bok(string titel, string förfatare, int pris, int sidor, int vikt, int antal)
        {
            this.titel = titel;
            this.förfatare = förfatare;
            this.sidor = sidor;
            this.pris = pris;
            this.vikt = vikt;
            this.antal = antal;
            
        }
        public string Titel
        {
            get
            {
                return titel;
            }
            set
            {
                titel = value;
            }
        }
        public string Förfatare
        {
            get
            {
                return förfatare;
            }
            set
            {
                förfatare = value;
            }
        }
        public int Sidor
        {
            get
            {
                return sidor;
            }
            set
            {
                sidor = value;
            }
        }
        public int Pris
        {
            get
            {
                return pris;
            }
            set
            {
                pris = value;
            }

        }
        public int Vikt
        {
            get
            {
                return vikt;
            }
            set
            {
                vikt = value;
            }
        }
        public int  Antal
        {
            get
            {
                return antal;
            }
            set
            {
                antal = value;
            }
        }
       
    }
}
 