using System;
using System.Collections.Generic;
using System.Text;

namespace EvidenceHerAFilmu
{
    internal abstract class Polozka // tato třída bude rodičem třídy hry a filmy
    {
        // vytvoření jednotlivých atributů dané třídy
        public string Nazev { get; private set; } // public get = hodnota se dá získat všude v namespacu, private set = hodnota se dá změnit pouze uvnitř třídy, díky to mu získáváme kontrolu nad změnou hodnot
        public int RokVydani { get; private set; }
        public double Hodnoceni { get; private set; }
        public string Recenze { get; private set; }

        public Polozka(string nazev, int rokVydani, double hodnoceni, string recenze) // konstruktor, stejnojmená funkce, která se automaticky vyvolává při zakládání instance objektu, dojde ke vložení hodnot do objektu
        {
            Nazev = nazev;
            RokVydani = rokVydani;
            Hodnoceni = (double)Math.Round(hodnoceni, 1); // zaokrohlení Hodnocení na jednodesetinné místo
            Recenze = recenze;
        }

        // Klíčové slovo virtual dovolí dětem metodu přepsat
        public abstract void VypisInfo();
    }
}
