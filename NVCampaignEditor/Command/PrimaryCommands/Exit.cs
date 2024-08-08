namespace NVCampaignEditor.Command.PrimaryCommands
{
    /// <summary>
    /// Close the editor.
    /// </summary>
    internal class Exit : CommandBase
    {
        public Exit()
        {
            Aliases = ["exit"];
        }

        protected override void Process(string[] argArray)
        {
            Environment.Exit(0);
        }
    }
}
