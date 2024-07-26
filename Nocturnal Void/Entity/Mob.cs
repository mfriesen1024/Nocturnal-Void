using Nocturnal_Void.Managers;
using TZPRenderers.Text;

namespace Nocturnal_Void.Entity
{
    /// <summary>
    /// Represents a mob(ile) entity.
    /// </summary>
    internal abstract class Mob
    {
        public string name;

        public StatManager statMan { get; protected set; }

        public int def { get; protected set; }
        public int str { get; protected set; }

        public RelativeRenderable renderable { get; protected set; }

        public Hitbox hitbox { get; protected set; }
        public abstract void Update();
    }
}
