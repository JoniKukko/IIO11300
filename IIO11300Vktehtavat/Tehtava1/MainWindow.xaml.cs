/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 14.1.2016
* Authors: Joni Kukko, Esa Salmikangas
*/
using System;
using System.Windows;


namespace Tehtava1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double result, widht, height;

                // Default value of 0 is used if tryparse fails
                double.TryParse(txtWidht.Text, out widht);
                double.TryParse(txtHeight.Text, out height);

                result = BusinessLogicWindow.CalculatePerimeter(widht, height);

                txtPerimeter.Text = result.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //yield to an user that everything okay
                // WHY? "finally" is executed even when there where exceptions.
                MessageBox.Show("Everything might be okay.");
            }
        }

        
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
