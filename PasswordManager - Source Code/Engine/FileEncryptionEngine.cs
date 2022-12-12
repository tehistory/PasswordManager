using System.IO;
using System.Security.Cryptography;
using System.Text;
using PasswordManager.Contracts;

namespace PasswordManager.Engine
{
    public class FileEncryptionEngine
    {
        public MemoryStream EncryptFile(User userData, SingleStreamFile fileString)
        {
            var rgb = new Rfc2898DeriveBytes(userData.Password, Encoding.Unicode.GetBytes(userData.Salt));
            var algorithm = new AesManaged();
            algorithm.BlockSize = 128;
            algorithm.KeySize = 128;
            var rgbKey = rgb.GetBytes(algorithm.KeySize / 8);
            var rgbIV = rgb.GetBytes(algorithm.BlockSize / 8);

            var bufferStream = new MemoryStream();

            var encryptor = algorithm.CreateEncryptor(rgbKey, rgbIV);

            var cryptoStream = new CryptoStream(bufferStream, encryptor, CryptoStreamMode.Write);

            var bytesToTransform = Encoding.Unicode.GetBytes(fileString.FileContents);
            cryptoStream.Write(bytesToTransform, 0, bytesToTransform.Length);
            cryptoStream.FlushFinalBlock();

            return bufferStream;
        }
    }
}
