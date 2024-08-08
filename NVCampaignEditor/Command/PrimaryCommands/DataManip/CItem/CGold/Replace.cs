using Nocturnal_Void.Entity.Items;
using Nocturnal_Void.FileSystem;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem.CGold
{
    internal class Replace : CommandBase
    {
        public Replace()
        {
            Aliases = ["replace", "r"];
        }

        protected override void Process(string[] argArray)
        {
            var objs = FileManager.ItemLoader.GoldItems.ToList();
            objs.RemoveAt(int.Parse(argArray[0]));
            if (argArray.Length < 2) { objs.Add(new Gold(int.Parse(argArray[1]))); }
            else
            {
                Console.WriteLine("Enter a value for the object.");
                objs.Add(new Gold(int.Parse(Console.ReadLine())));
            }
            FileManager.ItemLoader.SetGold(objs.ToArray());
        }
    }
}
