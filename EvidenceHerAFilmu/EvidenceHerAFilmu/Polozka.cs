using System;
using System.Collections.Generic;
using System.Text;

namespace EvidenceHerAFilmu
{
    internal class Polozka // tato třída bude rodičem třídy hry a filmy
    {
        // vytvoření jednotlivých atributů dané třídy
        public string Nazev { get; private set; } // public get = hodnota se dá získat všude v namespacu, private set = hodnota se dá změnit pouze uvnitř třídy, díky to mu získáváme kontrolu nad změnou hodnot
        public int RokVydani { get; private set; }
        public float Hodnoceni { get; private set; }
        public string Zanr { get; private set; }

        public Polozka(string nazev, int rokVydani, float hodnoceni, string zanr) // konstruktor, stejnojmená funkce, která se automaticky vyvolává při zakládání instance objektu, dojde ke vložení hodnot do objektu
        {
            Nazev = nazev;
            RokVydani = rokVydani;
            Hodnoceni = (float)Math.Round(hodnoceni, 1); // zaokrohlení Hodnocení na jednodesetinné místo
            Zanr = zanr;
        }

        // Klíčové slovo virtual dovolí dětem metodu přepsat
        public virtual void VypisInfo()
        {
            Console.WriteLine($"{Nazev} ({RokVydani}) - Hodnocení: {Hodnoceni}/10, Žánr: {Zanr}");
        }
    }
}
