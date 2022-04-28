using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    internal class Profile
    {
        //website name, username, password
        private string _name { get; set; }
        private string _username { get; set; }
        private string _password { get; set; }

        public Profile(string name, string username, string password)
        {
            _name = name;
            _username = username;
            _password = password;
        }

        public string getName()
        {
            return _name;
        }
        public string getUsername()
        {
            return _username;
        }
        public string getPassword()
        {
            return _password;
        }
    }
}
