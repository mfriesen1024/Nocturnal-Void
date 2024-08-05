using Nocturnal_Void.FileSystem.Loaders;
using File = Nocturnal_Void.FileSystem.Util.File;

namespace Nocturnal_Void.FileSystem
{
    public static class FileManager
    {
        public static ItemLoader ItemLoader { get; private set; } = new ItemLoader("items.bin");
        public static EntityLoader EntityLoader { get; private set; } = new EntityLoader("entities.bin");

        public static void Load(string path)
        {
            File dir = new File(path);

            ItemLoader.Load(dir);
            EntityLoader.Load(dir);
        }

        public static void Save(string path)
        {
            File dir = new File(path);

            ItemLoader.Save(dir);
            EntityLoader.Save(dir);
        }
    }
}
