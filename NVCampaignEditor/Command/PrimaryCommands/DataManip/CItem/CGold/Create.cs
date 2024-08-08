using Nocturnal_Void.Entity.Items;
using Nocturnal_Void.FileSystem;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem.CGold
{
    internal class Create : CommandBase
    {
        public Create()
        {
            Aliases = ["create", "c"];
        }

        protected override void Process(string[] argArray)
        {
            var objs = FileManager.ItemLoader.GoldItems.ToList();

            // Its quite simple, just take value as argument.
            objs.Add(new Gold(int.Parse(argArray[0])));

            FileManager.ItemLoader.SetGold(objs.ToArray());
        }
    }
}
