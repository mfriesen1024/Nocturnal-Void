using Nocturnal_Void.Entity.Items;
using Nocturnal_Void.Managers;
using Nocturnal_Void.MapConstructs;
using TZPRenderers.Text;

namespace Nocturnal_Void.Entity.Movable
{
    public class Player : MobBase
    {
        public const int reqBytes = 14;
        public new const string name = "Player";        // Player's name should always be Player, so just make a constant.

        // Inventory things
        List<Item> inventory = new List<Item>();
        Equipment[] equipped = new Equipment[3];
        public int gold { get; protected set; } = 0;

        public Player(string name, StatManager statMan, int def, int str, Vector2 location, RelativeRenderable renderable) : base(name, statMan, def, str, location, renderable)
        {
        }

        public Player() : base() { }


        /// <summary>
        /// Adds an item to inventory. If the item is gold, add its value to gold var instead.
        /// </summary>
        /// <param name="item"></param>
        void AddItem(Item item)
        {
            if (item is not Gold) { inventory.Add(item); }
            else { gold += ((Gold)item).value; }
        }

        /// <summary>
        /// Equips an item, replacing anything currently in the slot. The item remains in the primary inventory list.
        /// This will silent fail if anything breaks.
        /// </summary>
        /// <param name="item">The item to be equipped.</param>
        /// <param name="slot">The equipment slot to use.</param>
        void EquipItem(Equipment item, int slot) { if (equipped.ToList().Contains(item)) { return; } try { equipped[slot] = item; } catch { } }

        void ConsumeItem(Consumable item)
        {
            switch (item.type)
            {
                case Consumable.ConsumableType.heal: statMan.Heal(item.value); break;
                default: Console.WriteLine(new NotImplementedException()); break;
            }
        }
        /// <summary>
        /// Removes an item from inventory and equipment list.
        /// </summary>
        /// <param name="item">The item to be removed.</param>
        void RemoveItem(Item item)
        {
            inventory.Remove(item);
            var equipment = equipped.ToList();
            if (equipment.Contains(item))
            {
                equipment.Remove((Equipment)item);
            }
            equipped = equipment.ToArray();
        }

        public override MobBase Clone()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a player object from a byte array.
        /// </summary>
        /// <param name="bytes">A byte array of length equal or greater than reqBytes</param>
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
