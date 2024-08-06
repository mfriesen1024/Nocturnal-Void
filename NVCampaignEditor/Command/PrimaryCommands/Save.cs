using Nocturnal_Void.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVCampaignEditor.Command.PrimaryCommands
{
    /// <summary>
    /// Save all data.
    /// </summary>
    internal class Save : CommandBase
    {
        public Save()
        {
            Aliases = ["save"];
        }

        protected override void Process(string[] argArray)
        {
            // Save using the first argument.
            FileManager.Save(argArray[0]);
        }
    }
}
