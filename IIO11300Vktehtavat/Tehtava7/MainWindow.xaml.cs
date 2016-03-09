using System.Windows;
using System.Windows.Controls;

namespace Tehtava7
{

    public partial class MainWindow : Window
    {
        private int 
            symbolCountInt = 0, 
            bigLetterCountInt = 0, 
            smallLetterCountInt = 0, 
            numberCountInt = 0, 
            specialSymbolCountInt = 0;


        public MainWindow()
        {
            InitializeComponent();
            this.updateLabels();
        }



        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.symbolCountInt = password.Text.Length;
        }



        private void updateLabels()
        {
            this.symbolCount.Content = this.symbolCountInt;
            this.bigLetterCount.Content = this.bigLetterCountInt;
            this.smallLetterCount.Content = this.smallLetterCountInt;
            this.numberCount.Content = this.numberCountInt;
            this.specialSymbolCount.Content = this.specialSymbolCountInt;
        }
    }
}
