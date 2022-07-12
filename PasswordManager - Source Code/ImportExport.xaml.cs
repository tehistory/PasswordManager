using System.IO;
using System.Windows;

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
