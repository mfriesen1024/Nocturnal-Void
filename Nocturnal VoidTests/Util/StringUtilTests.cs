using Microsoft.VisualStudio.TestTools.UnitTesting;
using NVCampaignEditor.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVCampaignEditor.Util.Tests
{
    [TestClass()]
    public class StringUtilTests
    {
        [TestMethod()]
        public void ParseArgsTest()
        {

            string[] strings = StringUtils.ParseArgs("you boring. also more words.");
            foreach (string s in strings)
            {
                Console.WriteLine(s);
                Debug.Write(s);
            }
            string[] compare = ["you", "boring.", "also", "more", "words."];
            for (int i = 0; i < compare.Length; i++)
            {
                Assert.IsTrue(strings[i].Equals(compare[i]));
            }
        }

        [TestMethod()]
        public void HexParseTest()
        {
            Assert.Fail();
        }
    }
}