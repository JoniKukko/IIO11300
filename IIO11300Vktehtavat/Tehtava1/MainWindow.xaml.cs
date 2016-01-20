/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 20.1.2016
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
                double resultWindowArea, resultFrameSphere, resultFrameArea, windowWidht, windowHeight, frameWidht;

                // Default value of 0 is used if tryparse fails
                double.TryParse(txtWindowWidht.Text, out windowWidht);
                double.TryParse(txtWindowHeight.Text, out windowHeight);
                double.TryParse(txtFrameWidht.Text, out frameWidht);

                // Calculate results
                resultWindowArea = BusinessLogicWindow.CalculateWindowArea(windowWidht, windowHeight);
                resultFrameSphere = BusinessLogicWindow.CalculateFrameSphere(windowWidht, windowHeight);
                resultFrameArea = BusinessLogicWindow.CalculateFrameArea(windowWidht, windowHeight, frameWidht);


                // Show results
                txtWindowArea.Text = resultWindowArea.ToString();
                txtFrameSphere.Text = resultFrameSphere.ToString();
                txtFrameArea.Text = resultFrameArea.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
