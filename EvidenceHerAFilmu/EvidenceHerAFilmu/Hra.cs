using System;
using System.Collections.Generic;
using System.Text;

namespace EvidenceHerAFilmu
{
    internal class Hra : Polozka
    {
        public bool JeMultiplayer { get; private set; }
        public string Vydavatel { get; private set; }

        public Hra(string nazev, int rokVydani, double hodnoceni, string recenze, bool jeMultiplayer, string vydavatel) : base(nazev, rokVydani, hodnoceni, recenze) // base() slouží k vyvolání konstruktoru předka který zpracuje hodnoty, které se dědí.
        {
            Vydavatel = vydavatel;
            JeMultiplayer = jeMultiplayer;
        }
        public override void VypisInfo()
        {
            Console.WriteLine($"{Nazev} ({RokVydani}) - Hodnocení: {Hodnoceni}/10, Má multiplayer? - {JeMultiplayer}, Vydavatel - {Vydavatel}, Recenze - {Recenze} ");
        }
    }
}
