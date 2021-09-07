using System;
using System.Collections.Generic;
using System.Text;

namespace Les2Oef1
{
    class Postit: IPrintMessage
    {
        private string naam;
        private string locatie;
        private string message;

        public string Naam
        {
            get
            {
                return this.naam;
            }
            set
            {
                this.naam = value;
            }
        }

        public string Locatie
        {
            get
            {
                return this.locatie;
            }
            set
            {
                this.locatie = value;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }

        public void GetMessageInfo()
        {
            Console.WriteLine("--- Postit ---");
            Console.WriteLine("\tVan: " + this.naam + "\n\tLocatie: " + this.locatie + "\n\tBericht: " + this.message);
        }

        public override string ToString()
        {
            return "Postit - " + this.locatie;
        }

    }
}
