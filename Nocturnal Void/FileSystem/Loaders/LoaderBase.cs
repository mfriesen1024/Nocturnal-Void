using Nocturnal_Void.FileSystem.Util;
using File = Nocturnal_Void.FileSystem.Util.File;

namespace Nocturnal_Void.FileSystem.Loaders
{
    public abstract class LoaderBase
    {
        public LoaderBase(string fName) { this.fName = fName; }

        protected string fName;
        public abstract void Load(File path);
        public abstract void Save(File path);
    }
}
