using Nocturnal_Void.Entity.Items;
using Nocturnal_Void.Managers;
using Nocturnal_Void.MapConstructs;
using TZPRenderers.Text;

namespace Nocturnal_Void.Entity.Movable
{
    /// <summary>
    /// Represents an opponent.
    /// </summary>
    public class Foe : MobBase
    {
        // Do loot things here.
        public Item loot; // Idk how we're going to assign loot. Deal with this later.
        public delegate void DeathCallback(Item loot);
        public DeathCallback OnDeath = (ignored) => { }; // Assign later.

        public Foe()
        {
            statMan.OnDeath += delegate { OnDeath(loot); };
        }

        public override MobBase Clone()
        {
            Foe foe = (Foe)MemberwiseClone();
            foe.statMan = statMan.Clone();

            return foe;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This should be a temporary operator.
        /// </summary>
        /// <param name="bytes"></param>
        public static explicit operator Foe(byte[] bytes)
        {
            List<byte> list = new List<byte>();

            // Construct the name.
            byte nameLength = bytes[0];
            char[] chars = new char[nameLength];
            for (int i = 1; i < nameLength; i++)
            {
                chars[i - 1] = (char)bytes[i];
            }
            string name = new string(chars);

            // Construct basic stats, adding 1 to start index due to our namelength byte.
            int def = BitConverter.ToInt32(bytes, 1 + nameLength);
            int str = BitConverter.ToInt32(bytes, 5 + nameLength);
            int hp = BitConverter.ToInt32(bytes, 9 + nameLength);
            StatManager statMan = new StatManager(hp);

            // Construct renderable.
            // Add 0 because we dont want to eat disc space for a value we never use.
            var tileBytes = list.GetRange(13 + nameLength, 2); tileBytes.Add(0);
            RPGTile[,] tileArray = new RPGTile[,] { { (RPGTile)tileBytes.ToArray() } };
            RelativeRenderable renderable = new RelativeRenderable(tileArray);

            // Finally construct the foe itself.
            return new Foe() { def = def, str = str, statMan = statMan, renderable = renderable };
        }

        public static explicit operator byte[](Foe foe)
        {
            List<byte> list = new List<byte>();

            // Deconstruct name
            list.Add((byte)foe.name.Length); // Add the name length so the inverse operation works.
            foreach (char c in foe.name) { list.Add((byte)c); }

            // Deconstruct stats
            list.AddRange(BitConverter.GetBytes(foe.def));
            list.AddRange(BitConverter.GetBytes(foe.str));
            list.AddRange(BitConverter.GetBytes(foe.statMan.MaxHP));

            var tileBytes = ((byte[])(RPGTile)foe.renderable.tiles[0, 0]).ToList();
            list.AddRange(tileBytes.GetRange(0, 2)); // Only store the first 2 bytes to not waste space.

            return list.ToArray();
        }
    }
}
