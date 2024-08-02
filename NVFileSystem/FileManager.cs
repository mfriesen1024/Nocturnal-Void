using NVFileSystem.Loaders;
using NVFileSystem.Util;
using File = NVFileSystem.Util.File;

namespace NVFileSystem
{
    public static class FileManager
    {
        public static ItemLoader ItemLoader { get; private set; } = new ItemLoader();


        public static void Load(string path)
        {
            File file = new File(path);

            ItemLoader.Load(file);
        }

        public static void Save(string path)
        {

        }        
    }
}
