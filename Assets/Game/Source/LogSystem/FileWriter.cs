using System;
using System.IO;
using System.Text;

namespace Game.Source
{
    public class FileWriter
    {
        private string _folder;
        private string _filePath;

        private const string DATA_FORMAT = "yyyy-MM-dd";


        public FileWriter(string Folder)
        {
            _folder = Folder;
            ManagePath();
        }

        private void ManagePath()
        {
            _filePath = $@"{_folder}/{DateTime.UtcNow.ToString(DATA_FORMAT)}";
        }

        public void Write(string Messeg)
        {
            using (FileStream fs = File.Open(_filePath,FileMode.Append , FileAccess.Write , FileShare.Read))
            {
                var bytes = Encoding.UTF8.GetBytes(Messeg);
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}