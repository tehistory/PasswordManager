using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Contracts
{
    internal class User
    {
        public string Filename { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }
    }
}
