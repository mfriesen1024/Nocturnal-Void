namespace Nocturnal_Void.Entity.Items
{
    public class Consumable : Item
    {
        public ConsumableType type;
        public int value;

        public delegate void OnConsumeDelegate(int value);
        OnConsumeDelegate consumeDelegate;

        public override Item Clone()
        {
            return (Consumable)MemberwiseClone();
        }

        /// <summary>
        /// Set the delegate for 
        /// </summary>
        /// <param name="method">What should happen when the item is consumed?</param>
        public void SetDelegate(OnConsumeDelegate method)
        {
            consumeDelegate = method;
        }

        public static explicit operator Consumable(byte[] bytes)
        {
            byte type = bytes[0];
            int value = BitConverter.ToInt32(bytes, 1);
            return new Consumable() { type = (ConsumableType)type, value = value };
        }

        public static explicit operator byte[](Consumable item)
        {
            var list = new List<byte>();
            list.Add((byte)item.type);
            list.AddRange(BitConverter.GetBytes(item.value));
            return list.ToArray();
        }

        /// <summary>
        /// This should eventually be used to determine what to do with a consumable based on its type.
        /// </summary>
        public enum ConsumableType { heal }
    }
}
