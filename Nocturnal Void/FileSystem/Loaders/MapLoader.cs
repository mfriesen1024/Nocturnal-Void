using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal_Void.FileSystem.Util;
using CFile = Nocturnal_Void.FileSystem.Util.File;

namespace Nocturnal_Void.FileSystem.Loaders
{
    /// <summary>
    /// A loader that constructs/stores/saves maps.
    /// </summary>
    internal class MapLoader : LoaderBase
    {
        public MapLoader(string fName) : base(fName)
        {
        }

        public override void Load(CFile path)
        {
            throw new NotImplementedException();
        }

        public override void Save(CFile path)
        {
            throw new NotImplementedException();
        }
    }
}
