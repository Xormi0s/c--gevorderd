using System;
using System.Collections.Generic;

namespace Les3Oefening
{
    class Program
    {
        static void Main(string[] args)
        {
            string menukeuze = string.Empty;
            List<IColorObject> colorObjects = new List<IColorObject>();
            do
            {
                Console.Clear();
                Console.WriteLine(" *** Beheer kleurobjecten ***");
                Console.WriteLine("1. Voeg vorm toe");
                Console.WriteLine("2. Voeg foto toe");
                Console.WriteLine("3. Geef overzicht");
                Console.WriteLine("4. Stop");
                menukeuze = Console.ReadLine();

                switch (menukeuze)
                {
                    case "1":
                        string vormkeuze = string.Empty;
                        do
                        {
                            Console.WriteLine("1. Vierkant");
                            Console.WriteLine("2. Cirkel");
                            vormkeuze = Console.ReadLine();
                            switch (vormkeuze)
                            {
                                case "1":
                                    double side;
                                    do
                                    {
                                        Console.Write("Lengte zijde: ");
                                    } while (!double.TryParse(Console.ReadLine(), out side));
                                    Square square = new Square { SideLength = side };
                                    Console.Write("Naam vorm: ");
                                    square.Name = Console.ReadLine();
                                    SetColorObject(square);
                                    colorObjects.Add(square);
                                    break;
                                case "2":
                                    double radius;
                                    do
                                    {
                                        Console.Write("Straal: ");
                                    } while (!double.TryParse(Console.ReadLine(), out radius));
                                    Circle circle = new Circle { Radius = radius };
                                    Console.Write("Naam vorm: ");
                                    circle.Name = Console.ReadLine();
                                    SetColorObject(circle);
                                    colorObjects.Add(circle);
                                    break;
                                default:
                                    Console.WriteLine("Ongeldige vormkeuze");
                                    break;
                            }
                        } while (vormkeuze != "1" && vormkeuze != "2");

                        break;
                    case "2":
                        Picture picture = new Picture();
                        Console.Write("Foto locatie: ");
                        picture.Location = Console.ReadLine();
                        SetColorObject(picture);
                        colorObjects.Add(picture);
                        break;
                    case "3":
                        Console.WriteLine(Environment.NewLine + "Overzicht kleurobjecten: ");
                        foreach (var colorObject in colorObjects)
                        {
                            Console.WriteLine(colorObject.ToString());
                        }
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Ongeldige menukeuze");
                        break;
                }
                if (menukeuze != "4")
                {
                    Console.WriteLine("Druk op een toets om verder te gaan");
                    Console.ReadKey();
                }

            } while (menukeuze != "4");
        }


        private static void SetColorObject(IColorObject colorObject)
        {
            string colorType = string.Empty;

            do
            {
                Console.WriteLine("Kleurtype: ");
                Console.WriteLine(" 1. Zwart-wit");
                Console.WriteLine(" 2. Kleur");
                colorType = Console.ReadLine();
                switch (colorType)
                {
                    case "1":
                        colorObject.ColorType = ColorTypes.BlackAndWhite;
                        break;
                    case "2":
                        colorObject.ColorType = ColorTypes.Color;
                        break;
                    default:
                        Console.WriteLine("Ongeldig kleurtype keuze");
                        break;
                }
            } while (colorType != "1" && colorType != "2");

            int colorDepth;

            do
            {
                Console.Write("Kleur diepte: ");
            } while (!int.TryParse(Console.ReadLine(), out colorDepth));
            colorObject.ColorDepth = colorDepth;

        }
    }
}
