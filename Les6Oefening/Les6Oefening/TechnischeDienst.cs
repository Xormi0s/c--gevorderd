using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Les6Oefening
{
    class TechnischeDienst
    {
        AirplanesDbContext db = new AirplanesDbContext();
        public bool VoerOnderhoudUit(Airplane vliegtuig)
        {
            if (vliegtuig.Maintenance != "Geen")
            {
                vliegtuig.Maintenance = "Geen";
                return true;
            }
            else
            {
                return false;
            }
        }

        public int VoerOnderhoudUitAlles()
        {
            int aantal = 0;
            var queryOverzicht =
                (from a in db.Airplane
                select new
                {
                    vluchtcode = a.FlightCode,
                    onderhoud = a.Maintenance,
                    airborn = a.AirBorn
                }).ToList();

            foreach (var o in queryOverzicht)
            {
                if(o.onderhoud.ToString() != "Geen" && o.airborn == false)
                {
                    Airplane vliegtuig = db.Airplane.Find(o.vluchtcode);
                    vliegtuig.Maintenance = "Geen";
                    db.SaveChanges();
                    aantal++;
                }
            }
            return aantal;
        }
    }
}
