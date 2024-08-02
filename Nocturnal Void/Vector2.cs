namespace Nocturnal_Void
{
    public struct Vector2
    {
        public int x, y;

        public static Vector2 Zero { get { return new Vector2() { x = 0, y = 0 }; } }

        public static explicit operator Vector2(byte[] bytes)
        {
            if (bytes.Length != 8) throw new ArgumentException($"Byte array must be of length 8. It was {bytes.Length}");

            int x = BitConverter.ToInt32(bytes, 0);
            int y = BitConverter.ToInt32(bytes, 4);

            return new Vector2() { x = x, y = y };
        }

        public static explicit operator byte[](Vector2 vector)
        {
            List<byte> list = new List<byte>();
            list.AddRange(BitConverter.GetBytes(vector.x));
            list.AddRange(BitConverter.GetBytes(vector.y));
            return list.ToArray();
        }
    }
}
