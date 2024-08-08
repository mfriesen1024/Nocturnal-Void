namespace NVCampaignEditor.Command
{
    internal class Help : CommandBase
    {
        public Help()
        {
            Aliases = ["help"];
        }

        protected override void Process(string[] argArray)
        {
            string helpMsg = "" +
                "Load: Loads all data from the path specified\n" +
                "Usage: load <path>\n\n" +
                "Save: Saves all data to the path specified\n" +
                "Usage: save <path>\n\n" +
                "Init: Generates new data so things dont break when loads/saves/updates are called.\n" +
                "Usage: init\n\n" +
                "Exit: Exits the editor.\n" +
                "Usage: exit\n\n" +
                "Help: Displays this message.\n" +
                "Usage: help\n\n";

            Console.WriteLine(helpMsg);
        }
    }
}
