using System.Linq.Expressions;

namespace EvidenceHerAFilmu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cislo = ShowMenu();
            Console.Clear();
            Console.WriteLine(cislo);
        }
        static int ShowMenu() // Funkce pro zobrazení Mmenu
        {
            // vytvoření proměnné, do které uložím výběr uživatele
            int vyber = 0;
            while (true)
            {
                while (true)
                {
                    // smazání konzole
                    Console.Clear();

                    // Vypsání na obrazovku
                    Console.WriteLine("Hry");
                    Console.WriteLine("1.Zobrazit seznam");

                    // změna barvy následujícího vypsání na obrazovku
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("2.Přidat");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("3.Odebrat\n\n");

                    Console.ForegroundColor = ConsoleColor.White;

                    // Vypsání na obrazovku
                    Console.WriteLine("Filmy");
                    Console.WriteLine("4.Zobrazit seznam");

                    // změna barvy následujícího vypsání na obrazovku
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("5.Přidat");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("6.Odebrat");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\n0.Ukončení\n\n");

                    /*
                        kód v bloku try se provede a pokud proběhne bez problému nic se nestane, pokud dojde k chybě provede se block catch
                    */
                    try
                    {
                        /*
                            Uložení textu z konzole do proměnné
                            vrácená hodnota z Console.ReadLin() = string, int.Parse to převede na string
                        */
                        vyber = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Vyberte prosím číslo z menu");
                    }

                }
                if(vyber < 7 && vyber > -1)
                {
                    return vyber;
                }
            }
        }
    }
}
