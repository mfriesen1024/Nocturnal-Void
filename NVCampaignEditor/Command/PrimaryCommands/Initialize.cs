using Nocturnal_Void.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVCampaignEditor.Command.PrimaryCommands
{
    /// <summary>
    /// Initializes the loader
    /// </summary>
    internal class Initialize : CommandBase
    {
        protected override void Process(string[] argArray)
        {
            FileManager.Init();
        }
    }
}
