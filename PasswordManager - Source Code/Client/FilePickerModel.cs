using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Manager;

namespace PasswordManager.Client
{
    public class FilePickerModel
    {
        private string _FileLocation;

        private FilePickerManager _FilePickerManager;

        public FilePickerModel()
        {
            _FilePickerManager = new FilePickerManager();
        }

        public string FileLocation { get; set; }

        public void NewFile()
        {

        }

        public void LoadFile()
        {

        }
    }
}
