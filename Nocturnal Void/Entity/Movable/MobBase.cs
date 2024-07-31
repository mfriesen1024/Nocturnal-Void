using Nocturnal_Void.Managers;
using TZPRenderers.Text;

namespace Nocturnal_Void.Entity.Movable
{
    /// <summary>
    /// Represents a mob(ile) entity.
    /// </summary>
    internal abstract class MobBase
    {
        // For now, we're only going to use 1 tile for hitboxes and rendering.
        public string name;

        public StatManager statMan { get; protected set; }

        public int def { get; protected set; }
        public int str { get; protected set; }

        public Vector2 location { get; protected set; } = Vector2.Zero;

        public RelativeRenderable renderable { get; protected set; }
        public abstract void Update();
        public abstract MobBase Clone();
    }
}
