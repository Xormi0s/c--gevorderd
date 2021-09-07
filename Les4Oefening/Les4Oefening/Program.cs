using System;

namespace Les4Oefening
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            bool actief = false;
            int keuze = 0;
            Provider provider = new Provider();

            while (repeat)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(" Provider beheer");
                    if (actief == false)
                    {
                        Console.WriteLine("1. Maak provider aan");
                    }
                    else
                    {
                        Console.WriteLine("1. Pas provider aan");
                    }
                    Console.WriteLine("2. Voeg smartphone toe");
                    Console.WriteLine("3. Geef overzicht provider");
                    Console.WriteLine("4. Stop");
                    Console.Write("> ");

                    while (!int.TryParse(Console.ReadLine(), out keuze))
                    {
                        Console.WriteLine("Gelieve een geldige menukeuze te maken !");
                        Console.Write("> ");
                    }

                    switch (keuze)
                    {
                        case 1:
                            if (actief == false)
                            {
                                string naam;
                                int snelheid;
                                Console.Write("Geef de naam van de provider: ");
                                naam = Console.ReadLine();
                                Console.Write("Provider connectie snelheid: ");
                                while (!int.TryParse(Console.ReadLine(), out snelheid))
                                {
                                    Console.WriteLine("Gelieve een geldige snelheid in te geven !");
                                    Console.Write("> ");
                                }
                                provider = new Provider(naam, snelheid);
                                Console.WriteLine("Een nieuwe provider werd aangemaakt");
                            }
                            else
                            {
                                int status;
                                Console.WriteLine("Status provider");
                                Console.WriteLine("1. Online");
                                Console.WriteLine("2. Offline");
                                Console.WriteLine("3. Restricted");
                                Console.Write("> ");

                                while (!int.TryParse(Console.ReadLine(), out status))
                                {
                                    Console.WriteLine("Gelieve een geldige keuze in te geven !");
                                    Console.Write("> ");
                                }
                                if (status == 1)
                                {
                                    provider.Status = ProviderStatus.Online;
                                }
                                else if (status == 2)
                                {
                                    provider.Status = ProviderStatus.Offline;
                                }
                                else if (status == 3)
                                {
                                    provider.Status = ProviderStatus.Restricted;
                                }
                                else
                                {
                                    Console.WriteLine("Ongeldige keuze !");
                                }
                            }
                            actief = true;
                            break;
                        case 2:
                            string model;
                            int connectiesnelheid;

                            Console.Write("Model: ");
                            model = Console.ReadLine();
                            Console.Write("Connectiesnelheid: ");
                            while (!int.TryParse(Console.ReadLine(), out connectiesnelheid))
                            {
                                Console.WriteLine("Gelieve een geldige snelheid in te geven !");
                                Console.Write("> ");
                            }
                            Smartphone temp = new Smartphone(model, connectiesnelheid);
                            provider.VoegSmartphoneToe(ref temp);
                            break;
                        case 3:
                            if(provider.Naam != "")
                            {
                                Console.WriteLine(provider.Naam);
                                Console.WriteLine("\t\t- Connectiesnelheid: " + provider.ConnectieSnelheid);
                                Console.WriteLine("\t\t- Status: " + provider.Status);
                                Console.WriteLine("\t\t- Overzicht smartphones:");
                                if(provider.Smartphones.Count > 0)
                                {
                                    foreach (Smartphone smartphone in provider.Smartphones)
                                    {
                                        Console.WriteLine("\t\t\t\t" + smartphone.ToString());
                                    }
                                } else
                                {
                                    Console.WriteLine("Er zijn nog geen smartphones toegevoegd");
                                }
                                Console.WriteLine("");
                            } else
                            {
                                Console.WriteLine("Nog geen provider in het systeem toegekend");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Programma word afgesloten");
                            repeat = false;
                            break;
                        default:
                            break;
                    }
                } 
                catch (Exception e)
                {
                    Console.WriteLine("Fout tijdens smartphone initialistatie: " + e.Message);
                    Console.WriteLine("De smartphone werd niet toegevoegd");
                }
                finally
                {
                    if (keuze != 4)
                    {
                        Console.WriteLine("Druk op een toets om verder te gaan");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
