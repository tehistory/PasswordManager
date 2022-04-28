using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace PasswordManager
{
    internal class FIleController
    {
        /*
         * The salt could be bound to the usb drive locking the passwords to only being accessed on the drive, 
         * not sure how to do this yet
         */
        //encryption salt ~ temp value
        private string _salt = "salt";
        //password protected string
        private string _password { get; set; }
        //file name and location
        private string _file = "..\\protectedPasswordFile.pw";
        //storage of profiles
        List<Profile> storedProfiles;
        //
        //file checking method
        public bool CheckFile()
        {
            try
            {
                if (File.Exists(_file))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }catch(FileNotFoundException fnfe)
            {
                return false;
            }
        }
        //file creation method
        public void CreateFile()
        {
            File.Create(_file);
        }
        //file load method
        public List<Profile> LoadFile()
        {
            List<Profile> outList = new List<Profile>();

            StreamReader sReader = new StreamReader(_file);
            var outstream = sReader.ReadToEnd();

            var rgb = new Rfc2898DeriveBytes(_password, Encoding.Unicode.GetBytes(_salt));
            var algorithm = new AesManaged();
            var rgbKey = rgb.GetBytes(algorithm.KeySize / 8);
            var rgbIV = rgb.GetBytes(algorithm.BlockSize / 8);

            var bufferStream = new MemoryStream();

            var decryptor = algorithm.CreateDecryptor(rgbKey, rgbIV);

            var cryptoStream = new CryptoStream(bufferStream, decryptor, CryptoStreamMode.Read);

            var bytesToTransform = Encoding.Unicode.GetBytes(outstream);
            cryptoStream.Write(bytesToTransform, 0, bytesToTransform.Length);
            cryptoStream.FlushFinalBlock();

            var outputString = Encoding.Unicode.GetString(bytesToTransform);

            cryptoStream.Close();
            bufferStream.Close();
            sReader.Close();

            String[] ProfileArray = outputString.Split(',');

            try
            {
                for (int i = 0; i < ProfileArray.Length; i = i + 3)
                {
                    Profile tempProf = new Profile(ProfileArray[i], ProfileArray[i + 1], ProfileArray[i + 2]);
                    outList.Add(tempProf);
                }
            }catch(Exception e)
            {
                
            }

            storedProfiles = outList;
            return outList;
        }
        //add profile method
        public async void AddProfile(Profile newProf)
        {
            var exProfs = LoadFile();

            exProfs.Add(newProf);

            await SaveProfiles(exProfs);
        }
        //save profile list to file
        public async Task SaveProfiles(List<Profile> inProf)
        {
            string outstring = "";

            foreach(var prof in inProf)
            {
                outstring = outstring + prof.getName() + ',' + prof.getUsername() + ',' + prof.getPassword() + ',';
            }

            var rgb = new Rfc2898DeriveBytes(_password, Encoding.Unicode.GetBytes(_salt));
            var algorithm = new AesManaged();
            var rgbKey = rgb.GetBytes(algorithm.KeySize / 8);
            var rgbIV = rgb.GetBytes(algorithm.BlockSize / 8);

            var bufferStream = new MemoryStream();

            var encryptor = algorithm.CreateEncryptor(rgbKey, rgbIV);

            var cryptoStream = new CryptoStream(bufferStream, encryptor, CryptoStreamMode.Write);

            var bytesToTransform = Encoding.Unicode.GetBytes(outstring);
            cryptoStream.Write(bytesToTransform, 0, bytesToTransform.Length);
            cryptoStream.FlushFinalBlock();

            StreamWriter sWriter = new StreamWriter(_file);

            sWriter.Write(bytesToTransform);

            cryptoStream.Close();
            bufferStream.Close();
            sWriter.Close();
        }
        //
        //
    }
}
