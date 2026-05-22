using System.Linq.Expressions;

namespace EvidenceHerAFilmu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Seznam MujSeznam = new Seznam();
            MujSeznam.NacitaniZeSouboru();
            Console.ForegroundColor = ConsoleColor.White;




            while (true) {
                Console.Clear();
                switch (ShowMenu())
                {
                    case 1: // Výpis seznamu filmů nebo her (true = hra, false = film)
                        Console.Clear();
                        MujSeznam.VypisVse(true);
                        Console.WriteLine("\n(Pro pokračování stikněte libovolnou klávesu)");
                        Console.ReadKey();
                        break;
                    case 2: // Zadání nové hry
                        Console.Clear();
                        string nazev;
                        int pocet = 0;

                        // zapsání názvu hry
                        while (true)
                        {
                            Console.WriteLine("Zadejte název hry: ");
                            nazev = Console.ReadLine().Replace(';', ' '); // ochrana proti ; (oddelovač v souboru pro ukládání)
                            if (nazev.Trim().Length > 0)
                            {
                                break;
                            }
                            pocet++;
                            Console.Clear();
                            Console.WriteLine($"{pocet}. Zadal jste neplatný název");
                        }

                        // while pro zapsání roku vydání hry
                        int rok;
                        pocet = 0;
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Zadejte rok vydání: ");
                                rok = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                pocet++;
                                Console.Clear();
                                Console.WriteLine($"{pocet}. Zadal jste neplatný rok vydání");
                            }
                        }

                        // while pro zapsání hodnocení
                        double hodnoceni;
                        pocet = 0;
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Zadejte hodnocení od 0.0 až do 10.0");
                                hodnoceni = double.Parse(Console.ReadLine().Replace('.', ',')); // změna . na , protože v  českém rozhranní se píše desetinná čárka, ale například angličtina má .
                                if (hodnoceni >= 0 && hodnoceni <= 10)
                                {
                                    break;
                                }
                                pocet++; 
                                Console.Clear();
                                Console.WriteLine($"{pocet}. Zadejte platné hodnocení v rámci intervalu");
                            }
                            catch
                            {
                                pocet++;
                                Console.Clear();
                                Console.WriteLine($"{pocet}. Zadejte platné hodnocení v rámci intervalu");
                            }
                        }

                        // while pro zapsání písemné recenze
                        string recenze;
                        pocet = 0;
                        while (true)
                        {
                            Console.WriteLine("Zadejte prosím recenzi (max. 100 znaků)");
                            recenze = Console.ReadLine().Replace(';', ' '); // ochrana proti ; (oddelovač v souboru pro ukládání)
                            if (recenze.Trim().Length > 0 && recenze.Length <= 100) // recenze musí být nějaká ale max. 100 znaků
                            {
                                break;
                            }
                            pocet++;
                            Console.Clear();
                            Console.WriteLine($"{pocet}. Zadal jste neplatnou recenzi (nesmí být prázdná a max 100 znaků)");
                        }

                        // while pro zapsání jestli má hra multiplayer
                        bool maMultiplayer;
                        string slovo;
                        pocet = 0;
                        while (true)
                        {
                            Console.WriteLine("Zadejte zda má hra multiplayer (ano/ne)");
                            slovo = Console.ReadLine().Trim().ToLower(); // ano/ne může mít jakoukoliv podobu např. AnO, NE, nE atd.
                            if (slovo == "ano")
                            {
                                maMultiplayer = true;
                                break;
                            }
                            else if (slovo == "ne")
                            {
                                maMultiplayer = false;
                                break;
                            }
                            pocet++;
                            Console.Clear();
                            Console.WriteLine($"{pocet}. Zadejte prosím pouze \"ano\" nebo \"ne\"");
                        }

                        // zadání studia s kontrolou
                        string studio;
                        pocet = 0;
                        while (true)
                        {
                            Console.WriteLine("Zadejte kdo hru vydal (vydavatelství / studio):");
                            studio = Console.ReadLine().Replace(';', ' '); // ochrana proti ; (oddelovač v souboru pro ukládání)
                            if (studio.Trim().Length > 0)
                            {
                                break;
                            }
                            pocet++;
                            Console.Clear();
                            Console.WriteLine($"{pocet}. Zadal jste neplatný název studia");
                        }

                        Hra nova = new Hra(nazev, rok, hodnoceni, recenze, maMultiplayer, studio);
                        MujSeznam.Pridat(nova, 1); // 1 = hra 0 = film
                        MujSeznam.UlozeniDoSouboru();
                        break;
                    case 3: // Výpis seznamu filmů nebo her (true = hra, false = film)
                        Console.Clear();
                        MujSeznam.VypisVse(false);
                        Console.WriteLine("\n(Pro pokračování stikněte libovolnou klávesu)");
                        Console.ReadKey();
                        break;
                    case 4: // Zadání nového filmu
                        Console.Clear();
                        string nazevf;
                        pocet = 0;
                        // zapsání názvu filmu
                        while (true)
                        {
                            Console.WriteLine("Zadejte název filmu: ");
                            nazevf = Console.ReadLine().Replace(';', ' '); // ochrana proti ; (oddelovač v souboru pro ukládání)
                            if (nazevf.Trim().Length > 0)
                            {
                                break;
                            }
                            pocet++;
                            Console.Clear();
                            Console.WriteLine($"{pocet}. Zadal jste neplatný název");

                        }

                        // while pro zapsání roku vydání hry
                        int rokf;
                        pocet = 0;
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
                                pocet++;
                                Console.Clear();
                                Console.WriteLine($"{pocet}. Zadal jste neplatný rok vydání");
                            }
                        }

                        // while pro zapsání hodnocení
                        double hodnocenif;
                        pocet = 0;
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Zadejte hodnocení od 0.0 až do 10.0");
                                hodnocenif = double.Parse(Console.ReadLine().Replace('.', ',')); // změna . na , protože v  českém rozhranní se píše desetinná čárka, ale například angličtina má .
                                if (hodnocenif >= 0 && hodnocenif <= 10)
                                {
                                    break;
                                }
                                pocet++;
                                Console.Clear();
                                Console.WriteLine($"{pocet}. Zadejte platné hodnocení v rámci intervalu");

                            }
                            catch
                            {
                                pocet++;
                                Console.Clear();
                                Console.WriteLine($"{pocet}. Zadejte platné hodnocení v rámci intervalu");
                            }
                        }

                        //while pro zapsání písemné recenze
                        string recenzef;
                        pocet = 0;
                        while (true)
                        {
                            Console.WriteLine("Zadejte prosím recenzi (max. 100 znaků)");
                            recenzef = Console.ReadLine().Replace(';', ' '); // ochrana proti ; (oddelovač v souboru pro ukládání)
                            if (recenzef.Length <= 100 && recenzef.Trim().Length > 0) // recenze musí být nějaká ale max. 100 znaků
                            {
                                break;
                            }
                            pocet++;
                            Console.Clear();
                            Console.WriteLine($"{pocet}. Zadal jste neplatnou recenzi");
                        }

                        int minuty;
                        pocet = 0;
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
                                pocet++;
                                Console.Clear();
                                Console.WriteLine($"{pocet}. Zadal jste špatné číslo");
                            }
                            

                        }
                        // zadání kdo film režíroval
                        string reziser;
                        pocet = 0;
                        while (true)
                        {
                            Console.WriteLine("Zadejte, kdo režíroval daný film:");
                            reziser = Console.ReadLine().Replace(';', ' '); // ochrana proti ; (oddelovač v souboru pro ukládání)

                            if (reziser.Trim().Length > 0)
                            {
                                break;
                            }

                            pocet++;
                            Console.Clear();
                            Console.WriteLine($"{pocet}. Zadal jste neplatné jméno režiséra");
                        }
                        Film novyf = new Film(nazevf, rokf, hodnocenif, recenzef, minuty, reziser);
                        MujSeznam.Pridat(novyf, 0); // 1 = hra 0 = film
                        MujSeznam.UlozeniDoSouboru();
                        break;
                    case 5: // Smazaní filmů i her, které mají zadaný název
                        Console.Clear();
                        Console.WriteLine("Zadejte název filmu nebo hry které chcete odebrat (dojde k odebrání všeho se schodným názvem)");
                        string odstranit = Console.ReadLine();
                        int pocetsmazani = MujSeznam.Odebrat(odstranit);
                        Console.WriteLine($"Odstranění proběhlo úspěšně\nPočet smazaných položek: {pocetsmazani}\n(Pro pokračování stiskněte libovolnou klávesu)");
                        Console.ReadKey();
                        break;
                    case 0: // uložení a následné ukončení programu
                        MujSeznam.UlozeniDoSouboru();
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
                Console.ForegroundColor = ConsoleColor.White; // reset barvy na systémovou výchozí
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
