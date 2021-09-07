using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Les6Oefening
{
    class ControleToren
    {
        AirplanesDbContext db = new AirplanesDbContext();
        public string MeldVliegtuigAan(string vluchtCode)
        {
            var queryVoegtoe =
                from a in db.Airplane
                where a.FlightCode == vluchtCode
                select new
                {
                    vluchtcode = a.FlightCode
                };

            if(queryVoegtoe.Count() > 0)
            {
                return "Vluchtcode werd reeds toegewezen.";
            } else
            {
                Airplane vliegtuig = new Airplane
                {
                    FlightCode = vluchtCode,
                    AirBorn = true,
                    Maintenance = "Geen"
                };

                db.Airplane.Add(vliegtuig);
                db.SaveChanges();
                return "Vliegtuig met code " + vluchtCode + " werd aangemeld.";
            }
        }

        public string ToestemmingTotLanden(string vluchtCode)
        {
            if (ZoekVliegtuig(vluchtCode))
            {
                Airplane vliegtuig = db.Airplane.Find(vluchtCode);
                if(vliegtuig.AirBorn == false)
                {
                    return "Vliegtuig met code " + vluchtCode + " is al reeds geland.";
                } else
                {
                    vliegtuig.Land();
                    db.SaveChanges();
                    return "Vliegtuig " + vluchtCode + " is geland.";
                }
            } else
            {
                return "Vliegtuig " + vluchtCode + " is niet gekend in het systeem.";
            }
        }
        public string ToestemmingTotOpstijgen(string vluchtCode)
        {
            if (ZoekVliegtuig(vluchtCode))
            {
                Airplane vliegtuig = db.Airplane.Find(vluchtCode);
                if (vliegtuig.AirBorn == false)
                {
                    TechnischeDienst technischeDienst = new TechnischeDienst();
                    bool reparatieUitgevoerd = technischeDienst.VoerOnderhoudUit(vliegtuig);
                    vliegtuig.StijgOp();
                    db.SaveChanges();
                    return "Vliegtuig " + vluchtCode + " is opgestegen." + (reparatieUitgevoerd ? " (+ reparatie uitgevoerd)" : "");
                }
                else
                {
                    return "Vliegtuig " + vluchtCode + " was reeds opgestegen.";
                }
            }
            else
            {
                return "Vliegtuig " + vluchtCode + " is niet gekend in het systeem.";
            }
        }

        public string VerwijderUitLuchtruim(string vluchtCode)
        {
            if (ZoekVliegtuig(vluchtCode))
            {
                Airplane vliegtuig = db.Airplane.Find(vluchtCode);
                db.Remove(vliegtuig);
                db.SaveChanges();
                return "Vliegtuig " + vluchtCode + " verliet het luchtruim.";
            }
            else
            {
                return "Vliegtuig " + vluchtCode + " is niet gekend in het systeem.";
            }
        }

        private bool ZoekVliegtuig(string vluchtCode)
        {
            var queryZoekVliegtuig =
                from a in db.Airplane
                where a.FlightCode == vluchtCode
                select new
                {
                    vluchtcode = a.FlightCode
                };

            if (queryZoekVliegtuig.Count() > 0)
            {
                return true;
            }

            return false;
        }

        public int RepareerVliegtuigen()
        {
            TechnischeDienst technischeDienst = new TechnischeDienst();

            return technischeDienst.VoerOnderhoudUitAlles();
        }
    }
}
