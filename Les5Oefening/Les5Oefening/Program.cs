using System;
using System.Data;
using System.Linq;

namespace Les5Oefening
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            int keuze = 0;
            int order = 0;
            var db = new NorthwindContext();

            while (repeat)
            {
                Console.WriteLine("1. Overzicht klantbestellingen");
                Console.WriteLine("2. Data analyse");
                Console.WriteLine("3. Stop");
                Console.Write(" > ");

                while (!int.TryParse(Console.ReadLine(), out keuze))
                {
                    Console.WriteLine("Gelieve een geldige menukeuze te maken !");
                    Console.Write("> ");
                }
                switch (keuze)
                {
                    case 1:
                        bool temp = true;
                        Console.WriteLine("\nOrder ID".PadRight(15) + "Klant ID".PadRight(15) + "Klant naam".PadRight(40) + "Werknemer naam");
                        Console.WriteLine("------------------------------------------------------------------------------------");
                        var query =
                            from c in db.Customers
                            join o in db.Orders on c.CustomerId equals o.CustomerId
                            join e in db.Employees on o.EmployeeId equals e.EmployeeId
                            select new
                            {
                                OrderID = o.OrderId,
                                KlantID = c.CustomerId,
                                KlantNaam = c.CompanyName,
                                WerknemerNaam = e.FirstName
                            };
                        foreach (var c in query)
                        {
                            Console.WriteLine($"{c.OrderID}".PadRight(15) + $"{c.KlantID}".PadRight(15) + $"{c.KlantNaam}".PadRight(40) + $"{c.WerknemerNaam}");
                        }
                        Console.Write("\nGeef een geldig order id in om detail info te bekijken: ");
                        while (!int.TryParse(Console.ReadLine(), out order))
                        {
                            Console.WriteLine("Gelieve een geldige waarde in te geven !");
                            Console.Write(" > ");
                        }
                        var query2 =
                           from o in db.OrderDetails
                           join p in db.Products on o.ProductId equals p.ProductId
                           where o.OrderId == order
                           select new
                           {
                               ProductID = o.ProductId,
                               ProductNaam = p.ProductName,
                               Aantal = o.Quantity,
                               Prijs = o.UnitPrice,
                           };
                        if(query2.Count() > 0)
                        {
                            Console.WriteLine("\nProduct ID".PadRight(15) + "Productnaam".PadRight(40) + "Aantal".PadRight(10) + "Eenheidsprijs".PadRight(20) + "Lijnwaarde");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------");
                            foreach (var o in query2)
                            {
                                Console.WriteLine($"{o.ProductID}".PadRight(15) + $"{ o.ProductNaam}".PadRight(40) + $"{o.Aantal}".PadRight(10) + $"{o.Prijs}".PadRight(20) + o.Prijs * o.Aantal);
                            }
                        } else
                        {
                            Console.WriteLine("\nGeen geldige order id ! Gelieve opnieuw te beginnen");
                        }
                        break;
                    case 2:
                        bool check1 = true;
                        bool check2 = true;
                        Console.WriteLine("Land".PadRight(20) + "Totaal verkocht");
                        var query3 = 
                            from c in db.Customers
                            from o in db.Orders
                            from d in db.OrderDetails
                            where c.CustomerId == o.CustomerId
                            where o.OrderId == d.OrderId
                            group d by new
                            {
                                c.Country
                            } into cByCat
                            select new
                            {
                                Land = cByCat.Key.Country,
                                Hoeveelheid = cByCat.Sum(d =>(d.Quantity * d.UnitPrice))
                            }                            ;                            
                        foreach (var c in query3.OrderByDescending(c => c.Hoeveelheid))
                        {
                            Console.WriteLine($"{c.Land }".PadRight(20) + $"{c.Hoeveelheid}");
                        }
                        while (check1)
                        {
                            Console.Write("\nGeef de landnaam in om details te bekijken: ");
                            string land = Console.ReadLine();
                            var query4 =
                               from c in db.Customers
                               join o in db.Orders on c.CustomerId equals o.CustomerId
                               join d in db.OrderDetails on o.OrderId equals d.OrderId
                               where c.Country == land
                               group d by new
                               {
                                   c.CustomerId,
                                   c.CompanyName
                               } into kByCat
                               select new
                               {
                                   KlantID = kByCat.Key.CustomerId,
                                   Klantnaam = kByCat.Key.CompanyName,
                                   Totaal = kByCat.Sum(d => (d.Quantity * d.UnitPrice))
                               };
                            if (query4.Count() > 0)
                            {
                                check1 = false;
                                Console.WriteLine("\nKlant ID".PadRight(15) + "Klantnaam".PadRight(40) + "Totaal");
                                Console.WriteLine("-----------------------------------------------------------------");
                                foreach (var c in query4)
                                {
                                    Console.WriteLine($"{c.KlantID}".PadRight(15) + $"{ c.Klantnaam}".PadRight(40) + $"{ c.Totaal}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nOngeldige landkeuze ! Gelieve opnieuw te beginnen.");
                            }
                        }
                        while (check2)
                        {
                            Console.Write("\nGeef het Klant id in: ");
                            string klantid = Console.ReadLine();
                            var query5 =
                                from o in db.Orders
                                join d in db.OrderDetails on o.OrderId equals d.OrderId
                                where o.CustomerId == klantid
                                group d by new
                                {
                                    o.OrderId,
                                    o.OrderDate,
                                    o.ShippedDate
                                } into dByCat
                                select new
                                {
                                    OrderID = dByCat.Key.OrderId,
                                    OrderDatum = dByCat.Key.OrderDate,
                                    Verzenddatum = dByCat.Key.ShippedDate,
                                    Totaal = dByCat.Sum(d => d.Quantity * d.UnitPrice)
                                };
                            if (query5.Count() > 0)
                            {
                                check2 = false;
                                Console.WriteLine("\nOrder ID".PadRight(15) + "Order datum".PadRight(25) + "Verzendatum".PadRight(25) + "Totaal");
                                Console.WriteLine("--------------------------------------------------------------------------");
                                foreach (var c in query5)
                                {
                                    Console.WriteLine($"{c.OrderID}".PadRight(15) + $"{ c.OrderDatum}".PadRight(25) + $"{ c.Verzenddatum}".PadRight(25) + $"{ c.Totaal}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nOngeldige klant id ! Gelieve opnieuw te beginnen.");
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Programma word afgesloten");
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Gelieve een geldige menukeuze te maken !");
                        break;
                }
                if(keuze != 3)
                {
                    Console.WriteLine("\nDruk op een toets om verder te gaan");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
