using Nocturnal_Void.Managers;
using TZPRenderers.Text;

namespace Nocturnal_Void.Entity
{
    /// <summary>
    /// Represents a mob(ile) entity.
    /// </summary>
    internal abstract class Mob
    {
        // For now, we're only going to use 1 tile for hitboxes and rendering.
        public string name;

        public StatManager statMan { get; protected set; }

        public int def { get; protected set; }
        public int str { get; protected set; }

        public Vector2 location { get; protected set; }

        public RelativeRenderable renderable { get; protected set; }
        public abstract void Update();
        public abstract void Clone();
    }
}
