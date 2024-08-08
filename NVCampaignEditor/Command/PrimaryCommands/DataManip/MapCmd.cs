namespace NVCampaignEditor.Command.PrimaryCommands.DataManip
{
    internal class MapCmd : CommandBase
    {
        public MapCmd()
        {
            Aliases = ["map"];
        }

        protected override void Process(string[] argArray)
        {
            throw new NotImplementedException("Map commands are not implemented.");
        }
    }
}
