using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tehtava7
{

    public partial class MainWindow : Window
    {
        // alustukset
        private int 
            symbolCountInt = 0, 
            bigLetterCountInt = 0, 
            smallLetterCountInt = 0, 
            numberCountInt = 0, 
            specialSymbolCountInt = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            this.updateResultLabel();
            this.updateIntLabels();
        }



        // kun teksti muuttuu niin lasketaan symbolit ja päivitetään tulokset
        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.calculateSymbols(this.password.Text);
            this.updateResultLabel();
            this.updateIntLabels();
        }



        // lasketaan symbolit
        private void calculateSymbols(string str)
        {
            int temp;
            // kokonaispituus
            this.symbolCountInt = str.Length;
            // isot kirjaimet
            this.bigLetterCountInt = str.Count(c => char.IsUpper(c));
            // pienet kirjaimet
            this.smallLetterCountInt = str.Count(c => char.IsLower(c));
            // numerot
            this.numberCountInt = str.Count(c => int.TryParse(c.ToString(), out temp));
            // spesiaalimerkit on kaikki muut merkit
            this.specialSymbolCountInt = this.symbolCountInt - this.bigLetterCountInt - this.smallLetterCountInt - this.numberCountInt;
        }



        // päivitetään resultti
        private void updateResultLabel()
        {
            // lasketaan kuinka montaa eri merkkiluokkaa on käytössä
            int symbolClassCount = 0;
            if (this.bigLetterCountInt != 0) symbolClassCount++;
            if (this.smallLetterCountInt != 0) symbolClassCount++;
            if (this.numberCountInt != 0) symbolClassCount++;
            if (this.specialSymbolCountInt != 0) symbolClassCount++;
            

            if (this.symbolCountInt == 0)
            {   // jos salasanakenttä on tyhjä
                this.result.Content = "Anna salasana";
                this.result.Background = new SolidColorBrush(Color.FromRgb(100, 100, 100));
            }
            else if (this.symbolCountInt < 8 || symbolClassCount == 1)
            {   // merkkejä vähemmän kuin kahdeksan tai pelkästään yhden merkkiluokan merkkejä
                this.result.Content = "bad";
                this.result.Background = new SolidColorBrush(Color.FromRgb(255, 153, 51));
            }
            else if (this.symbolCountInt < 12 || symbolClassCount == 2)
            {   // merkkejä vähemmän kuin kaksitoista ja vain kahden merkkiluokkan merkkejä
                this.result.Content = "fair";
                this.result.Background = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            }
            else if (this.symbolCountInt < 16 || symbolClassCount == 3)
            {   // merkkejä vähemmän kuin kuusitoista ja kolmen merkkiluokan merkkejä
                this.result.Content = "moderate";
                this.result.Background = new SolidColorBrush(Color.FromRgb(153, 255, 153));
            } 
            else
            {   // merkkejä vähintään kuusitoista ja sisältää kaikkien neljän merkkiluokan merkkejä
                this.result.Content = "good";
                this.result.Background = new SolidColorBrush(Color.FromRgb(0, 153, 0));
            }
        }



        // päivitetään labelit
        private void updateIntLabels()
        {
            this.symbolCount.Content = this.symbolCountInt;
            this.bigLetterCount.Content = this.bigLetterCountInt;
            this.smallLetterCount.Content = this.smallLetterCountInt;
            this.numberCount.Content = this.numberCountInt;
            this.specialSymbolCount.Content = this.specialSymbolCountInt;
        }
    }
}
