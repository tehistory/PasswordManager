using System.Windows;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for CreateFile.xaml
    /// </summary>
    public partial class CreateFile : Window
    {
        public CreateFile()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //create file, encrypt with password
            //goto mainwindow
            DialogResult = true;
        }
    }
}
