using NVCampaignEditor.Command.PrimaryCommands;

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
                new Save()];
        }

        protected override void Process(string[] argArray)
        {
            throw new ArgumentException("Invalid command.");
        }
    }
}
