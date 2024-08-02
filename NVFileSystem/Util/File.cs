using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVFileSystem.Util
{
    /// <summary>
    /// Represents a file or directory.
    /// </summary>
    public class File
    {
        public string path;
        public string finalDir;

        /// <summary>
        /// Create a new instance of the file class.
        /// </summary>
        /// <param name="path">The final path of the object.</param>
        public File(string path) { this.path = path; }
        /// <summary>
        /// Create a new instance of the file class.
        /// </summary>
        /// <param name="parent">The parent file/directory</param>
        /// <param name="path">The final path of the object.</param>
        public File(File parent, string path) { this.path = parent.path + "\\" +  path; finalDir = parent.path; }

        // Initialize the object, should set values such as finalDir and be called during constructor.
        protected void Init()
        {
            if (path != null) { }
            else
            {
                int substringLoc = path.LastIndexOf("\\");
                finalDir = path.Substring(0, substringLoc);
            }
        }

        /// <summary>
        /// Ensure that the file this object represents does in fact exist.
        /// </summary>
        /// <returns>Whether or not the file existed prior to the call.</returns>
        public bool VerifyFile()
        {
            if (!Directory.Exists(finalDir)) { Directory.CreateDirectory(finalDir); }
            if (!System.IO.File.Exists(path)) {  System.IO.File.Create(path).Close(); return false; }
            return true;
        }

        public byte[] ReadBytes()
        {
            if (VerifyFile()) { return System.IO.File.ReadAllBytes(path); }
            throw new InvalidOperationException($"The file didn't exist, and therefore cannot be read.");
        }

        public void WriteBytes(byte[] data)
        {
            VerifyFile();
            System.IO.File.WriteAllBytes(path, data);
        }
    }
}
