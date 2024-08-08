using Nocturnal_Void.Entity.Items;
using Nocturnal_Void.FileSystem;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem.CEquip
{
    internal class Create : CommandBase
    {
        public Create()
        {
            Aliases = ["create", "c"];
        }

        protected override void Process(string[] argArray)
        {
            var objs = FileManager.ItemLoader.Equip.ToList();

            if (argArray.Length < 2) { objs.Add(AskUser()); }
            else { objs.Add(new Equipment((Equipment.EquipType)int.Parse(argArray[0]), int.Parse(argArray[1]))); }

            FileManager.ItemLoader.SetEquip(objs.ToArray());
        }

        public static Equipment AskUser()
        {
            Console.WriteLine($"Currently only heal type is supported. Please enter \"0\"");
            int typeInt = int.Parse(Console.ReadLine());
            Console.WriteLine($"Enter the value for the item.");
            int value = int.Parse(Console.ReadLine());
            return new Equipment((Equipment.EquipType)typeInt, value);
        }
    }
}
