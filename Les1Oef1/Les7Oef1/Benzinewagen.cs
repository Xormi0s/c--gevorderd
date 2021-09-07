using System;
using System.Collections.Generic;
using System.Text;

namespace Les7Oef1
{
    class Benzinewagen:Wagen
    {
        int co2;

        public override string ToString()
        {
            string output = " / CO2: " + co2;
            return base.ToString() + output;
        }

        public override decimal VAA()
        {
            decimal output = (Prijs * co2)/1000;
            return output;
        }

        public int Co2
        {
            get
            {
                return co2;
            }
            set
            {
                this.co2 = value;
            }
        }
    }
}
