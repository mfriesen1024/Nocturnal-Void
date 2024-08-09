using Nocturnal_Void.Entity.Items;
using Nocturnal_Void.Entity.Movable;
using Nocturnal_Void.FileSystem;
using TZPRenderers.Text;

namespace Nocturnal_Void.MapConstructs
{
    public class Map
    {
        public RelativeRenderable renderable;

        public RPGTile[,] tile;

        public Foe[] foes;

        public Pickup[] pickups;

        public static explicit operator Map(byte[] bytes)
        {
            var list = bytes.ToList();

            // First, lets define some bounds.
            int tilesX = BitConverter.ToInt32(bytes, 0);
            int tilesY = BitConverter.ToInt32(bytes, 4);
            int tileReqBytes = tilesX * tilesY * 3; // This is how many bytes we need for tile array.
            int fStart = BitConverter.ToInt32(bytes, 8);
            int fEnd = BitConverter.ToInt32(bytes, 12);
            int pStart = BitConverter.ToInt32(bytes, 16);
            int pEnd = BitConverter.ToInt32(bytes, 20);

            RPGTile[,] tiles = new RPGTile[tilesX, tilesY];

            for (int x = 0; x < tilesX; x++)
            {
                for (int y = 0; y < tilesY; y++)
                {
                    int startIndex = x * tilesY * 3 + y * 3;

                    byte[] tileData = list.GetRange(startIndex, 3).ToArray();

                    tiles[x, y] = (RPGTile)tileData;
                }
            }

            // Create renderable.
            RelativeRenderable renderable = new RelativeRenderable(tiles);

            List<Foe> foeList = new List<Foe>();
            // Create foe array.
            for (int i = fStart; i < fEnd; i += 12)
            {
                int x = BitConverter.ToInt32(bytes, i);
                int y = BitConverter.ToInt32(bytes, i + 4);
                int foeIndex = BitConverter.ToInt32(bytes, i + 8);

                Foe foe = (Foe)FileManager.EntityLoader.Foes[foeIndex].Clone();
                foe.SetPosition(new Vector2() { y = y, x = x });
                foeList.Add(foe);
            }

            List<Pickup> pickups = new List<Pickup>();
            // Create pickup array.
            for (int i = pStart; i < pEnd; i += Pickup.requiredBytes)
            {
                pickups.Add((Pickup)list.GetRange(i, Pickup.requiredBytes).ToArray());
            }

            Map map = new Map() { renderable = renderable, tile = tiles, foes = foeList.ToArray(), pickups = pickups.ToArray() };

            return map;
        }
    }
}
