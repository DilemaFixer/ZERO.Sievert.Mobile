using System;
using System.IO;
using System.Text;

namespace Game.LogSystem
{
    public class FileAppender
    {
        public string FileName { get; }
        private readonly object _lockObj = new object();

        public FileAppender(string FileName)
        {
            this.FileName = FileName;
        }

        public bool Append(string Content)
        {
            try
            {
                lock(_lockObj)
                {
                    using (FileStream fs = File.Open(FileName,FileMode.Append , FileAccess.Write , FileShare.Read))
                    {
                        var bytes = Encoding.UTF8.GetBytes(Content);
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}