using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZPRenderers.Text;

namespace Nocturnal_Void.Entity.Item
{
    /// <summary>
    /// Represents an item.
    /// </summary>
    internal abstract class Item
    {
        public RelativeRenderable renderable {  get; protected set; }

        /// <summary>
        /// Deep clone method.
        /// </summary>
        /// <returns>A deep clone of the object.</returns>
        public abstract Item Clone();

        // Items dont need to update.
    }
}
