using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava4
{

    // pelaajat wrapperi
    class Pelaajat
    {

        public List<Pelaaja> pelaajat;
        
        public Pelaajat()
        {
            this.pelaajat = new List<Pelaaja>();
        }

        
        public void insertPlayer(string firstname, string lastname, string club, decimal price)
        {
            // luodaan uusi pelaaja
            Pelaaja newPlayer = new Pelaaja(firstname, lastname, club, price);

            // Tarkistetaan ettei samannimistä vielä ole
            if (this.pelaajat.Exists(x => x.KokoNimi == newPlayer.KokoNimi))
                throw new Exception("Pelaaja on jo listalla!");

            // lisätään ja päivitetään lista
            this.pelaajat.Add(newPlayer);
        }



        public Pelaaja selectPlayer(string playerName)
        {
            // tarkistetaan ettei valinta ole tyhjä
            // vähän huono paikka tälle..
            if (playerName == null)
                throw new Exception("Pelaajaa ei ole valittu!");
            
            return this.pelaajat.Find(x => x.EsitysNimi == playerName);
        }



        public void deletePlayer(string playerName)
        {
            // tarkistetaan ettei valinta ole tyhjä
            if (playerName == null)
                throw new Exception("Pelaajaa ei ole valittu!");

            // haetaan pelaajan indeksi ja poistetaan se
            int playerIndex = this.pelaajat.FindIndex(x => x.EsitysNimi == playerName);
            this.pelaajat.RemoveAt(playerIndex);
        }
        
    }
}
