using Nocturnal_Void.Managers;
using Nocturnal_Void.MapConstructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZPRenderers.Text;

namespace Nocturnal_Void.Entity.Movable
{
    internal class Player : MobBase
    {
        // Player's name should always be Player, so just make a constant.
        public new string name { get { return "Player"; } }

        public override MobBase Clone()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public static explicit operator Player(byte[] bytes)
        {
            List<byte> list = new List<byte>();

            // Construct basic stats, adding 1 to start index due to our namelength byte.
            int def = BitConverter.ToInt32(bytes, 0);
            int str = BitConverter.ToInt32(bytes, 4);
            int hp = BitConverter.ToInt32(bytes, 8);
            StatManager statMan = new StatManager(hp);

            // Construct renderable.
            // Add 0 because we dont want to eat disc space for a value we never use.
            var tileBytes = list.GetRange(12, 2); tileBytes.Add(0);
            RPGTile[,] tileArray = new RPGTile[,] { { (RPGTile)tileBytes.ToArray() } };
            RelativeRenderable renderable = new RelativeRenderable(tileArray);

            // Finally construct the foe itself.
            return new Player() { def = def, str = str, statMan = statMan, renderable = renderable };
        }

        public static explicit operator byte[](Player player)
        {
            List<byte> list = new List<byte>();

            // Deconstruct stats
            list.AddRange(BitConverter.GetBytes(player.def));
            list.AddRange(BitConverter.GetBytes(player.str));
            list.AddRange(BitConverter.GetBytes(player.statMan.MaxHP));

            var tileBytes = ((byte[])(RPGTile)player.renderable.tiles[0, 0]).ToList();
            list.AddRange(tileBytes.GetRange(0, 2)); // Only store the first 2 bytes to not waste space.

            return list.ToArray();
        }
    }
}
