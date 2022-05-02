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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FIleController fCon = new FIleController();
        List<Profile> curProf = new List<Profile>();
        public MainWindow()
        {
            InitializeComponent();
            initProfile();
        }

        public void initProfile()
        {
            if (fCon.CheckFile())
            {
                //ask for password and pass to filecontroller
                LoginPage PopUp = new LoginPage();

                if (PopUp.ShowDialog() == true)
                {
                    fCon.setPassword(PopUp.textBox.Text);
                    RefreshProf();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                CreateFile PopUp = new CreateFile();

                if (PopUp.ShowDialog() == true)
                {
                    fCon.setPassword(PopUp.textBox.Text);
                    fCon.CreateFile();
                }
                else
                {
                    this.Close();
                }

            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(var prof in curProf)
            {
                if(prof.getName() == comboBox.SelectedItem.ToString())
                {
                    ProfileName.Text = prof.getName();
                    UserName.Text = prof.getUsername();
                    Password.Text = prof.getPassword();
                }
            }
        }

        private void usernameCopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(UserName.Text);
        }

        private void passwordCopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Password.Text);
        }

        private async void Createbutton_Click(object sender, RoutedEventArgs e)
        {
            CreateProfile PopUp = new CreateProfile();

            if(PopUp.ShowDialog() == true)
            {
                Profile newProf = new Profile(PopUp.ProfileBox.Text, PopUp.UsernameBox.Text, PopUp.PasswordBox.Text);

                await fCon.AddProfile(newProf);
                RefreshProf();
            }

        }

        private void Deletebutton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to Delete the password file?", "Delete File", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            
            if(result == MessageBoxResult.Yes)
            {
                fCon.DeleteFile();
            }
        }

        public void RefreshProf()
        {
            List<Profile> profiles = new List<Profile>();

            profiles = fCon.LoadFile();
            if (profiles != null)
            {
                curProf = profiles;

                foreach (var prof in profiles)
                {
                    comboBox.Items.Add(prof.getName());
                }
            }
        }
    }
}
