﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip
{
    internal class ItemCmd : CommandBase
    {
        public ItemCmd()
        {
            Aliases = ["item"];
        }

        protected override void Process(string[] argArray)
        {
            throw new NotImplementedException();
        }
    }
}