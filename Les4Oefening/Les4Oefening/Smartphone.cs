using System;
using System.Collections.Generic;
using System.Text;

namespace Les4Oefening
{
    class Smartphone
    {
        private int connectiesnelheid;
        private string model;

        public Smartphone(string model, int snelheid)
        {
            this.model = model;

            if(snelheid >= 0)
            {
                this.connectiesnelheid = snelheid;
            } else
            {
                throw new Exception("Connectiesnelheid mag niet negatief zijn");
            }
        }
        public bool Verbind(int connectiesnelheid)
        {
            bool output;
            if(this.connectiesnelheid >= connectiesnelheid)
            {
                output = true;
            } else
            {
                output = false;
            }
            return output;
        }

        public override string ToString()
        {
            return "Smartphone " + model + " / Connectie snelh.: " + connectiesnelheid;
        }
    }
}
