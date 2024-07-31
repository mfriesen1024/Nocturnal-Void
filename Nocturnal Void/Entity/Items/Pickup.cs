using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TZPRenderers.Text;

namespace Nocturnal_Void.Entity.Items
{
    /// <summary>
    /// Represents an item placed on the map.
    /// </summary>
    internal class Pickup
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
    }
}
