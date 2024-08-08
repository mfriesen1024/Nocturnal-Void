using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem.C;
using NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem.CGold;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem.CConsumable
{
    internal class ConsumableBase : CommandBase
    {
        public ConsumableBase()
        {
            Aliases = ["consumable", "c"];
            Subcommands = [new Replace(), new Create(), new Delete()];
        }

        protected override void Process(string[] argArray)
        {
            throw new ArgumentException("Invalid command.");
        }
    }
}
