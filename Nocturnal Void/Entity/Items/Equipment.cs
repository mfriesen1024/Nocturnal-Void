namespace Nocturnal_Void.Entity.Items
{
    public class Equipment : Item
    {
        public const int requiredBytes = 5;

        public Equipment()
        {
        }

        public Equipment(EquipType type, int value)
        {
            this.value = value;
            this.type = type;
        }

        public int value { get; protected set; }
        public EquipType type { get; protected set; }

        public override Item Clone()
        {
            return (Equipment)MemberwiseClone();
        }

        public static explicit operator Equipment(byte[] bytes)
        {
            byte type = bytes[0];
            int value = BitConverter.ToInt32(bytes, 1);
            return new Equipment() { type = (EquipType)type, value = value };
        }

        public static explicit operator byte[](Equipment item)
        {
            var list = new List<byte>();
            list.Add((byte)item.type);
            list.AddRange(BitConverter.GetBytes(item.value));
            return list.ToArray();
        }

        /// <summary>
        /// This should be used to determine what to do with an equipped item.
        /// </summary>
        public enum EquipType { str, def }
    }
}
