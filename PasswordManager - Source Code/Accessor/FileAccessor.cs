using System;
using System.Collections.Generic;
using System.IO;

namespace PasswordManager.Accessor
{
    internal static class FileAccessor
    {
        public static List<byte> ReadFile(string fileName)
        {
            BinaryReader sReader = new BinaryReader(new FileStream(fileName, FileMode.Open));

            List<byte> outstream = new List<byte>();
            try
            {
                while (true)
                {
                    outstream.Add(sReader.ReadByte());
                }
            }
            catch (Exception e)
            {

            }
            sReader.Close();

            return outstream;
        }

        public static void WriteFile(string fileName, byte[] fileContents)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            BinaryWriter sWriter = new BinaryWriter(new FileStream(fileName, FileMode.CreateNew));

            sWriter.Write(fileContents);
            sWriter.Flush();
            sWriter.Close();
            
        }
    }
}
