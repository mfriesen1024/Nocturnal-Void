using Nocturnal_Void.Entity.Items;
using File = Nocturnal_Void.FileSystem.Util.File;

namespace Nocturnal_Void.FileSystem.Loaders
{
    public class ItemLoader
    {
        string fName = "items.bin";
        Consumable[] consumables;
        Equipment[] equip;
        Gold[] goldItems;
        Item[] allItems;
        Pickup[] pickups;

        public Consumable[] Consumables { get => consumables; }
        public Equipment[] Equip { get => equip; }
        public Gold[] GoldItems { get => goldItems; }
        public Item[] AllItems { get => allItems; }
        public Pickup[] Pickups { get => pickups; }

        public void Load(File path)
        {
            File items = new File(path, fName);

            var data = items.ReadBytes().ToList();
            var itemList = allItems.ToList();

            // Track the required bytes for a conversion.
            int reqBytes;

            // Use the first 8 bytes to define a range for consumables.
            int cStart = BitConverter.ToInt32(data.ToArray(), 0);
            int cEnd = BitConverter.ToInt32(data.ToArray(), 4);

            // Get consumables.
            reqBytes = Consumable.requiredBytes;
            var consumables = this.consumables.ToList();
            for (int i = cStart; i < cEnd; i += reqBytes)
            {
                // get the required bytes, and cast the byte array.
                consumables.Add((Consumable)data.GetRange(i, reqBytes).ToArray());
            }
            this.consumables = consumables.ToArray();
            itemList.AddRange(consumables);

            // Next 8 bytes should define a range for equip.
            int eStart = BitConverter.ToInt32(data.ToArray(), cEnd + 1);
            int eEnd = BitConverter.ToInt32(data.ToArray(), cEnd + 5);

            // Get equip.
            reqBytes = Equipment.requiredBytes;
            var equip = this.equip.ToList();
            for (int i = eStart; i < eEnd; i += reqBytes)
            {
                // get the required bytes, and cast the byte array.
                equip.Add((Equipment)data.GetRange(i, reqBytes).ToArray());
            }
            this.equip = equip.ToArray();
            itemList.AddRange(equip);

            // Now define gold.
            int gStart = BitConverter.ToInt32(data.ToArray(), eEnd + 1);
            int gEnd = BitConverter.ToInt32(data.ToArray(), eEnd + 5);

            // Get gold.
            reqBytes = Gold.requiredBytes;
            var gold = goldItems.ToList();
            for (int i = gStart; i < gEnd; i += 4)
            {
                gold.Add((Gold)data.GetRange(i, 4).ToArray());
            }
            goldItems = gold.ToArray();
            itemList.AddRange(gold);

            // Set the array so pickup can reference it.
            allItems = itemList.ToArray();

            // Define range for pickups.
            int pStart = BitConverter.ToInt32(data.ToArray(), gEnd + 1);
            int pEnd = BitConverter.ToInt32(data.ToArray(), gEnd + 5);

            var pickups = this.pickups.ToList();
            reqBytes = Pickup.requiredBytes;
            for (int i = pStart; i < pEnd; i += 14)
            {
                pickups.Add((Pickup)data.GetRange(i, 14).ToArray());
            }
        }
    }
}
