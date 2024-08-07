namespace NVCampaignEditor.Util
{
    public static class StringUtils
    {
        /// <summary>
        /// Parse a given string into an array of values, based on the given separator. Originally intended to parse a command and arguments.
        /// </summary>
        /// <param name="command">The string/command to be parsed</param>
        /// <param name="separator">The character separating the values.</param>
        /// <returns>An array containing the values from the string.</returns>
        public static string[] ParseArgs(string command, char separator = ' ')
        {
            List<string> args = new List<string>();

            // index of space character
            int i = command.IndexOf(separator);
            // index of last space character. Start at -1 because we didnt have anything before, and o + 1 will return 0, the first item.
            int o = -1;

            do
            {
                // o + 1 gets the index of the character after the last space.
                // i - (o + 1) gets the length of the substring because o + 1 is the first index, so subtracting it from next space index
                // gives us length, and the + 1 now accounts for the space character.
                if (i > 0) { args.Add(command.Substring(o + 1, i - (o + 1))); }
                else { args.Add(command); return args.ToArray(); } // This catches if the first search fails.
                o = i; i = command.IndexOf(' ', o + 1); // Update indices
            } while (i > 0);

            // That won't pickup the last one though, so we should add the last string.
            // I feel like theres a better way to do this though.
            args.Add(command.Substring(o + 1));

            return args.ToArray();
        }

        /// <summary>
        /// Convert a character representing a hexidecimal number to an integer.
        /// </summary>
        /// <param name="c">The character to be parsed. Must be 0-f</param>
        /// <returns>An integer from 0-15 based on the character input.</returns>
        /// <exception cref="FormatException">Thrown if the character isn't hexidecimal.</exception>
        public static int HexParse(char c)
        {
            // Try to return it as an int, its less code for me.
            try { return int.Parse(c.ToString()); }
            catch
            {
                switch (c)
                {
                    case 'a': return 10;
                    case 'b': return 11;
                    case 'c': return 12;
                    case 'd': return 13;
                    case 'e': return 14;
                    case 'f': return 15;
                    default: throw new FormatException($"Hex parse failed, character was {c}, which was deemed invalid.");
                }
            }
        }
    }
}
