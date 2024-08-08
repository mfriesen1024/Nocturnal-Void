using Nocturnal_Void.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip.CFoe
{
    internal class Replace : CommandBase
    {
        public Replace()
        {
            Aliases = ["replace", "r"];
        }

        protected override void Process(string[] argArray)
        {
            int index = int.Parse(argArray[0]);

            // I'm not doing argument management. Nope, not again.
            var foes = FileManager.EntityLoader.Foes.ToList();
            foes.RemoveAt(index);
            foes.Insert(index, Create.AskPlayer());
            FileManager.EntityLoader.SetFoes(foes.ToArray());
        }
    }
}
