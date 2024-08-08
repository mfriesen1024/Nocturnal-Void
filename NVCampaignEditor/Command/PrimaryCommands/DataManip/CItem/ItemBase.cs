using NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem.CConsumable;
using NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem.CEquip;
using NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem.CGold;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem
{
    internal class ItemBase : CommandBase
    {
        public ItemBase()
        {
            Aliases = ["item", "items", "i"];
            Subcommands = [new ConsumableBase(), new EquipmentBase(), new GoldBase(), new ListAll()];
        }

        protected override void Process(string[] argArray)
        {
            throw new NotImplementedException();
        }
    }
}
