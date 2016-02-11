using System;
using System.Collections.Generic;
using System.IO;

namespace Tehtava4
{
    class FileHandler
    {

        // Pelaajien tallennus tiedostoon
        public void Save(string filepath, List<Pelaaja> players)
        {
            // Haetaan tiedostopääte
            string ext = Path.GetExtension(filepath);
            
            // tarkastetaan tiedostopäätteen perusteella
            // missä muodossa se halutaan tallentaa
            switch (ext)
            {
                case ".xml":
                    this.SaveXML(filepath, players);
                    break;

                case ".bin":
                    this.SaveBIN(filepath, players);
                    break;

                default:
                    throw new Exception("Extension \"" + ext + "\" is not supported");
            }
        }



        // Tallennus XML
        private void SaveXML(string filepath, List<Pelaaja> players)
        {
            throw new NotImplementedException();

        }



        // Tallennus BIN
        private void SaveBIN(string filepath, List<Pelaaja> players)
        {
            using (Stream stream = File.Open(filepath, FileMode.Create))
            {
                // serialisoidaan lista pelaajista ja tallennetaan streamin kautta
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, players);
            }
        }



        // Pelaajien lataaminen tiedostosta
        public List<Pelaaja> Load(string filepath)
        {
            // palautusarvo
            List<Pelaaja> players = new List<Pelaaja>();

            // haetaan pääte
            string ext = Path.GetExtension(filepath);

            // tarkastetaan tiedostopäätteen perusteella
            // miten sitä käsitellään
            // HOX HUONO TAPA, tiedostopäätteellä ei oikeasti ole merkitystä
            switch (ext)
            {
                case ".xml":
                    players = this.LoadXML(filepath);
                    break;
                case ".bin":
                    players = this.LoadBIN(filepath);
                    break;
                default:
                    throw new Exception("Extension \"" + ext + "\" is not supported");
            }
            
            return players;
        }


        // Luetaan XML tiedostosta
        private List<Pelaaja> LoadXML(string filepath)
        {
            throw new NotImplementedException();
        }



        // Luetaan BINARY tiedostosta
        private List<Pelaaja> LoadBIN(string filepath)
        {
            // palautusarvo
            List<Pelaaja> players = new List<Pelaaja>();

            using (Stream stream = File.Open(filepath, FileMode.Open))
            {
                // deserialisoidaan lista pelaajista ja luetaan streamin kautta
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                players = (List<Pelaaja>)bformatter.Deserialize(stream);
            }

            return players;
        }
    }
}
