using Nocturnal_Void.Entity.Movable;
using File = Nocturnal_Void.FileSystem.Util.File;

namespace Nocturnal_Void.FileSystem.Loaders
{
    /// <summary>
    /// A loader that constructs stores and saves entities.
    /// </summary>
    public class EntityLoader : LoaderBase
    {
        Player player;
        Foe[] foes;
        // NPC[] npcs;
        public Player Player { get => player; }
        public Foe[] Foes { get => foes; }
        // public NPC[] NPCs {get=>npcs;}


        public EntityLoader(string fName) : base(fName)
        {
        }

        public override void Load(File path)
        {
            File dataFile = new File(path, fName);
            var data = dataFile.ReadBytes().ToList();

            // There should only ever be 1 player, so just read them without defining bounds.
            // We know that the converter will just ignore excess bytes, so don't bother cropping array.
            player = (Player)data.ToArray();

            // Start/End for foes. Add player's required bytes as bounds.
            int fStart = BitConverter.ToInt32(data.ToArray(), Player.reqBytes);
            int fEnd = BitConverter.ToInt32(data.ToArray(), 4 + Player.reqBytes);

            List<Foe> foes = new List<Foe>();
            // Custom for loop to account for variable length objects.
            int nextStartIndex = fStart;
            while (nextStartIndex < fEnd)
            {
                // Converter ignores excess data, so just feed it the entire list, figure out how much data it actually used, and pass it on.
                Foe foe = (Foe)data.GetRange(nextStartIndex, data.Count - nextStartIndex).ToArray();
                foes.Add(foe);
                nextStartIndex += ((byte[])foe).Length;
            }
            this.foes = foes.ToArray();


            Console.WriteLine("Entities Loaded");
        }

        public override void Save(File path)
        {
            File dataFile = new File(path, fName);
            var data = new List<byte>();


            // Player is first, no bounds as stated in Load().
            data.AddRange((byte[])player);


            // Add foe data.
            var foeData = new List<byte>();
            foreach (Foe foe in foes)
            {
                foeData.AddRange((byte[])foe);
            }
            // Get the start/end indices.
            data.AddRange(BitConverter.GetBytes(Player.reqBytes + 8));
            data.AddRange(BitConverter.GetBytes(Player.reqBytes + 7 + foeData.Count));

            // Add foe data
            data.AddRange(foeData);


            // Now save all data to file.
            dataFile.WriteBytes(data.ToArray());

            Console.WriteLine("Entities saved.");
        }

        /// <summary>
        /// Setter method. Should only be used by the editor.
        /// </summary>
        public void SetPlayer(Player player) => this.player = player;
        /// <summary>
        /// Setter method. Should only be used by the editor.
        /// </summary>
        public void SetFoes(Foe[] foes) => this.foes = foes;
    }
}
