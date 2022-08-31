namespace PasswordManager.Contracts
{
    internal class Profile
    {
        //website name, username, password
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Profile(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
        }
        
    }
}
