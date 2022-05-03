using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows;

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
        private string _password;
        //file name and location
        private string _file = "..\\protectedPasswordFile.pw";
        //storage of profiles
        List<Profile> storedProfiles;
        //
        //password setting
        public void setPassword(string pass)
        {
            _password = pass;
        }
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
        //file deletion method
        public void DeleteFile()
        {
            File.Delete(_file);
        }
        //file load method
        public List<Profile> LoadFile()
        {
            try
            {
                List<Profile> outList = new List<Profile>();

                StreamReader sReader = new StreamReader(_file);
                var outstream = sReader.ReadToEnd();
                sReader.Close();

                var rgb = new Rfc2898DeriveBytes(_password, Encoding.Unicode.GetBytes(_salt));
                var algorithm = new AesManaged();
                algorithm.BlockSize = 128;
                algorithm.KeySize = 128;
                var rgbKey = rgb.GetBytes(algorithm.KeySize / 8);
                var rgbIV = rgb.GetBytes(algorithm.BlockSize / 8);

                var bufferStream = new MemoryStream();

                var decryptor = algorithm.CreateDecryptor(rgbKey, rgbIV);

                var cryptoStream = new CryptoStream(bufferStream, decryptor, CryptoStreamMode.Write);

                var bytesToTransform = Encoding.Unicode.GetBytes(outstream);
                cryptoStream.Write(bytesToTransform, 0, bytesToTransform.Length);
                cryptoStream.FlushFinalBlock();

                bufferStream.Position = 0;
                var transformedBytes = bufferStream.ToArray();

                var outputString = Encoding.Unicode.GetString(transformedBytes);

                cryptoStream.Close();
                bufferStream.Close();

                String[] ProfileArray = outputString.Split(',');

                try
                {
                    for (int i = 0; i < ProfileArray.Length; i = i + 3)
                    {
                        Profile tempProf = new Profile(ProfileArray[i], ProfileArray[i + 1], ProfileArray[i + 2]);
                        outList.Add(tempProf);
                    }
                }
                catch (Exception e)
                {

                }

                storedProfiles = outList;
                return outList;

            }catch(Exception e)
            {
                MessageBox.Show(e.Message + "\nYou may have entered in the wrong password", "LoadFileError", MessageBoxButton.OK);
                return null;
            }
        }
        //add profile method
        public async Task AddProfile(Profile newProf)
        {
            var exProfs = LoadFile();
            if (exProfs == null)
            {
                List<Profile> outList = new List<Profile>();
                outList.Add(newProf);
                exProfs = outList;
            }
            else
            {
                exProfs.Add(newProf);
            }
            

            await SaveProfiles(exProfs);
        }
        //deletes profile from file
        public async Task DeleteProfile(Profile delProf, List<Profile> curProf)
        {
            List<Profile> tempProf = curProf;

            if (!tempProf.Remove(delProf))
            {
                foreach (var prof in curProf)
                {
                    if (prof.getName() == delProf.getName())
                    {
                        tempProf.Remove(prof);
                        break;
                    }
                }
            }

            await SaveProfiles(tempProf);
        }
        //save profile list to file
        public async Task SaveProfiles(List<Profile> inProf)
        {
            string outstring = "";
            int i = 0;

            foreach(var prof in inProf)
            {
                if (i == 0)
                {
                    outstring = outstring + prof.getName() + ',' + prof.getUsername() + ',' + prof.getPassword();
                }
                else
                {
                    outstring = outstring + ',' + prof.getName() + ',' + prof.getUsername() + ',' + prof.getPassword();
                }
                i++;
            }

            var rgb = new Rfc2898DeriveBytes(_password, Encoding.Unicode.GetBytes(_salt));
            var algorithm = new AesManaged();
            algorithm.BlockSize = 128;
            algorithm.KeySize = 128;
            var rgbKey = rgb.GetBytes(algorithm.KeySize / 8);
            var rgbIV = rgb.GetBytes(algorithm.BlockSize / 8);

            var bufferStream = new MemoryStream();

            var encryptor = algorithm.CreateEncryptor(rgbKey, rgbIV);

            var cryptoStream = new CryptoStream(bufferStream, encryptor, CryptoStreamMode.Write);

            var bytesToTransform = Encoding.Unicode.GetBytes(outstring);
            cryptoStream.Write(bytesToTransform, 0, bytesToTransform.Length);
            cryptoStream.FlushFinalBlock();

            bufferStream.Position = 0;
            var transformedBytes = bufferStream.ToArray();

            StreamWriter sWriter = new StreamWriter(_file);
            
            sWriter.Write(Encoding.Unicode.GetChars(transformedBytes));

            cryptoStream.Close();
            bufferStream.Close();
            sWriter.Close();
        }
        //export unencrypted file
        public void ExportFile(string filepath)
        {
            string exFile = "\\unencryptedPasswordFile.pw";
            File.Create(filepath + exFile);
            StreamWriter sWriter = new StreamWriter(filepath + exFile);
            try
            {
                var profList = LoadFile();

                string outstring = "";

                foreach (var prof in profList)
                {
                    outstring = outstring + prof.getName() + ',' + prof.getUsername() + ',' + prof.getPassword() + ',';
                }

                sWriter.Write(outstring);
                sWriter.Flush();
                sWriter.Close();
            }catch(Exception e)
            {
                sWriter.Flush();
                sWriter.Close();
                File.Delete(filepath + exFile);
                MessageBox.Show(e.Message);
            }
        }
        //import unencrypted file
        public void ImportFile(string filepath)
        {
            try
            {
                List<Profile> outList = new List<Profile>();

                StreamReader sReader = new StreamReader(filepath);

                string passFile = sReader.ReadToEnd();

                String[] ProfileArray = passFile.Split(',');

                try
                {
                    for (int i = 0; i < ProfileArray.Length; i = i + 3)
                    {
                        Profile tempProf = new Profile(ProfileArray[i], ProfileArray[i + 1], ProfileArray[i + 2]);
                        outList.Add(tempProf);
                    }

                    var exProfs = LoadFile();

                    if (exProfs == null)
                    {
                        exProfs = outList;
                    }
                    else
                    {
                        foreach (var prof in outList)
                        {
                            exProfs.Add(prof);
                        }
                    }

                    SaveProfiles(exProfs);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
