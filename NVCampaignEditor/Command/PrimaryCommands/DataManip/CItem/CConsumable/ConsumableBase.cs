namespace NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem.CConsumable
{
    internal class ConsumableBase : CommandBase
    {
        public ConsumableBase()
        {
            Aliases = ["consumable", "c"];
            Subcommands = [new Replace(), new Create(), new Delete()];
        }

        protected override void Process(string[] argArray)
        {
            throw new ArgumentException("Invalid command.");
        }
    }
}
