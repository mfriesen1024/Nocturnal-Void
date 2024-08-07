using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip
{
    internal class Map : CommandBase
    {
        public Map()
        {
            Aliases = ["map"];
        }

        protected override void Process(string[] argArray)
        {
            throw new NotImplementedException("Map commands are not implemented.");
        }
    }
}
