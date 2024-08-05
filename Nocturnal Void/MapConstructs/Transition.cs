namespace Nocturnal_Void.MapConstructs
{
    /// <summary>
    /// Represents a map transition trigger
    /// </summary>
    public class Transition
    {
        private int yMax;
        private int xMin;
        private int xMax;
        private int yMin;
        public int XMin { get => xMin; protected set => xMin = value; }
        public int XMax { get => xMax; protected set => xMax = value; }
        public int YMin { get => yMin; protected set => yMin = value; }
        public int YMax { get => yMax; protected set => yMax = value; }

        public Transition(int xMin, int xMax, int yMin, int yMax)
        {
            this.xMin = xMin;
            this.xMax = xMax;
            this.yMin = yMin;
            this.yMax = yMax;
        }
        protected Transition()
        {
            // Empty constructor for use in operator.
        }

        /// <summary>
        /// Check if a given coordinate pair is within the bounds of the trigger.
        /// </summary>
        /// <returns>true if the coordinates are within the trigger, otherwise false.</returns>
        public bool CheckPos(int x, int y)
        {
            return x <= xMin && y <= yMin && x >= xMax && y >= yMax;
        }

        /// <summary>
        /// Converts a 16 byte array into a transition.
        /// </summary>
        /// <param name="bytes">A 16 byte array to be converted.</param>
        public static explicit operator Transition(byte[] bytes)
        {
            if (bytes.Length < 16) { throw new InvalidCastException($"Invalid array size. Size was {bytes.Length}, must be 16 or greater."); }
            Transition transition = new Transition();
            transition.xMin = BitConverter.ToInt32(bytes, 0);
            transition.xMax = BitConverter.ToInt32(bytes, 4);
            transition.yMin = BitConverter.ToInt32(bytes, 8);
            transition.yMax = BitConverter.ToInt32(bytes, 12);
            return transition;
        }
    }
}
