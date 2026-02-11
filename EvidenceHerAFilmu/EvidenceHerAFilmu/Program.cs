using System.Linq.Expressions;

namespace EvidenceHerAFilmu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            switch (ShowMenu())
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
        }
        static int ShowMenu() // Funkce pro zobrazení Mmenu
        {
            // vytvoření proměnné, do které uložím výběr uživatele
            int vyber = -1;
            while (true)
            {
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
                        vrácená hodnota z Console.ReadLin() = string, int.Parse to převede na int (celé číslo)
                    */
                    vyber = int.Parse(Console.ReadLine());
                }
                catch // tento blok se provede pouze pokud uživatel nezadá číslo
                {
                    vyber = -1; // proměnná výběru uživatele se nastaví na neplatnou hodnotu
                }
                // kontrola zda je hodnoa výběru zadaná v intervalu <0;6>
                if (vyber < 7 && vyber > -1)
                {
                    return vyber;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nVyberte prosím číslo mezi 0-6\n");
                }
            }
        }
    }
}
