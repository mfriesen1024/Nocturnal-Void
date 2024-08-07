using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip
{
    internal class EntityCmd : CommandBase
    {
        public EntityCmd()
        {
            Aliases = ["entity"];
        }

        protected override void Process(string[] argArray)
        {
            
        }
    }
}
