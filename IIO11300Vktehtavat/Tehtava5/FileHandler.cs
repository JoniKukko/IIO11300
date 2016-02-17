using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Tehtava4
{
    class FileHandler
    {
        
        // Pelaajien tallennus tiedostoon
        public void Save(string filepath, List<Pelaaja> players)
        {
            // Haetaan tiedostopääte
            string ext = Path.GetExtension(filepath);

            // käynnistetään stream
            using (Stream stream = File.Open(filepath, FileMode.Create))
            {
                // tarkastetaan tiedostopäätteen perusteella
                // missä muodossa se halutaan tallentaa
                switch (ext)
                {
                    case ".xml":
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pelaaja>));
                        xmlSerializer.Serialize(stream, players);
                        break;

                    case ".bin":
                        var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        bformatter.Serialize(stream, players);
                        break;

                    default:
                        throw new Exception("Extension \"" + ext + "\" is not supported");
                }
            }
        }


        


        // Pelaajien lataaminen tiedostosta
        public List<Pelaaja> Load(string filepath)
        {
            // palautusarvo
            List<Pelaaja> players = new List<Pelaaja>();
            // haetaan pääte
            string ext = Path.GetExtension(filepath);

            using (Stream stream = File.Open(filepath, FileMode.Open))
            {
                // tarkastetaan tiedostopäätteen perusteella
                // miten sitä käsitellään
                // HOX HUONO TAPA, tiedostopäätteellä ei oikeasti ole merkitystä
                switch (ext)
                {
                    case ".xml":
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Pelaaja>));
                        players = (List<Pelaaja>)serializer.Deserialize(stream);
                        break;

                    case ".bin":
                        var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        players = (List<Pelaaja>)bformatter.Deserialize(stream);
                        break;

                    default:
                        throw new Exception("Extension \"" + ext + "\" is not supported");
                }
            }

            return players;
        }


        
    }
}
