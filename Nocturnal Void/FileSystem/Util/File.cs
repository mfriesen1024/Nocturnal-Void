using SFile = System.IO.File;

namespace Nocturnal_Void.FileSystem.Util
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
        public File(File parent, string path) { this.path = parent.path + "\\" + path; finalDir = parent.path; }

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
            if (!SFile.Exists(path)) { SFile.Create(path).Close(); return false; }
            return true;
        }

        /// <summary>
        /// Read all bytes from the file this object represents.
        /// </summary>
        /// <returns>The data read from the file as a byte array.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the file didn't exist.</exception>
        public byte[] ReadBytes()
        {
            if (VerifyFile()) { return SFile.ReadAllBytes(path); }
            throw new InvalidOperationException($"The file didn't exist, and therefore cannot be read.");
        }

        /// <summary>
        /// Writes the data to the file this object represents.
        /// </summary>
        /// <param name="data">An array of bytes to be written.</param>
        public void WriteBytes(byte[] data)
        {
            VerifyFile();
            SFile.WriteAllBytes(path, data);
        }
    }
}
