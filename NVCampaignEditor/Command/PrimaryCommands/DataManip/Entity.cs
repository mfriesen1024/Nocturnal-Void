using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip
{
    internal class Entity : CommandBase
    {
        public Entity()
        {
            Aliases = ["entity"];
        }

        protected override void Process(string[] argArray)
        {
            throw new NotImplementedException();
        }
    }
}
