using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVCampaignEditor.Command
{
    internal class Help : CommandBase
    {
        public Help()
        {
            Aliases = ["help"];
        }

        protected override void Process(string[] argArray)
        {
            string helpMsg = "";

            Console.WriteLine(helpMsg);
        }
    }
}
