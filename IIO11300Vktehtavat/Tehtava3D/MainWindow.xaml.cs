using System.Collections.Generic;
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
            txtboxFilename.Text = result.ToString();
        }
    }
}
