using System;
using System.ComponentModel;

namespace Tehtava4
{
    [Serializable]
    public class Pelaaja
    {

        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string Seura { get; set; }
        public decimal Siirtohinta { get; set; }
        
        public string KokoNimi
        {
            get
            {
                return this.Etunimi + " " + this.Sukunimi;
            }
        }
        
        public string EsitysNimi
        {
            get
            {
                return this.KokoNimi + ", " + this.Seura;
            }
        }
        

        public override string ToString()
        {
            return this.EsitysNimi;
        }

        // for xmlSerialize
        public Pelaaja() { }
        
        public Pelaaja(string etunimi, string sukunimi, string seura, decimal siirtohinta)
        {
            if (etunimi == "")
                throw new Exception("Etunimi puuttuu");
            if (sukunimi == "")
                throw new Exception("Sukunimi puuttuu");
            if (seura == "")
                throw new Exception("Seura puuttuu");
            if (siirtohinta == 0)
                throw new Exception("Siirtohinta ei voi olla nolla");

            this.Etunimi = etunimi;
            this.Sukunimi = sukunimi;
            this.Seura = seura;
            this.Siirtohinta = siirtohinta;
        }
    }
}
