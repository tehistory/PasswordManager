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

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for CreateProfile.xaml
    /// </summary>
    public partial class CreateProfile : Window
    {
        public CreateProfile()
        {
            InitializeComponent();
        }

        private void Genbutton_Click(object sender, RoutedEventArgs e)
        {
            Random rng = new Random();
            char[] lowLetterCharRef = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] upLetterCharRef = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] numberCharRef = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            char[] specialCharRef = new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-','_','=','+','`','~',',','<','>','.','/','?' };
            string outPass = "";

            int x = rng.Next(lowLetterCharRef.Length);
            outPass.Append(lowLetterCharRef[x]);
            x = rng.Next(upLetterCharRef.Length);
            outPass.Append(upLetterCharRef[x]);
            x = rng.Next(numberCharRef.Length);
            outPass.Append(numberCharRef[x]);
            x = rng.Next(specialCharRef.Length);
            outPass.Append(specialCharRef[x]);

            for (int i = 4; i < 16; i++)
            {
                int z = rng.Next(4);

                if(z < 1)
                {
                    int y = rng.Next(lowLetterCharRef.Length);
                    outPass.Append(lowLetterCharRef[y]);
                }
                else if(z < 2)
                {
                    int y = rng.Next(upLetterCharRef.Length);
                    outPass.Append(upLetterCharRef[y]);
                }
                else if(z < 3)
                {
                    int y = rng.Next(numberCharRef.Length);
                    outPass.Append(numberCharRef[y]);
                }
                else if(z < 4)
                {
                    int y = rng.Next(specialCharRef.Length);
                    outPass.Append(specialCharRef[y]);
                }
            }

            PasswordBox.Text = outPass;
        }

        private void Createbutton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
