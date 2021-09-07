using System;
using System.Collections.Generic;

namespace Les7Oef1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            int input;
            List<Wagen> wagenpark = new List<Wagen>();

            while (repeat)
            {
                Console.WriteLine(" ** VAA berekening **");
                Console.WriteLine("1. Geef een wagen in");
                Console.WriteLine("2. Overzicht wagens");
                Console.WriteLine("3. Totaal VAA");
                Console.WriteLine("4. Stop programma");

                Console.Write("> ");
                while(!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Gelieve een correcte menukeuze in te geven !");
                    Console.Write("> ");
                }

                switch (input)
                {
                    case 1:
                        int keuze;
                        decimal prijstemp;
                        int noxtemp;
                        int co2temp;
                        bool nrplaat = true;

                        Console.WriteLine("\tType");
                        Console.WriteLine("\t1. Diesel");
                        Console.WriteLine("\t2. Benzine");
                        Console.Write("\t> ");

                        while(!int.TryParse(Console.ReadLine(), out keuze))
                        {
                            Console.WriteLine("\tOngeldige keuze. Gelieve een correcte in te geven !");
                            Console.Write("\t> ");
                        }

                        while(keuze != 1 && keuze != 2)
                        {
                            Console.WriteLine("\tGelieve een geldige keuzen tussen 1 en 2 te maken !");
                            Console.Write("\t>");
                            while (!int.TryParse(Console.ReadLine(), out keuze))
                            {
                                Console.WriteLine("\tGelieve een geldige keuzen tussen 1 en 2 te maken !");
                                Console.Write("\t> ");
                            }
                        }

                        if(keuze == 1)
                        {
                            Dieselwagen tempwagen = new Dieselwagen();
                            Console.Write("\tNummerplaat: ");
                            string tempnr = Console.ReadLine();
                            foreach(Wagen wagen in wagenpark)
                            {
                                if(tempnr == wagen.Nummerplaat)
                                {
                                    Console.WriteLine("\tDeze nummerplaat is al reeds ingegeven !");
                                    nrplaat = false;
                                }
                            }
                            if (nrplaat) {
                                tempwagen.Nummerplaat = tempnr;
                                Console.Write("\tCatalogusprijs: ");
                                while (!decimal.TryParse(Console.ReadLine(), out prijstemp))
                                {
                                    Console.WriteLine("\tGelieve een correcte waarde in te geven !");
                                    Console.Write("\t> ");
                                }
                                tempwagen.Prijs = prijstemp;
                                Console.Write("\tNOx: ");
                                while (!int.TryParse(Console.ReadLine(), out noxtemp))
                                {
                                    Console.WriteLine("\tGelieve een correcte waarde in te geven !");
                                    Console.Write("\t> ");
                                }
                                tempwagen.Nox = noxtemp;
                                wagenpark.Add(tempwagen);
                            }
                            
                        } else if( keuze == 2)
                        {
                            Benzinewagen tempwagen = new Benzinewagen();
                            Console.Write("\tNummerplaat: ");
                            string tempnr = Console.ReadLine();
                            foreach (Wagen wagen in wagenpark)
                            {
                                if (tempnr == wagen.Nummerplaat)
                                {
                                    Console.WriteLine("\tDeze nummerplaat is al reeds ingegeven !");
                                    nrplaat = false;
                                }
                            }
                            if (nrplaat)
                            {
                                tempwagen.Nummerplaat = tempnr;
                                Console.Write("\tCatalogusprijs: ");
                                while (!decimal.TryParse(Console.ReadLine(), out prijstemp))
                                {
                                    Console.WriteLine("\tGelieve een correcte waarde in te geven !");
                                    Console.Write("\t> ");
                                }
                                tempwagen.Prijs = prijstemp;
                                Console.Write("\tCO2: ");
                                while (!int.TryParse(Console.ReadLine(), out co2temp))
                                {
                                    Console.WriteLine("\tGelieve een correcte waarde in te geven !");
                                    Console.Write("\t> ");
                                }
                                tempwagen.Co2 = co2temp;
                                wagenpark.Add(tempwagen);
                            }
                        } 
                        break;
                    case 2:
                        if (wagenpark.Count >=1)
                        {
                            foreach (Wagen wagen in wagenpark)
                            {
                                Console.WriteLine(wagen);
                            }
                        } else
                        {
                            Console.WriteLine("Er zijn nog geen auto's toegevoegd.");
                        }
                        break;
                    case 3:
                        decimal totaal = 0;
                        if (wagenpark.Count >= 1)
                        {
                            foreach (Wagen wagen in wagenpark)
                            {
                                totaal += wagen.VAA();
                            }
                            Console.WriteLine("Het totaal te betalen VAA: " + totaal);
                        } else
                        {
                            Console.WriteLine("Er zijn nog geen auto's toegevoegd.");
                        }
                        break;
                    case 4:
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Ongeldige menukeuze.");
                        break;
                }

                if(input == 4)
                {
                    Console.WriteLine("Programma word beëindigd.");
                } else
                {
                    Console.WriteLine("Druk op een toets om verder te gaan.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
