using System;
using System.Collections.Generic;
using System.Text;

namespace EvidenceHerAFilmu
{
    internal class Seznam
    {
        public List<Film> SeznamFilmu { get; private set; } = new List<Film>(); // List pro filmy
        public List<Hra> SeznamHer { get; private set; } = new List<Hra>(); // List pro hry
        public void Pridat(Polozka p, int t) // 1 = hra 0 = film
        {
            if (t == 0)
            {
                SeznamFilmu.Add((Film)p);
            }
            if (t == 1)
            {
                SeznamHer.Add((Hra)p);
            }
        }
        public int Odebrat(string Nazev) // funkce pro odebirání filmů i her podle názvu 
        {
            Nazev = Nazev.ToLower().Trim();
            int pocetf = 0;
            int poceth = 0;
            pocetf = SeznamFilmu.RemoveAll(f => f.Nazev.Trim().ToLower() == Nazev); // RemoveAll. => vrací počet smazaných položek (int), funguje jako foreach().
            poceth = SeznamHer.RemoveAll(h => h.Nazev.Trim().ToLower() == Nazev);
            return pocetf + poceth;
        }
        public void VypisVse(bool Typ) // true - hra false - film
        {
            if (Typ)
            {
                foreach (Hra h in SeznamHer)
                {
                    h.VypisInfo();
                    Console.WriteLine("\n");
                }
            }
            else
            {
                foreach (Film f in SeznamFilmu)
                {
                    f.VypisInfo();
                    Console.WriteLine("\n");
                }
            }
        }
        public void UlozeniDoSouboru()
        {
            // using slouží ke správnému zavření souboru aby nezůstal otevřený po skončení s prácí
            using (StreamWriter sw = new StreamWriter("uloziste.txt", false)) // druhý parametr je Append - slouží k tomu jestli připisovat na konec souboru nebo vytvářet nový pokaždé
            {
                foreach(Film f in SeznamFilmu)
                {
                    sw.WriteLine($"Film;{f.Nazev};{f.RokVydani};{f.Hodnoceni};{f.Recenze};{f.DelkaVMinutach};{f.Reziser}");
                }
                foreach(Hra h  in SeznamHer)
                {
                    sw.WriteLine($"Hra;{h.Nazev};{h.RokVydani};{h.Hodnoceni};{h.Recenze};{h.JeMultiplayer};{h.Vydavatel}");
                }
            } 
        }
        public void NacitaniZeSouboru()
        {
            string cesta = "uloziste.txt";
            if (System.IO.File.Exists(cesta)) // kontrola zda ten soubor existuje
            {
                using (StreamReader sr = new StreamReader(cesta))
                {
                    string radek;
                    string[] data;
                    while ((radek = sr.ReadLine()) != null) // radek obsahujec elý jeden řádek jako string
                    {
                        data = radek.Split(";"); // zde dojde k rozložení jednoho stringu do pole stringů s názvem data, podle rozdělovače ;, následně už známe pořadí, jak jdou data za sebou
                        if (data[0] == "Film")
                        {
                            SeznamFilmu.Add(new Film(data[1], int.Parse(data[2]), double.Parse(data[3]), data[4], int.Parse(data[5]), data[6]));
                        }
                        else if(data[0] == "Hra")
                        {
                            SeznamHer.Add(new Hra(data[1], int.Parse(data[2]), double.Parse(data[3]), data[4], bool.Parse(data[5]), data[6]));
                        }
                    }

                }
            }
        }
    }
}

