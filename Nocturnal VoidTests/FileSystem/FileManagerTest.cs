namespace Nocturnal_Void.FileSystem.Tests
{
    [TestClass()]
    public class FileManagerTest
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