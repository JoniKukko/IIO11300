using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Tehtava4
{
    public partial class MainWindow : Window
    {
        private List<string> clubs = new List<string> {
            "Blues", "HIFK", "HPK", "Ilves", "JYP",
            "Kalpa", "KooKoo", "Kärpät", "Lukko", "Pelicans",
            "SaiPa", "Sport", "Tappara", "TPS", "Ässät" };

        private Pelaajat pelaajat = new Pelaajat();



        public MainWindow()
        {
            InitializeComponent();
            // alustukset
            this.cbClub.ItemsSource = this.clubs;
            this.cbClub.SelectedIndex = 0;
            this.tbStatusbar.Text = "Seurat ladattu";
            this.lbPlayerList.ItemsSource = this.pelaajat.pelaajat;
        }



        // Exit nappula
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        

        // uuden pelaajan luonti
        private void btnNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // luodaan uusi pelaaja
                decimal price;
                Decimal.TryParse(this.tbPrice.Text, out price);
                this.pelaajat.insertPlayer(this.tbFirstname.Text, this.tbLastname.Text, this.cbClub.SelectedItem.ToString(), price);

                // päivitetään lista ja tyhjennetään arvot
                this.lbPlayerList.Items.Refresh();
                this.ClearValues();

                this.tbStatusbar.Text = "Pelaaja lisätty";
            } catch(Exception ex)
            {
                this.tbStatusbar.Text = ex.Message;
            }
        }



        // haetaan pelaajan tiedot
        private void lbPlayerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // haetaan pelaaja
                Pelaaja pelaaja = this.pelaajat.selectPlayer(lbPlayerList.SelectedItem.ToString());

                this.tbFirstname.Text = pelaaja.Etunimi;
                this.tbLastname.Text = pelaaja.Sukunimi;
                this.tbPrice.Text = pelaaja.Siirtohinta.ToString();
                this.cbClub.SelectedValue = pelaaja.Seura;

                this.tbStatusbar.Text = "Pelaajan tiedot ladattu.";
            }
            catch (Exception ex)
            {
                this.tbStatusbar.Text = ex.Message;
            }
        }



        // pelaajan poisto
        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // haetaan pelaajan indeksi ja poistetaan se
                this.pelaajat.deletePlayer(lbPlayerList.SelectedItem.ToString());
                this.lbPlayerList.Items.Refresh();
                this.ClearValues();

                this.tbStatusbar.Text = "Pelaaja poistettu.";
            }
            catch (Exception ex)
            {
                this.tbStatusbar.Text = ex.Message;
            }
        }



        // talleta muutokset
        private void btnSavePlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // luodaan uusi pelaaja
                decimal price;
                Decimal.TryParse(this.tbPrice.Text, out price);
                this.pelaajat.insertPlayer(this.tbFirstname.Text, this.tbLastname.Text, this.cbClub.SelectedItem.ToString(), price);

                // poistetaan vanha pelaaja
                this.pelaajat.deletePlayer(lbPlayerList.SelectedItem.ToString());

                this.lbPlayerList.Items.Refresh();
                this.ClearValues();
                this.tbStatusbar.Text = "Pelaajan tiedot päivitetty.";
            }
            catch (Exception ex)
            {
                this.tbStatusbar.Text = ex.Message;
            }
        }



        // pelaajien tallennus
        private void btnWritePlayers_Click(object sender, RoutedEventArgs e)
        {
            // näytetään ja kysytään käyttäjältä tallennus sijainti
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            Nullable<bool> result = sfd.ShowDialog();
            
            // jos sijainti on true
            if (result == true)
            {
                using (Stream stream = File.Open(sfd.FileName, FileMode.Create))
                {
                    // serialisoidaan lista pelaajista ja tallennetaan streamin kautta
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bformatter.Serialize(stream, this.pelaajat.pelaajat);
                }
            }
        }



        // apumetodi
        private void ClearValues()
        {
            // tyhjennetään valinnat
            this.tbFirstname.Text = "";
            this.tbLastname.Text = "";
            this.tbPrice.Text = "";
            this.cbClub.SelectedIndex = 0;
        }

    }
}
