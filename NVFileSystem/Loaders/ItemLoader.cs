using Nocturnal_Void.Entity.Items;
using File = NVFileSystem.Util.File;

namespace NVFileSystem.Loaders
{
    public class ItemLoader
    {
        string fName = "items.bin";
        Consumable[] consumables;
        Equipment[] equip;
        Gold[] gold;
        Item[] allItems;
        Pickup[] pickups;

        public void Load(File path)
        {
            File items = new File(path, fName);

            var data = items.ReadBytes().ToList();
            var itemList = allItems.ToList();

            // Use the first 8 bytes to define a range for consumables.
            int cStart = BitConverter.ToInt32(data.ToArray(), 0);
            int cEnd = BitConverter.ToInt32(data.ToArray(), 4);

            // Get consumables.
            var consumables = this.consumables.ToList();
            for (int i = cStart; i < cEnd; i += 5)
            {
                // get the required bytes, and cast the byte array.
                consumables.Add((Consumable)data.GetRange(i, 5).ToArray());
            }
            this.consumables = consumables.ToArray();
            itemList.AddRange(consumables);

            // Next 8 bytes should define a range for equip.
            int eStart = BitConverter.ToInt32(data.ToArray(), cEnd + 1);
            int eEnd = BitConverter.ToInt32(data.ToArray(), cEnd + 5);

            // Get equip.
            var equip = this.equip.ToList();
            for (int i = eStart; i < eEnd; i += 5)
            {
                // get the required bytes, and cast the byte array.
                equip.Add((Equipment)data.GetRange(i, 5).ToArray());
            }
            this.equip = equip.ToArray();
            itemList.AddRange(equip);

            // Now define gold.
            int gStart = BitConverter.ToInt32(data.ToArray(),eEnd + 1);
            int gEnd = BitConverter.ToInt32(data.ToArray(), eEnd + 5);

            // Get gold.
            var gold = this.gold.ToList();
            for (int i = gStart; i < gEnd; i += 4)
            {
                gold.Add((Gold)data.GetRange(i, 4).ToArray());
            }
            this.gold = gold.ToArray();
            itemList.AddRange(gold);

            // Set the array so pickup can reference it.
            allItems = itemList.ToArray();  

            // Define range for pickups.
            int pStart = BitConverter.ToInt32(data.ToArray(),gEnd + 1);
            int pEnd = BitConverter.ToInt32(data.ToArray(), gEnd + 5);

            for (int i = pStart; i < pEnd; i += 14)
            {

            }
        }
    }
}
