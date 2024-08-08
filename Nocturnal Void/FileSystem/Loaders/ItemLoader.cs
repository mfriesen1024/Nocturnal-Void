using Nocturnal_Void.Entity.Items;
using File = Nocturnal_Void.FileSystem.Util.File;

namespace Nocturnal_Void.FileSystem.Loaders
{
    /// <summary>
    /// A loader that constructs and stores items.
    /// </summary>
    public class ItemLoader : LoaderBase
    {
        Consumable[] consumables;
        Equipment[] equip;
        Gold[] goldItems;
        Pickup[] pickups;
        Item[] allItems;

        public Consumable[] Consumables { get => consumables; }
        public Equipment[] Equip { get => equip; }
        public Gold[] GoldItems { get => goldItems; }
        public Pickup[] Pickups { get => pickups; }
        public Item[] AllItems { get => allItems; }

        public ItemLoader(string fName) : base(fName)
        {
        }

        public override void Load(File path)
        {
            File dataFile = new File(path, fName);

            var data = dataFile.ReadBytes().ToList();

            // Track the required bytes for a conversion.
            int reqBytes;

            // Use the first 8 bytes to define a range for consumables.
            int cStart = BitConverter.ToInt32(data.ToArray(), 0);
            int cEnd = BitConverter.ToInt32(data.ToArray(), 4);

            // Get consumables.
            reqBytes = Consumable.requiredBytes;
            var consumables = new List<Consumable>();
            for (int i = cStart; i < cEnd; i += reqBytes)
            {
                // get the required bytes, and cast the byte array.
                consumables.Add((Consumable)data.GetRange(i, reqBytes).ToArray());
            }
            this.consumables = consumables.ToArray();

            // Next 8 bytes should define a range for equip.
            int eStart = BitConverter.ToInt32(data.ToArray(), cEnd + 1);
            int eEnd = BitConverter.ToInt32(data.ToArray(), cEnd + 5);

            // Get equip.
            reqBytes = Equipment.requiredBytes;
            var equip = new List<Equipment>();
            for (int i = eStart; i < eEnd; i += reqBytes)
            {
                // get the required bytes, and cast the byte array.
                equip.Add((Equipment)data.GetRange(i, reqBytes).ToArray());
            }
            this.equip = equip.ToArray();

            // Now define gold.
            int gStart = BitConverter.ToInt32(data.ToArray(), eEnd + 1);
            int gEnd = BitConverter.ToInt32(data.ToArray(), eEnd + 5);

            // Get gold.
            reqBytes = Gold.requiredBytes;
            var gold = new List<Gold>();
            for (int i = gStart; i < gEnd; i += 4)
            {
                gold.Add((Gold)data.GetRange(i, 4).ToArray());
            }
            goldItems = gold.ToArray();

            // Set the array so pickup can reference it.
            UpdateItemArray();

            // Define range for pickups.
            int pStart = BitConverter.ToInt32(data.ToArray(), gEnd + 1);
            int pEnd = BitConverter.ToInt32(data.ToArray(), gEnd + 5);

            var pickups = new List<Pickup>();
            reqBytes = Pickup.requiredBytes;
            for (int i = pStart; i < pEnd; i += 14)
            {
                pickups.Add((Pickup)data.GetRange(i, 14).ToArray());
            }
            Console.WriteLine("Loaded items.");
        }

        public override void Save(File path)
        {
            File dataFile = new File(path, fName);

            var bytes = new List<byte>();

            /* 
             * Whats with the magic numbers?:
             * 
             * 7 and -1: the index of our start index was inclusive, so our end index should be too. Subtract 1 from start, then add length.
             * 8: start index must be the 9th byte or index 8, because we save start/end locations as 4 byte arrays, from ints.
             * 9: our next start index needs to be offset by 9, because start/end indices should be the inclusive range of the data,
             * but not include the index metadata. Therefore, add 8 for our metadata, add 1 to find the next start index.
            */

            // Start/End Indices
            int cStart = 8;
            int cEnd = 7 + consumables.Length * Consumable.requiredBytes;
            bytes.AddRange(BitConverter.GetBytes(cStart));
            bytes.AddRange(BitConverter.GetBytes(cEnd));

            foreach (Consumable consumable in consumables) { bytes.AddRange((byte[])consumable); }

            // Start/End for Equip
            int eStart = cEnd + 9;
            int eEnd = eStart - 1 + equip.Length * Equipment.requiredBytes;
            bytes.AddRange(BitConverter.GetBytes(eStart));
            bytes.AddRange(BitConverter.GetBytes(eEnd));

            foreach (Equipment equipment in equip) { bytes.AddRange((byte[])equipment); }

            // Gold
            int gStart = eEnd + 9;
            int gEnd = gStart - 1 + goldItems.Length * Gold.requiredBytes;
            bytes.AddRange(BitConverter.GetBytes(gStart));
            bytes.AddRange(BitConverter.GetBytes(gEnd));

            foreach (Gold gItem in goldItems) { bytes.AddRange((byte[])gItem); }

            // Pickups
            int pStart = gEnd + 9;
            int pEnd = pStart - 1 + pickups.Length * Pickup.requiredBytes;
            bytes.AddRange(BitConverter.GetBytes(pStart));
            bytes.AddRange(BitConverter.GetBytes(pEnd));

            foreach (Pickup pickup in pickups) { bytes.AddRange((byte[])pickup); }

            dataFile.WriteBytes(bytes.ToArray());

            Console.WriteLine("Items saved.");
        }

        /// <summary>
        /// Should be called when any array is changed.
        /// </summary>
        void UpdateItemArray()
        {
            List<Item> items = new List<Item>();
            items.AddRange(consumables);
            if (equip != null) { items.AddRange(equip); }
            if (goldItems != null) { items.AddRange(goldItems); }
            allItems = items.ToArray();
        }

        /// <summary>
        /// Setter method. Should only be used by the editor.
        /// </summary>
        public void SetConsumables(Consumable[] consumables)
        {
            this.consumables = consumables;
            UpdateItemArray();
        }

        /// <summary>
        /// Setter method. Should only be used by the editor.
        /// </summary>
        public void SetEquip(Equipment[] equip)
        {
            this.equip = equip;
            UpdateItemArray();
        }

        /// <summary>
        /// Setter method. Should only be used by the editor.
        /// </summary>
        public void SetGold(Gold[] gold)
        {
            goldItems = gold;
            UpdateItemArray();
        }

        /// <summary>
        /// Setter method. Should only be used by the editor.
        /// </summary>
        public void SetPickups(Pickup[] pickups) => this.pickups = pickups;
    }
}
