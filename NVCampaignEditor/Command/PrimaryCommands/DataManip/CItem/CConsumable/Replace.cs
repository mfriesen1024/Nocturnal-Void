using Nocturnal_Void.Entity.Items;
using Nocturnal_Void.FileSystem;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem.CConsumable
{
    internal class Replace : CommandBase
    {
        public Replace()
        {
            Aliases = ["replace", "r"];
        }

        protected override void Process(string[] argArray)
        {
            var objs = FileManager.ItemLoader.Consumables.ToList();
            objs.RemoveAt(int.Parse(argArray[0]));
            if (argArray.Length < 3) { objs.Add(new Consumable((Consumable.ConsumableType)int.Parse(argArray[1]), int.Parse(argArray[2]))); }
            else
            {
                objs.Add(Create.AskUser());
            }
            FileManager.ItemLoader.SetConsumables(objs.ToArray());
        }
    }
}
