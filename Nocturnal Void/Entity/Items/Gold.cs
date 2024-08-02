namespace Nocturnal_Void.Entity.Items
{
    internal class Gold : Item
    {
        public int value = 1;
        public override Item Clone()
        {
            return (Item)MemberwiseClone();
        }

        public static explicit operator Gold(byte[] data)
        {
            int value = BitConverter.ToInt32(data, 0);
            return new Gold() { value = value };
        }

        public static explicit operator byte[](Gold item)
        {
            return BitConverter.GetBytes(item.value);
        }
    }
}
