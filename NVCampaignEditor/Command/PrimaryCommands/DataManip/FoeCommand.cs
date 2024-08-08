using NVCampaignEditor.Command.PrimaryCommands.DataManip.FoeCmd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip
{
    internal class FoeCommand : CommandBase
    {
        public FoeCommand()
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
