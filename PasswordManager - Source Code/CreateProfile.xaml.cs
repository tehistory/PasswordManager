using System;
using System.Windows;

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
            char[] specialCharRef = new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '`', '~', '<', '>', '.', '/', '?' };
            string outPass = "";

            int x = rng.Next(lowLetterCharRef.Length);
            outPass = lowLetterCharRef[x].ToString();
            x = rng.Next(upLetterCharRef.Length);
            outPass = outPass + upLetterCharRef[x].ToString();
            x = rng.Next(numberCharRef.Length);
            outPass = outPass + numberCharRef[x].ToString();
            x = rng.Next(specialCharRef.Length);
            outPass = outPass + specialCharRef[x].ToString();

            for (int i = 1; i <= 16; i++)
            {
                int z = rng.Next(5);

                if (z <= 1)
                {
                    x = rng.Next(lowLetterCharRef.Length);
                    outPass = outPass + lowLetterCharRef[x].ToString();
                }
                else if (z <= 2)
                {
                    x = rng.Next(upLetterCharRef.Length);
                    outPass = outPass + upLetterCharRef[x].ToString();
                }
                else if (z <= 3)
                {
                    x = rng.Next(numberCharRef.Length);
                    outPass = outPass + numberCharRef[x].ToString();
                }
                else
                {
                    x = rng.Next(specialCharRef.Length);
                    outPass = outPass + specialCharRef[x].ToString();
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
