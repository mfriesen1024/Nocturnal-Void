using Nocturnal_Void.MapConstructs;
using TZPRenderers.Text;

namespace Nocturnal_Void.Entity.Items
{
    /// <summary>
    /// Represents an item placed on the map.
    /// </summary>
    public class Pickup
    {
        public RelativeRenderable renderable { get; protected set; }
        public Item item { get; protected set; }
        public Vector2 position { get; protected set; } // Pickups are static in location, they shouldnt move.

        /// <summary>
        /// Deep clone method to forcibly get a completely new object.
        /// </summary>
        /// <returns>A fully cloned Pickup</returns>
        public Pickup Clone()
        {
            // Reconstruct renderable bc we dont have a clone method built in.
            RelativeRenderable old = renderable;
            RelativeRenderable newRenderable = new RelativeRenderable(old.tiles, old.location, old.layer);

            return new Pickup() { item = item.Clone(), position = position, renderable = newRenderable };
        }

        /// <summary>
        /// Creates a pickup from a byte array.
        /// </summary>
        /// <param name="bytes">A byte array containing the index, position and renderable for the new pickup.</param>
        public static explicit operator Pickup(byte[] bytes)
        {
            var list = bytes.ToList();

            int index = BitConverter.ToInt32(bytes, 0);
            // 5th to 12th bytes become x/y coordinate ints.
            Vector2 pos = (Vector2)bytes.ToList().GetRange(4, 8).ToArray();

            // Construct renderable.
            // Add 0 because we dont want to eat disc space for a value we never use.
            var tileBytes = list.GetRange(12, 2); tileBytes.Add(0);
            RPGTile[,] tileArray = new RPGTile[,] { { (RPGTile)tileBytes.ToArray() } };
            RelativeRenderable renderable = new RelativeRenderable(tileArray);

            // TODO: Add item index fetching. Use a null value for now.
            Item item = null;

            return new Pickup() { item = item, position = pos, renderable = renderable };
        }
    }
}
