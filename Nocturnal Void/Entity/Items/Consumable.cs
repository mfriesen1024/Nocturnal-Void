using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nocturnal_Void.Entity.Items
{
    internal class Consumable : Item
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

        /// <summary>
        /// This should eventually be used to determine what to do with a consumable based on its type.
        /// </summary>
        public enum ConsumableType { heal}
    }
}
