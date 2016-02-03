using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace Tehtava3D
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.test();
        }


        private void test()
        {
            List<FileModel> lista = new List<FileModel>();

            for (int i = 0; i < 100; i++)
            {
                FileModel temp = new FileModel();
                temp.Name = "Nimi " + i.ToString();
                temp.Path = "Path/to/file/if/there/is/one/well/there/always/is" + i.ToString();
                temp.Ext = "exe";
                lista.Add(temp);
            }

            dgFileList.ItemsSource = lista;
        }


        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result.ToString() == "OK") txtboxPath.Text = dialog.SelectedPath;
        }


        private void txtboxPath_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            dgFileList.ItemsSource = null;
            btnSave.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnAnalyze.IsEnabled = !string.IsNullOrWhiteSpace(txtboxPath.Text);
            cbVirtualMachine.IsEnabled = false;
            cbVirtualMachine.SelectedIndex = 0;
        }


        private void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(txtboxPath.Text))
                System.Windows.MessageBox.Show("Selected path is not valid!");
            else
            {
                string[] virtualMachines = Directory.GetDirectories(txtboxPath.Text);
                foreach (string virtualMachine in virtualMachines)
                {
                    System.Windows.MessageBox.Show(virtualMachine);
                }
                cbVirtualMachine.IsEnabled = true;
            }
        }
    }
}
