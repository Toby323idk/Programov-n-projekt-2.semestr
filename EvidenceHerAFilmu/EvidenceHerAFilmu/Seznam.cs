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
    }
}

