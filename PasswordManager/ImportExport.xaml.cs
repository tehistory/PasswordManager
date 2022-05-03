using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for ImportExport.xaml
    /// </summary>
    public partial class ImportExport : Window
    {
        public ImportExport()
        {
            InitializeComponent();
        }

        public bool importBool;

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            string filepath = exportTextBox.Text.ToString();
            if (Directory.Exists(filepath))
            {
                importBool = false;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Folder Path not valid", "Error", MessageBoxButton.OK);
            }
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            string filepath = importTextBox.Text.ToString();
            if (File.Exists(filepath))
            {
                importBool = true;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("File Path not valid", "Error", MessageBoxButton.OK);
            }
        }
    }
}
