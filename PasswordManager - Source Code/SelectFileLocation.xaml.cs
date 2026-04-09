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
using Microsoft.Win32;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for SelectFileLocation.xaml
    /// </summary>
    public partial class SelectFileLocation : Window
    {
        public string FilePath { get; set; }

        public SelectFileLocation()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Password Files (*.pw)|*.pw|All Files (*.*)|*.*";
            openFileDialog.Title = "Select Password File";

            if (openFileDialog.ShowDialog() == true)
            {
                filePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            FilePath = filePathTextBox.Text;
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
