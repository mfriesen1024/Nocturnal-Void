using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nocturnal_Void
{
    internal struct Vector2
    {
        public int x, y;

        public static explicit operator Vector2(byte[] bytes)
        {
            if (bytes.Length != 8) throw new ArgumentException($"Byte array must be of length 8. It was {bytes.Length}");

            int x = BitConverter.ToInt32(bytes, 0);
            int y = BitConverter.ToInt32(bytes, 4);

            return new Vector2() { x = x, y = y };
        }
    }
}
