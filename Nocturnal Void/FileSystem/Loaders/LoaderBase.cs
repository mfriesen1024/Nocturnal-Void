using File = Nocturnal_Void.FileSystem.Util.File;

namespace Nocturnal_Void.FileSystem.Loaders
{
    /// <summary>
    /// Abstract base class for data management.
    /// Loads, saves and stores various objects and data.
    /// </summary>
    public abstract class LoaderBase
    {
        public LoaderBase(string fName) { this.fName = fName; }

        /// <summary>
        /// The name of the file this loader should use.
        /// </summary>
        protected string fName;

        /// <summary>
        /// Loads data to a usable format.
        /// </summary>
        /// <param name="path">The path where data is stored.</param>
        public abstract void Load(File path);
        /// <summary>
        /// Saves data to a file.
        /// </summary>
        /// <param name="path">The path where data should be saved.</param>
        public abstract void Save(File path);
    }
}
