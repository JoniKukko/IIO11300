using Microsoft.Win32;
using System;
using System.Windows;

namespace H1MediaPlayer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MyInitialize();
        }

        private void MyInitialize()
        {
            txtboxFileName.Text = "D:\\H3247\\CoffeeMaker.mp4";
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtboxFileName.Text.Length == 0 || !File.Exists(txtboxFileName.Text))
                    throw new Exception("Tiedostoa ei löydy");
                
                mediaElement.Source = new Uri(txtboxFileName.Text);
                mediaElement.Play();
                btnPause.IsEnabled = btnStop.IsEnabled = true;
                btnStart.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
            btnPause.IsEnabled = btnStop.IsEnabled = false;
            btnStart.IsEnabled = true;
            btnStart.Content = "Continue";
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            btnPause.IsEnabled = btnStop.IsEnabled = false;
            btnStart.IsEnabled = true;
            btnStart.Content = "Start";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "d:\\salesa";
            ofd.Filter = "Video-tiedostot|*.mp4|All files|*.*";
            Nullable<bool> result = ofd.ShowDialog();
            

            if (result == true)
            {
                txtboxFileName.Text = ofd.FileName;
            }
            
        }
    }
}
