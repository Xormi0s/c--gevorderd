using System;
using System.Collections.Generic;

namespace Les2Oef1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            int input;

            List<IPrintMessage> berichten = new List<IPrintMessage>();

            while (repeat)
            {
                Console.WriteLine(" *** Bericht center ***");
                Console.WriteLine("1. Plak een post-it");
                Console.WriteLine("2. Post een tweet");
                Console.WriteLine("3. Bericht detail");
                Console.WriteLine("4. stop");

                Console.Write("> ");
                while(!int.TryParse(Console.ReadLine(),out input))
                {
                    Console.WriteLine("Gelieve een correcte keuzemenu te kiezen !");
                    Console.Write("> ");
                }

                switch (input)
                {
                    case 1:
                        Postit temppost = new Postit();
                        Console.Write("Van: ");
                        temppost.Naam = Console.ReadLine();
                        Console.Write("Locatie: ");
                        temppost.Locatie = Console.ReadLine();
                        Console.Write("Boodschap: ");
                        temppost.Message = Console.ReadLine();
                        berichten.Add(temppost);
                        break;
                    case 2:
                        Tweet temptweet = new Tweet();
                        Console.Write("Account: ");
                        temptweet.Account = Console.ReadLine();
                        Console.Write("Hashtag: ");
                        temptweet.Hashtag = Console.ReadLine();
                        Console.Write("Bericht: ");
                        temptweet.Message = Console.ReadLine();
                        berichten.Add(temptweet);
                        break;
                    case 3:
                        int tempcijfer = 0;
                        int tempkeuze = 0;

                        Console.WriteLine("Overzicht berichten:");
                        if(berichten.Count >= 1)
                        {
                            foreach (IPrintMessage print in berichten)
                            {
                                tempcijfer++;
                                Console.WriteLine(tempcijfer + ". " + print.ToString());
                            }

                            Console.WriteLine("Nummer bericht: ");
                            Console.Write("> ");
                            while (!int.TryParse(Console.ReadLine(), out tempkeuze))
                            {
                                Console.WriteLine("Gelieve een correcte keuzemenu te kiezen !");
                                Console.Write("> ");
                            }
                            
                            while(tempkeuze > tempcijfer || tempkeuze < 1)
                            {
                                Console.WriteLine("Gelieve een juiste keuze te maken in de lijst !");
                                Console.Write("> ");
                                while (!int.TryParse(Console.ReadLine(), out tempkeuze))
                                {
                                    Console.WriteLine("Gelieve een correcte keuzemenu te kiezen !");
                                    Console.Write("> ");
                                }
                            }

                            berichten[tempkeuze-1].GetMessageInfo();
                        }
                        else
                        {
                            Console.WriteLine("Er zijn nog berichten opgeslagen !");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Programma word afgesloten");
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Gelieve een correcte keuzemenu te kiezen !");
                        break;
                }

                Console.WriteLine("Druk op een toets om verder te gaan");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
