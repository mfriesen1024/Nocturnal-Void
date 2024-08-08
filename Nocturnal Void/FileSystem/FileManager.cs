using Nocturnal_Void.Entity.Items;
using Nocturnal_Void.Entity.Movable;
using Nocturnal_Void.FileSystem.Loaders;
using Nocturnal_Void.MapConstructs;
using TZPRenderers.Text;
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

        /// <summary>
        /// Initializes the system with sample data.
        /// </summary>
        public static void Init()
        {
            // Default items.
            RPGTile[,] tiles = { { new RPGTile('d', ConsoleColor.White, ConsoleColor.Black) } };
            RelativeRenderable renderable = new RelativeRenderable(tiles);

            // Item init.
            Consumable[] consumables = [new Consumable(0, 1)];
            ItemLoader.SetConsumables(consumables);
            Equipment[] equip = [new Equipment(1, 0)];
            ItemLoader.SetEquip(equip);
            Gold goldObj = new Gold(1);
            Gold[] goldObjs = [goldObj];
            ItemLoader.SetGold(goldObjs);
            Pickup[] pickups = [new Pickup(renderable, goldObj, Vector2.Zero)];
            ItemLoader.SetPickups(pickups);

            // Entity init.
            EntityLoader.SetPlayer(new Player("Player", 100, 0, 10, Vector2.Zero, renderable));
            Foe[] foes = [new Foe("SampleFoe", 10, 5, 2, 2, Vector2.Zero, renderable)];
            EntityLoader.SetFoes(foes);
        }
    }
}
