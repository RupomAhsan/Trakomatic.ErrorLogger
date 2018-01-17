using ErrorLogger.BusinessLogic.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErrorLogger.UnitTests
{
    [TestClass]
    public class UnitTestsConfiguration
    {
        [TestMethod]
        public void ReadConfiguration()
        {
            var config = new ConfigurationHandler().Read();

            Assert.IsNotNull(config);
            Assert.IsNotNull(config.LoggingLevel);
        }

        [TestMethod]
        public void WriteConfiguration()
        {
            var config = new ConfigurationHandler().Read();
            
            var writer = new ConfigurationHandler().Write(config);

            Assert.IsTrue(writer);
        }
    }
}
