using NVCampaignEditor.Command.PrimaryCommands;
using NVCampaignEditor.Command.PrimaryCommands.DataManip.CFoe;
using NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem;

namespace NVCampaignEditor.Command
{
    internal class EntryCommand : CommandBase
    {
        public EntryCommand()
        {
            Subcommands = [
                new Help(),
                new Exit(),
                new Initialize(),
                new Load(),
                new Save(),
                new FoeBase(),
                new ItemBase()];
        }

        protected override void Process(string[] argArray)
        {
            throw new ArgumentException("Invalid command.");
        }
    }
}
