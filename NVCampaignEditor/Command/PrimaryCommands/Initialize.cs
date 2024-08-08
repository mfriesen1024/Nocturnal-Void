using Nocturnal_Void.FileSystem;

namespace NVCampaignEditor.Command.PrimaryCommands
{
    /// <summary>
    /// Initializes the loader
    /// </summary>
    internal class Initialize : CommandBase
    {
        public Initialize()
        {
            Aliases = ["initialize", "init"];
        }

        protected override void Process(string[] argArray)
        {
            FileManager.Init();
        }
    }
}
