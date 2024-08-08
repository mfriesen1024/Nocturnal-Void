using Nocturnal_Void.Entity.Movable;
using Nocturnal_Void.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip.CFoe
{
    internal class List : CommandBase
    {
        public List()
        {
            Aliases = ["list", "l"];
        }

        protected override void Process(string[] argArray)
        {
            Foe[] foes = FileManager.EntityLoader.Foes;
            foreach (Foe foe in foes)
            {
                Console.WriteLine($"{foe.name} hp: {foe.statMan.MaxHP}, def: {foe.def}, str: {foe.str}");
            }
        }
    }
}
