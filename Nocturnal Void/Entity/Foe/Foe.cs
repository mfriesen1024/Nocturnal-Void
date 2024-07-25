using Nocturnal_Void.Managers;
using TZPRenderers.Text;

namespace Nocturnal_Void.Entity.Foe
{
    /// <summary>
    /// Represents an opponent.
    /// </summary>
    internal class Foe
    {
        public string name;

        public StatManager statMan { get; protected set; }

        public int def { get; protected set; }
        public int str { get; protected set; }

        public RelativeRenderable renderable { get; protected set; }

        public Hitbox hitbox { get; protected set; }
    }
}
