using System;
using System.Collections.Generic;

namespace Les6Oefening
{
    public partial class Airplane
    {
        private string vluchtCode;

        public string FlightCode {
            get { return vluchtCode; }
            set
            {
                if (value.Length > 10)
                {
                    vluchtCode = value.Substring(0, 10);
                }
                else
                {
                    vluchtCode = value;
                }
            }
        }
        public string Maintenance { get; set; }
        public bool AirBorn { get; set; }

        public void Land()
        {
            int random = new Random().Next(0, 11);
            if (random > 7)
            {
                Maintenance = "Groot";
            }
            else if (random > 3)
            {
                Maintenance = "Klein";
            }
            else
            {
                Maintenance = "Geen";
            }
            AirBorn = false;
        }

        public void StijgOp()
        {
            AirBorn = true;
        }
    }
}
