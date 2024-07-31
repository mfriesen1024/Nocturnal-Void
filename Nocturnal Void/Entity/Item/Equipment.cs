namespace Nocturnal_Void.Entity.Item
{
    internal class Equipment : Item
    {
        public int value { get; protected set; }
        public EquipType type { get; protected set; }

        public override Item Clone()
        {
            return (Equipment)MemberwiseClone();
        }

        /// <summary>
        /// This should be used to determine what to do with an equipped item.
        /// </summary>
        public enum EquipType { str, def }
    }
}
