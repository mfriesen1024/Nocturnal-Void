namespace Nocturnal_Void.Entity.Items
{
    /// <summary>
    /// Represents an item.
    /// </summary>
    public abstract class Item
    {

        /// <summary>
        /// Deep clone method.
        /// </summary>
        /// <returns>A deep clone of the object.</returns>
        public abstract Item Clone();

        // Items dont need to update.
    }
}
