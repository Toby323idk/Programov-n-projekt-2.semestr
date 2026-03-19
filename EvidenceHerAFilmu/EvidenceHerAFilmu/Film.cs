using System;
using System.Collections.Generic;
using System.Text;

namespace EvidenceHerAFilmu
{
    internal class Film : Polozka
    {
        public string Reziser { get; private set; }
        public int DelkaVMinutach { get; private set; }

        public Film(string nazev, int rokVydani, double hodnoceni, string recenze, int delkaVMinutach, string reziser) : base(nazev,rokVydani, hodnoceni, recenze) // base() slouží k vyvolání konstruktoru předka který zpracuje hodnoty, které se dědí.
        {
            DelkaVMinutach = delkaVMinutach;
            Reziser = reziser;
        }
        public override void VypisInfo()
        {
            Console.WriteLine($"{Nazev} ({RokVydani}) - Hodnocení: {Hodnoceni}/10, Délka - {DelkaVMinutach}, Režisér - {Reziser}, Recenze - {Recenze} ");
        }
    }
}
