using Nocturnal_Void.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip.FoeCmd
{
    internal class Delete : CommandBase
    {
        public Delete()
        {
            Aliases = ["delete", "del", "d"];
        }

        protected override void Process(string[] argArray)
        {
            int i = int.Parse(argArray[0]);

            var foes = FileManager.EntityLoader.Foes.ToList();
            foes.RemoveAt(i);
        }
    }
}
