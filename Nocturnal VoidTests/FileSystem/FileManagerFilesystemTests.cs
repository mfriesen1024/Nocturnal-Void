using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nocturnal_Void.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nocturnal_Void.FileSystem.Tests
{
    [TestClass()]
    public class FileManagerTests
    {
        [TestMethod()]
        public void LoadTest()
        {
            FileManager.Load("TestFolder");
        }

        [TestMethod()]
        public void SaveTest()
        {
            FileManager.Save("TestFolder");
        }
    }
}