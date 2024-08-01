using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nocturnal_Void.Entity.Items
{
    internal class Gold : Item
    {
        public int value = 1;
        public override Item Clone()
        {
            return (Item)MemberwiseClone();
        }
    }
}
