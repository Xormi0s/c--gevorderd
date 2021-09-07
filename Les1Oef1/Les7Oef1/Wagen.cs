using System;
using System.Collections.Generic;
using System.Text;

namespace Les7Oef1
{
    class Wagen
    {
        private decimal prijs;
        private string nummerplaat;

        public override string ToString()
        {
            string output = "Nummerplaat: " + nummerplaat + " / Catalogusprijs: " + prijs;
            return output;
        }

        public virtual decimal VAA()
        {
            return 0;
        }

        public decimal Prijs {
            get
            {
                return this.prijs;
            }
            set
            {
                this.prijs = value;
            }
        }
        public string Nummerplaat {
            get
            {
                return this.nummerplaat;
            }
            set
            {
                this.nummerplaat = value;
            }
        }
    }
}
