using NVCampaignEditor.Command.PrimaryCommands;
using NVCampaignEditor.Command.PrimaryCommands.DataManip;

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
                new FoeCommand()];
        }

        protected override void Process(string[] argArray)
        {
            throw new ArgumentException("Invalid command.");
        }
    }
}
