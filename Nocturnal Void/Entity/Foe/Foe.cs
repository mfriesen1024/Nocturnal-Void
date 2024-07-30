using Nocturnal_Void.Managers;
using Nocturnal_Void.MapConstructs;
using TZPRenderers.Text;

namespace Nocturnal_Void.Entity.Foe
{
    /// <summary>
    /// Represents an opponent.
    /// </summary>
    internal class Foe : Mob
    {
        public override void Clone()
        {
            throw new NotImplementedException();
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
        }
    }
}
