using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace EvidenceHerAFilmu
{
    internal class Seznam
    {
        public List<Film> SeznamFilmu { get; private set; } = new List<Film>();
        public List<Hra> SeznamHer { get; private set; } = new List<Hra>();
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
        public void Odebrat(string Nazev)
        {
            Nazev = Nazev.ToLower().Trim();
            SeznamFilmu.RemoveAll(f => f.Nazev.Trim().ToLower() == Nazev);
            SeznamHer.RemoveAll(h => h.Nazev.Trim().ToLower() == Nazev);
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
                    string Recenze = f.Recenze.Replace(';', ' '); // kdyby uživatel napsal do recenze středník rozbil by načítání
                    sw.WriteLine($"Film;{f.Nazev};{f.RokVydani};{f.Hodnoceni};{Recenze};{f.DelkaVMinutach};{f.Reziser}");
                }
                foreach(Hra h  in SeznamHer)
                {
                    string Recenze = h.Recenze.Replace(';', ' ');
                    sw.WriteLine($"Hra;{h.Nazev};{h.RokVydani};{h.Hodnoceni};{Recenze};{h.JeMultiplayer};{h.Vydavatel}");
                }
            } 
        }
    }
}

