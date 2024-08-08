﻿using Nocturnal_Void.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem.CGold
{
    internal class Delete : CommandBase
    {
        public Delete()
        {
            Aliases = ["delete", "del", "d"];
        }

        protected override void Process(string[] argArray)
        {
            var objs = FileManager.ItemLoader.GoldItems.ToList();
            objs.RemoveAt(int.Parse(argArray[0]));
            FileManager.ItemLoader.SetGold(objs.ToArray());
        }
    }
}