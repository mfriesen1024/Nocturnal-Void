namespace NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem.CGold
{
    internal class GoldBase : CommandBase
    {
        public GoldBase()
        {
            Aliases = ["gold"];
            Subcommands = [new Replace(), new Create(), new Delete()];
        }

        protected override void Process(string[] argArray)
        {
            throw new ArgumentException("Invalid command.");
        }
    }
}
