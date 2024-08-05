namespace Nocturnal_Void.Entity
{
    /// <summary>
    /// Defines a range where an attack will hit as a t/f value.
    /// </summary>
    public class Hitbox
    {
        // I'm aware that this can be shortened to be a bool array, but i couldnt get a converter working, so this is 8x fatter than it needs to be.
        private static int bytesNeeded = 8;
        public byte[,] coordMap { get; protected set; }

        public static explicit operator Hitbox(byte[] bytes)
        {
            // Create bounds from first 8 bytes.
            int xBounds = BitConverter.ToInt32(bytes, 0);
            int yBounds = BitConverter.ToInt32(bytes, 4);

            byte[,] coordMap = new byte[xBounds, yBounds];

            // Convert to 2d array.
            for (int y = 0; y < yBounds; y++)
            {
                for (int x = 0; x < xBounds; x++)
                {
                    int primaryIndex = y * yBounds + x + bytesNeeded;

                    coordMap[y, x] = bytes[primaryIndex];
                }
            }

            return new Hitbox() { coordMap = coordMap };
        }

        public static explicit operator byte[](Hitbox box)
        {
            // Get size first.
            List<byte> list =
            [
                // Add x bounds, then y bounds.
                .. BitConverter.GetBytes(box.coordMap.GetLength(1)),
                .. BitConverter.GetBytes(box.coordMap.GetLength(0)),
            ];

            // Add individual bytes.
            for (int y = 0; y < box.coordMap.GetLength(0); y++)
            {
                for (int x = 0; x < box.coordMap.GetLength(1); x++)
                {
                    list.Add(box.coordMap[y, x]);
                }
            }

            return list.ToArray();
        }
    }
}
