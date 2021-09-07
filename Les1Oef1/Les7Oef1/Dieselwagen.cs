using System;
using System.Collections.Generic;
using System.Text;

namespace Les7Oef1
{
    class Dieselwagen:Wagen
    {
        private int nox;

        public override string ToString()
        {
            string output = " / NOx: " + nox;
            return base.ToString() + output;
        }

        public override decimal VAA()
        {
            decimal output =  (Prijs * nox)/1000;
            return output;
        }

        public int Nox
        {
            get
            {
                return nox;
            }
            set
            {
                this.nox = value;
            }
        }
    }
}
