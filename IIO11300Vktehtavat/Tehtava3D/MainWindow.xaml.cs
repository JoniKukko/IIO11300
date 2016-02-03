using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Forms;

namespace Tehtava3D
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        

        // Selaa-napin painallus
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            // avataan dialogi ja jos käyttäjä on painanut ok-nappia
            // niin haetaan valittu polku tekstiboksiin
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result.ToString() == "OK") txtboxPath.Text = dialog.SelectedPath;
        }



        // kun polku-tekstiboksin teksti muuttuu
        private void txtboxPath_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // nollataan kaikki ja aloitetaan "alusta"
            dgFileList.ItemsSource = null;
            btnSave.IsEnabled = false;
            btnAnalyze.IsEnabled = !string.IsNullOrWhiteSpace(txtboxPath.Text);
            cbVirtualMachine.IsEnabled = false;
            cbVirtualMachine.ItemsSource = null;
            btnUpdate.IsEnabled = false;
        }



        // Annetun polun analysointi virtuaalikoneiden osalta
        // (ensimmäisen tason kansiot)
        private void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            // testataan että annettu polku varmasti on olemassa
            if (!Directory.Exists(txtboxPath.Text))
            {
                // jos polkua ei ole annetaan virheilmoitus
                System.Windows.MessageBox.Show("Backup path is not valid!");
            }
            else
            {
                // jos polku on olemassa niin voidaan jatkaa eteenpäin

                // alustukset
                List<FolderModel> virtualmachines = new List<FolderModel>();
                string[] VMpaths = Directory.GetDirectories(txtboxPath.Text);

                // Lisätään tulevaan vetovalikkoon valmiiksi "All"-vaihtoehto
                FolderModel All = new FolderModel();
                All.Name = "All";
                All.Path = txtboxPath.Text;
                virtualmachines.Add(All);

                // Virtuaalikone on todellisuudessa annetun polun
                // ensimmäisen tason kansiot (SERVER-VMDEV jne..)
                foreach (string VMpath in VMpaths)
                {
                    // luodaan "kansio"-model, annetaan perustiedot ja lisätään listaan
                    FolderModel virtualmachine = new FolderModel();
                    virtualmachine.Name = Path.GetFileName(VMpath);
                    virtualmachine.Path = Path.GetDirectoryName(VMpath);
                    virtualmachines.Add(virtualmachine);
                }

                // Vetovalikossa näytetään "Name" ja tämän jälkeen se on enabloitu
                cbVirtualMachine.DisplayMemberPath = "Name";
                cbVirtualMachine.ItemsSource = virtualmachines;
                cbVirtualMachine.IsEnabled = true;
            }
        }



        // virtuaalikoneen valinta vaihtuu
        private void cbVirtualMachine_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Muutamia perusnollauksia virtuaalikoneen tiedostojen osalta
            dgFileList.ItemsSource = null;
            btnUpdate.IsEnabled = true;
            btnSave.IsEnabled = false;
        }



        // Update-nappula hakee valitun virtuaalikoneen varmuuskopioitujen tiedostojen
        // tiedot ja luo niistä listan mikä näytetään käyttäjälle
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Nopeat alustukset alkuun
            dgFileList.ItemsSource = null;
            btnSave.IsEnabled = false;
            List<FileModel> files = new List<FileModel>();

            // erotellaan virtuaalikoneen polku
            // ja päätellään oliko valittuna "all" vai jokin muu
            // sen perusteella haetaan kansion kaikki tiedostot
            FolderModel selectedVM = (FolderModel)cbVirtualMachine.SelectedItem;
            string rootPath = cbVirtualMachine.SelectedIndex == 0 ? selectedVM.Path : selectedVM.FullPath;
            string[] filePaths = Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);
            
            // käydään löydetyt tiedostot läpi
            foreach (string filePath in filePaths)
            {
                // luodaan tiedostomalli ja fileinfo
                FileModel file = new FileModel();
                FileInfo info = new FileInfo(filePath);

                // FileInfoa ei voi periä joten FileModeliin joudutaan
                // asettamaan perustiedot käsin
                file.Name = Path.GetFileNameWithoutExtension(filePath);
                file.Ext = info.Extension;
                file.RealPath = info.DirectoryName;
                file.Created = info.CreationTime;
                file.Modified = info.LastWriteTime;
                file.Size = info.Length;
                file.Versions = new List<FileModel>();


                // virtuaalikoneen ja cronjobin erottaminen kansiopolusta
                // rikotaan path "/"-merkin kohdalta listaksi
                var TempPath = info.DirectoryName.Substring(selectedVM.Path.Length);
                List<string> pathParts = TempPath.Split(Path.DirectorySeparatorChar).ToList();

                // valitaan listan kolme ensimmäistä muihin tehtäviin
                file.VirtualMachine = pathParts[0];
                file.BackupFolder = pathParts[1] + pathParts[2];

                // poistetaan listan kolme ensimmäistä
                pathParts.RemoveAt(2);
                pathParts.RemoveAt(1);
                pathParts.RemoveAt(0);

                // kasataan lista uudestaan ilman noita kolmea.
                file.Path = Path.DirectorySeparatorChar + String.Join(Path.DirectorySeparatorChar.ToString(), pathParts.ToArray());
                // virtuaalikoneen ja cronjobin erottaminen kansiopolusta on valmis


                // Viimeiseksi etsitään onko kyseinen tiedosto ensimmäinen laatuaan tällä listalla
                // vai onko kyseessä listaan aiemmin lisätyn tiedoston eri versio
                // Versio jos path, filename ja virtualmachine ovat samoja
                var index = files.FindIndex(i => i.Path == file.Path && i.Filename == file.Filename && i.VirtualMachine == file.VirtualMachine);

                // Jos versio ja nykyinen on uudempi kuin aikaisemmin listaan lisätty
                if (index != -1 && (files[index].Modified < file.Modified))
                {
                    // siirretään aiemmin lisätyn versiot tämän versioiksi
                    file.Versions = files[index].Versions;
                    // tyhjennetään aimmin lisätyn versiot
                    files[index].Versions = new List<FileModel>();
                    // lisätään aiemmin lisätty tämän versioksi
                    file.Versions.Add(files[index]);
                    // poistetaan aiemmin lisätty ja lisätään nykyinen listaan
                    files.RemoveAt(index);
                    files.Add(file);
                }
                // jos versio muttei uudempi
                else if (index != -1)
                    // lisätään aiemmin löytyneen versioksi
                    files[index].Versions.Add(file);
                // jos versiota ei ole
                else
                    // niin lisätään se uutena
                    files.Add(file);
            }

            // Valmis lista taulukkoon näytille
            // jos lista ei ole tyhjä niin tulosjoukon voi tallentaa save-nappulalla
            dgFileList.ItemsSource = files;
            if (files.Count != 0) btnSave.IsEnabled = true;

        }


        // save-nappula tallentaa tulosjoukon binaaritiedostoon
        // myöhempää tarkastelua varten
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // kysytään käyttäjältä tallennuspolku
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            // jos käyttäjä painaa "Ok"
            if (result.ToString() == "OK")
            {
                try
                {
                    // muodostetaan datagridistä uudelleen filemodel lista
                    List<FileModel> files = (List<FileModel>)dgFileList.ItemsSource;

                    // luodaan oikea tiedostopolku
                    string serializationFile = Path.Combine(dialog.SelectedPath, "BackupAnalyzer-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bin");
                    // ja streamillä luodaan tiedosto ja pusketaan binaarit sisään
                    using (Stream stream = File.Open(serializationFile, FileMode.Create))
                    {
                        var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        bformatter.Serialize(stream, files);
                    }
                    // using sulkee streamin automaagisesti..

                }
                catch (UnauthorizedAccessException ex)
                {
                    System.Windows.MessageBox.Show("Selected path is not writable!");
                }
                catch (SerializationException ex)
                {
                    System.Windows.MessageBox.Show("Problems with serialization!");
                }
            }
        }
    }
}
