using System;
using System.Collections.Generic;
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
        private List<Pelaaja> players = new List<Pelaaja>();


        public MainWindow()
        {
            InitializeComponent();
            this.cbClub.ItemsSource = this.clubs;
            this.cbClub.SelectedIndex = 0;
            this.tbStatusbar.Text = "Seurat ladattu";
            this.lbPlayerList.ItemsSource = this.players;
        }



        // Exit nappula
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        

        // uuden pelaajan luonti
        private void btnNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            try {
                // luodaan uusi pelaaja
                decimal price;
                Decimal.TryParse(this.tbPrice.Text, out price);
                Pelaaja newPlayer = new Pelaaja(this.tbFirstname.Text, this.tbLastname.Text, this.cbClub.SelectedItem.ToString(), price);

                // Tarkistetaan ettei samannimistä vielä ole
                if (this.players.Exists(x => x.KokoNimi == newPlayer.KokoNimi))
                    throw new Exception("Pelaaja on jo listalla!");

                // lisätään ja päivitetään lista
                this.players.Add(newPlayer);
                this.lbPlayerList.Items.Refresh();

                // tyhjennetään valinnat
                this.tbFirstname.Text = "";
                this.tbLastname.Text = "";
                this.tbPrice.Text = "";
                this.cbClub.SelectedIndex = 0;

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
                // tarkistetaan ettei valinta ole tyhjä
                // vähän huono paikka tälle..
                if (lbPlayerList.SelectedItem == null)
                    throw new Exception("Pelaajaa ei ole valittu");

                // haetaan pelaaja
                int playerIndex = this.players.FindIndex(x => x.EsitysNimi == lbPlayerList.SelectedItem.ToString());

                this.tbFirstname.Text = this.players[playerIndex].Etunimi;
                this.tbLastname.Text = this.players[playerIndex].Sukunimi;
                this.tbPrice.Text = this.players[playerIndex].Siirtohinta.ToString();
                this.cbClub.SelectedValue = this.players[playerIndex].Seura;

                this.tbStatusbar.Text = "Pelaajan tiedot ladattu";
            }
            catch (Exception ex)
            {
                this.tbStatusbar.Text = ex.Message;
            }
        }
    }
}
