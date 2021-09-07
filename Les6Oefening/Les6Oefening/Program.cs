using System;
using System.Linq;

namespace Les6Oefening
{
    class Program
    {
        static void Main(string[] args)
        {
            string keuze = string.Empty;
            string stop = "7";
            string vluchtCode = string.Empty;
            ControleToren controleToren = new ControleToren();
            AirplanesDbContext db = new AirplanesDbContext();

            while (keuze != stop)
            {
                Console.Clear();
                Console.WriteLine("Controletoren menu");
                Console.WriteLine("1. Overzicht vliegtuigen");
                Console.WriteLine("2. Meld nieuw vliegtuig aan");
                Console.WriteLine("3. Toestemming tot landen");
                Console.WriteLine("4. Toestemming tot opstijgen");
                Console.WriteLine("5. Verwijderen uit luchtruim");
                Console.WriteLine("6. Onderhoud van alle vliegtuigen");
                Console.WriteLine("7. Stop");
                Console.Write("> ");
                keuze = Console.ReadLine();

                switch (keuze)
                {
                    case "1":
                        var queryOverzicht =
                            from a in db.Airplane
                            select new
                            {
                                vluchtcode = a.FlightCode,
                                onderhoud = a.Maintenance,
                                airborn = a.AirBorn
                            };

                        foreach(var o in queryOverzicht)
                        {
                            Console.WriteLine($"{o.vluchtcode}".PadRight(20) + $"{o.onderhoud}".PadRight(20) + $"{o.airborn}");
                        }
                        break;
                    case "2":
                        Console.Write("Geef de code in van het inkomende vliegtuig: ");
                        vluchtCode = Console.ReadLine();
                        Console.WriteLine(controleToren.MeldVliegtuigAan(vluchtCode));
                        break;
                    case "3":
                        Console.Write("Toestemming voor landen voor code: ");
                        vluchtCode = Console.ReadLine();
                        Console.WriteLine(controleToren.ToestemmingTotLanden(vluchtCode));
                        break;
                    case "4":
                        Console.Write("Toestemming voor opstijgen voor code: ");
                        vluchtCode = Console.ReadLine();
                        Console.WriteLine(controleToren.ToestemmingTotOpstijgen(vluchtCode));
                        break;
                    case "5":
                        Console.Write("Te verwijderen vlucht code: ");
                        vluchtCode = Console.ReadLine();
                        Console.WriteLine(controleToren.VerwijderUitLuchtruim(vluchtCode));
                        break;
                    case "6":
                        int aantal = controleToren.RepareerVliegtuigen();
                        Console.WriteLine("Aantal gerepareerde toestellen: " + aantal);
                        break;
                    default:
                        break;
                }
                if (keuze != stop)
                {
                    Console.WriteLine("Druk op een toets om verder te gaan");
                    Console.ReadKey();
                }
            }
        }
    }
}
