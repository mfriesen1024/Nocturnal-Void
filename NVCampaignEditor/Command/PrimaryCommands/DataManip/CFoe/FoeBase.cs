namespace NVCampaignEditor.Command.PrimaryCommands.DataManip.CFoe
{
    internal class FoeBase : CommandBase
    {
        public FoeBase()
        {
            Aliases = ["foe", "foes"];
            Subcommands = [new Create(), new Delete(), new List(), new Replace()];
        }

        protected override void Process(string[] argArray)
        {
            throw new ArgumentException("Invalid command.");
        }
    }
}
