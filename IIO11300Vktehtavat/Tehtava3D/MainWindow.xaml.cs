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
            btnAnalyze.IsEnabled = !string.IsNullOrWhiteSpace(txtboxPath.Text);
            cbVirtualMachine.IsEnabled = false;
            cbVirtualMachine.ItemsSource = null;
            btnUpdate.IsEnabled = false;
        }


        private void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(txtboxPath.Text))
                System.Windows.MessageBox.Show("Backup path is not valid!");
            else
            {
                List<FolderModel> virtualmachines = new List<FolderModel>();
                string[] VMpaths = Directory.GetDirectories(txtboxPath.Text);

                // Add first value "all"
                FolderModel All = new FolderModel();
                All.Name = "All";
                All.Path = txtboxPath.Text;
                virtualmachines.Add(All);

                foreach (string VMpath in VMpaths)
                {
                    FolderModel virtualmachine = new FolderModel();
                    virtualmachine.Name = Path.GetFileName(VMpath);
                    virtualmachine.Path = Path.GetDirectoryName(VMpath) + "\\";
                    virtualmachines.Add(virtualmachine);
                }

                cbVirtualMachine.DisplayMemberPath = "Name";
                cbVirtualMachine.ItemsSource = virtualmachines;
                cbVirtualMachine.IsEnabled = true;
            }
        }



        private void cbVirtualMachine_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            btnUpdate.IsEnabled = true;
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            FolderModel selectedVM = (FolderModel)cbVirtualMachine.SelectedItem;

            string checkPath = cbVirtualMachine.SelectedIndex == 0 ? selectedVM.Path : selectedVM.FullPath ;
            string[] filePaths = Directory.GetFiles(checkPath, "*", SearchOption.AllDirectories);
            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                FileModel file = new FileModel();
                file.Name = Path.GetFileNameWithoutExtension(filePath);
                file.Ext = Path.GetExtension(filePath);
                files.Add(file);
            }

            dgFileList.ItemsSource = files;
        }



        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
