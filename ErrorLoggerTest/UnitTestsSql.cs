using ErrorLogger.BusinessLogic.Configuration;
using ErrorLogger.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ErrorLogger.UnitTests
{
    [TestClass]
    public class UnitTestsSql
    {
        private LoggerConfig _config;

        [TestInitialize]
        public void InitialiseTests()
        {
            _config = new ConfigurationHandler().Read();

            _config.LoggerType = LoggingTypeModel.LogOutputType.SQL;

            new ConfigurationHandler().Write(_config);

            if (_config.LoggerType != LoggingTypeModel.LogOutputType.SQL)
            {
                throw new Exception("Set the logger type to SQL in the Config file before running these tests.");
            }
        }

        [TestMethod]
        [Priority(1)]
        [Owner("AHSAN")]
        public void WriteSqlError()
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    throw new Exception("ErrorLogger", new Exception("This is my inner exception"));
                }
                catch (Exception exception)
                {
                    Logger.LogError(LoggingTypeModel.LogCategory.Process, exception);
                }
            }
        }

        [TestMethod]
        [Priority(1)]
        [Owner("AHSAN")]
        public void Read_MaxRecordCount()
        {
            const int recordsToRead = 10;

            var result = Logger.Read(recordsToRead);

            Assert.AreEqual(recordsToRead, result);
        }

        [TestMethod]
        [Priority(1)]
        [Owner("AHSAN")]
        public void Read_ReadBetweenDates()
        {
            
        }

        [TestMethod]
        [Priority(1)]
        [Owner("AHSAN")]
        public void Read_ReadSpecificCategory()
        {
            
        }
    }
}
