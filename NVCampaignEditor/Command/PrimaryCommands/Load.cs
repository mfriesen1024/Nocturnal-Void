using Nocturnal_Void.FileSystem;

namespace NVCampaignEditor.Command.PrimaryCommands
{
    /// <summary>
    /// Load data from files.
    /// </summary>
    internal class Load : CommandBase
    {
        public Load()
        {
            Aliases = ["load"];
        }

        protected override void Process(string[] argArray)
        {
            // Load using the first argument.
            FileManager.Load(argArray[0]);
        }
    }
}
