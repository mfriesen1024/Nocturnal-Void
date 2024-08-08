using Nocturnal_Void.Entity.Items;
using Nocturnal_Void.FileSystem;

namespace NVCampaignEditor.Command.PrimaryCommands.DataManip.CItem
{
    internal class ListAll : CommandBase
    {
        public ListAll()
        {
            Aliases = ["list"];
        }

        protected override void Process(string[] argArray)
        {
            foreach (Item item in FileManager.ItemLoader.AllItems)
            {
                // probably better to find a way to switch case, but idk how to make this work.
                if (item is Gold) { Gold g = item as Gold; Console.WriteLine($"Type: {item.GetType()},  Value:{g.value}"); }
                if (item is Consumable)
                {
                    Consumable c = item as Consumable; Console.WriteLine($"Type: {item.GetType()}, Consumable type:" +
                    $"{c.type}, Value: {c.value}");
                }
                if (item is Equipment)
                {
                    Equipment e = item as Equipment; Console.WriteLine($"Type: {item.GetType()}, Equipment Type:" +
                    $"{e.type}, Value: {e.value}");
                }
            }
        }
    }
}
