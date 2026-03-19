using System.Linq.Expressions;

namespace EvidenceHerAFilmu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Seznam MujSeznam = new Seznam();

            while (true) {
                Console.Clear();
                switch (ShowMenu())
                {
                    case 1:
                        Console.Clear();
                        MujSeznam.VypisVse(true);
                        Console.WriteLine("\n(Pro pokračování stikněte libovolnou klávesu)");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        string nazev;
                        // zapsání názvu hry
                        while (true)
                        {
                            Console.WriteLine("Zadejte název hry: ");
                            nazev = Console.ReadLine();
                            if (nazev.Trim().Length > 0)
                            {
                                break;
                            }

                        }

                        // while pro zapsání roku vydání hry
                        int rok;
                        while(true)
                        {
                            try
                            {
                                Console.WriteLine("Zadejte rok vydání: ");
                                rok = int.Parse(Console.ReadLine());
                                break;

                            }
                            catch
                            {
                                Console.WriteLine("Zadal jste neplatný rok vydání");
                            }
                        }

                        // while pro zapsání hodnocení
                        double hodnoceni;
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Zadejte hodnocení od 0.0 až do 10.0 (při zadávání desetinných míst pište čárku)");
                                hodnoceni = double.Parse(Console.ReadLine());
                                if(hodnoceni >= 0 && hodnoceni <= 10)
                                {
                                    break;
                                }

                            }
                            catch
                            {
                                Console.WriteLine("Zadejte platné hodnocení v rámci intervalu");
                            }
                        }

                        //while pro zapsání písemné recenze
                        string recenze;
                        while (true)
                        {
                            Console.WriteLine("Zadejte prosím recenzi (max. 100 znaků)");
                            recenze = Console.ReadLine();
                            if(recenze.Length <= 100)
                            {
                                break;
                            }
                        }
                        bool maMultiplayer;
                        string slovo;
                        // while pro zapsání jestli má hra multiplayer
                        while (true)
                        {
                                Console.WriteLine("Zadejte zda má hra multiplayer (ano/ne)");
                                slovo = Console.ReadLine();
                                if (slovo.Trim().ToLower() == "ano")
                                {
                                    maMultiplayer = true;
                                    break;
                                }
                                else if (slovo.Trim().ToLower() == "ne")
                                {
                                    maMultiplayer= false;
                                    break;
                                }

                        }
                        // zadání kdo hru vydal, vydavatelství studio
                        Console.WriteLine("Zadejte kdo hru vydal (vydavatelství / studio)");
                        string studio = Console.ReadLine();
                        Hra nova = new Hra(nazev, rok,hodnoceni,recenze,maMultiplayer,studio);
                        MujSeznam.Pridat(nova, 1);
                        break;
                    case 3:
                        Console.Clear();
                        MujSeznam.VypisVse(false);
                        Console.WriteLine("\n(Pro pokračování stikněte libovolnou klávesu)");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        string nazevf;
                        // zapsání názvu filmu
                        while (true)
                        {
                            Console.WriteLine("Zadejte název filmu: ");
                            nazevf = Console.ReadLine();
                            if(nazevf.Trim().Length > 0)
                            {
                                break;
                            }

                        }

                        // while pro zapsání roku vydání hry
                        int rokf;
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Zadejte rok vydání: ");
                                rokf = int.Parse(Console.ReadLine());
                                break;

                            }
                            catch
                            {
                                Console.WriteLine("Zadal jste neplatný rok vydání");
                            }
                        }

                        // while pro zapsání hodnocení
                        double hodnocenif;
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Zadejte hodnocení od 0.0 až do 10.0 (při zadávání desetinných míst pište čárku)");
                                hodnocenif = double.Parse(Console.ReadLine());
                                if (hodnocenif >= 0 && hodnocenif <= 10)
                                {
                                    break;
                                }

                            }
                            catch
                            {
                                Console.WriteLine("Zadejte platné hodnocení v rámci intervalu");
                            }
                        }

                        //while pro zapsání písemné recenze
                        string recenzef;
                        while (true)
                        {
                            Console.WriteLine("Zadejte prosím recenzi (max. 100 znaků)");
                            recenzef = Console.ReadLine();
                            if (recenzef.Length <= 100)
                            {
                                break;
                            }
                        }

                        int minuty;
                        // while který slouží pro zapsání délky filmu v minutách
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Zadejte jak dlouhý byl daný film v minutách");
                                minuty = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Zadal jste špatné číslo");
                            }
                            

                        }
                        // zadání kdo hru vydal, vydavatelství studio
                        Console.WriteLine("Zadejte kdo režíroval daný film");
                        string reziser = Console.ReadLine();
                        Film novyf = new Film(nazevf, rokf, hodnocenif, recenzef,minuty , reziser);
                        MujSeznam.Pridat(novyf, 0);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Zadejte název filmu nebo hry které chcete odebrat (dojde k odebrání všeho se schodným názvem)");
                        string odstranit = Console.ReadLine();
                        MujSeznam.Odebrat(odstranit);
                        Console.WriteLine("Odstranění proběhlo úspěšně\n(Pro pokračování stiskněte libovolnou klávesu)");
                        Console.ReadKey();
                        break;
                    case 0:
                        return;
                        
                }
            }
        }
        static int ShowMenu() // Funkce pro zobrazení Mmenu
        {
            // vytvoření proměnné, do které uložím výběr uživatele
            int vyber = -1;
            while (true)
            {
                Console.ResetColor(); // reset barvy na systémovou výchozí
                // Vypsání na obrazovku
                Console.WriteLine("Hry");
                Console.WriteLine("1.Zobrazit seznam");

                // změna barvy následujícího vypsání na obrazovku
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("2.Přidat");

                Console.ForegroundColor = ConsoleColor.White;

                // Vypsání na obrazovku
                Console.WriteLine("\nFilmy");
                Console.WriteLine("3.Zobrazit seznam");

                // změna barvy následujícího vypsání na obrazovku
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("4.Přidat");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n5.Odebrat");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("0.Ukončení\n\n");

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
                if (vyber < 6 && vyber > -1)
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
