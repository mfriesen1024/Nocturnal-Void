using Nocturnal_Void.FileSystem.Loaders;
using File = Nocturnal_Void.FileSystem.Util.File;

namespace Nocturnal_Void.FileSystem
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
