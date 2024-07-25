using TZPRenderers.Text;

namespace Nocturnal_Void.MapConstructs
{
    /// <summary>
    /// Represents a renderable text character, its colours, and what (if any) hazards are present.
    /// </summary>
    public class RPGTile : Tile
    {
        public byte hazardID = 0;

        public RPGTile(char? character = null, ConsoleColor? fgColor = null, ConsoleColor? bgColor = null, byte hazardID = 0) : base(character, fgColor, bgColor)
        {
            this.hazardID = hazardID;
        }

        public RPGTile(string character, int fg, int bg, byte hazardID) : base(character, fg, bg)
        {
            this.hazardID = hazardID;
        }

        /// <summary>
        /// Convert from a tile to a 3 byte array representing that tile.
        /// </summary>
        /// <param name="tile">The tile to convert.</param>
        public static explicit operator byte[](RPGTile tile)
        {
            byte characterByte = 0;
            if (tile.character != null) { characterByte = (byte)tile.character; }

            // Combine colour into a single byte.
            byte colourByte = 0;
            if (tile.fgColor != null) { colourByte += (byte)((byte)tile.fgColor * 16); }
            if (tile.bgColor != null) { colourByte += (byte)tile.bgColor; }

            return [characterByte, colourByte, tile.hazardID];
        }

        /// <summary>
        /// Convert from a 3 byte array to a tile.
        /// </summary>
        /// <param name="bytes">A 3 byte array</param>
        public static explicit operator RPGTile(byte[] bytes)
        {
            char? character = (char)bytes[0];

            // Split the second byte in half turning it into 2 colours.
            int fgi, bgi;
            fgi = Math.DivRem(bytes[1], 16, out bgi);
            // assign vars for foreground/background.
            ConsoleColor? fgc, bgc;
            fgc = (ConsoleColor?)fgi; bgc = (ConsoleColor?)bgi;

            byte hazID = bytes[2];

            // If color was both 0, return nulls so we can render transparency.
            if (bytes[1] == 0) return new RPGTile(character, null, null, hazID);
            else return new RPGTile(character, fgc, bgc, hazID);
        }
    }
}
