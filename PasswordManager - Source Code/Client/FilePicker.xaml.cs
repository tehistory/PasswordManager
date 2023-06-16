using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace PasswordManager.Client
{
    
    public partial class FilePicker
    {
        public FilePickerModel Vm;

        public FilePicker()
        {
            InitializeComponent();

            Vm = new FilePickerModel();
        }

        public void ChooseFile_Clicked(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter for file extension and default file extension
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.DefaultExt = ".txt";

            // Display OpenFileDialog by calling ShowDialog method
            bool? result = openFileDialog.ShowDialog();

            // Process file selection if user clicked OK
            if (result == true)
            {
                // Set FilePath property of FilePickerModel to selected file path
                Vm.FileLocation = openFileDialog.FileName;
                Vm.LoadFile();
            }
        }

        public void CreateFile_Clicked(object sender, RoutedEventArgs e)
        {
            // Create SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set filter for file extension and default file extension
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".txt";

            // Display SaveFileDialog by calling ShowDialog method
            bool? result = saveFileDialog.ShowDialog();

            // Process file selection if user clicked OK
            if (result == true)
            {
                // Get file path and create new file
                string filePath = saveFileDialog.FileName;
                File.Create(filePath).Close();

                // Set FilePath property of FilePickerModel to new file path
                Vm.FileLocation = filePath;
                Vm.NewFile();
            }
        }
    }
}