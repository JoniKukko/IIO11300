/*
* Copyright (C) JAMK/IT/H3247 Joni Kukko
* This file is part of the IIO11300 course project.
* Created: 27.01.2016
* Authors: Joni Kukko
*/
using System;
using System.Collections.Generic;
using System.Windows;

namespace Tehtava2
{
    public partial class MainWindow : Window
    {
        // luodaan vain yksi lottogeneraattori
        private Lotto _lotto = new Lotto();


        public MainWindow()
        {
            InitializeComponent();
        }



        private void button_draw_Click(object sender, RoutedEventArgs e)
        {
            // tyhjennetään mahdollinen edellinen virhe
            label_messages.Content = "";

            try
            {
                // parsitaan kokonaisluku tekstboxista
                int drawns;
                int.TryParse(this.textBox_count.Text, out drawns);

                // switchissä määritetään mitä halutaan pelata
                switch (comboBox_games.Text)
                {
                    case "Lotto":
                        this.generateList(1, 39, 7, drawns);
                        break;
                    case "VikingLotto":
                        this.generateList(1, 48, 6, drawns);
                        break;
                    case "Eurojackpot":
                        this.generateList(1, 50, 5, drawns);
                        break;
                }

            } catch (Exception ex)
            {
                // exceptionin virhe käyttäjälle
                label_messages.Content = ex.Message;
            }
        }


        // apumetodi lotto-luokan kutsumiseen
        private void generateList(int min, int max, int count, int drawns)
        {
            // tyhjennetään aikaisempi lista ja asetetaan lottoluokkaan
            // pelin mukaiset rajat numeroille
            this.textBox_numbers.Text = "";
            this._lotto.setRange(min, max);

            // lotto luokkaa voi myös kutsua näin ylikuormituksella
            // lotto.getNumbers(min, max, count);
            // mutta mikäli sitä kutsutaan loopissa niin on 
            // tehokkaampaa käyttää setRangea erikseen

            // kuinka monta riviä halutaan
            for (int i = 0; i < drawns; i++)
            {
                // haetaan lista satunnaisista numeroista
                List<int> numbers = this._lotto.getNumbers(count);

                // käydään lista läpi tulostaen samalla se
                foreach (int number in numbers)
                    this.textBox_numbers.Text += number.ToString() + " ";

                // uusi rivi
                this.textBox_numbers.Text += Environment.NewLine;
            }
        }


        // listan tyhjennys
        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            this.textBox_numbers.Text = "";
        }
    }
}
