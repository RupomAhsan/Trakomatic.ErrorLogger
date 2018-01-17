using ErrorLogger.BusinessLogic.Configuration;
using ErrorLogger.BusinessLogic.TextLogger;
using ErrorLogger.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ErrorLogger.UnitTests
{
    [TestClass]
    public class UnitTestsTextFile
    {
        private LoggerConfig _config;

        [TestInitialize]
        public void InitialiseTests()
        {
            _config = new ConfigurationHandler().Read();

            _config.LoggerType = LoggingTypeModel.LogOutputType.TextFile;

            new ConfigurationHandler().Write(_config);

            if (_config.LoggerType != LoggingTypeModel.LogOutputType.TextFile)
            {
                throw new Exception("Set the logger type to TextFile in the Config file before running these tests.");
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            //If tests have failed, cleanup residual files.
            //var fileInfo = new FileInfo("D:\\Tests\\Logger\\Activity.log");
            //fileInfo.Delete();
        }

        [TestMethod]
        [Priority(1)]
        [Owner("AHSAN")]
        public void LogError()
        {
            try
            {
                throw new Exception("ErrorLogger", new Exception("This is my inner exception, and it contains a comma!"));
            }
            catch (Exception exception)
            {
                Logger.LogError(LoggingTypeModel.LogCategory.Process, exception);

                var loggerConfig = _config.Text;

                //Check that the log file exists with text inside
                var fileInfo = new FileInfo(loggerConfig.FileInformation.LogFileLocation + "\\" + loggerConfig.FileInformation.LogFileName);
                Assert.IsTrue(fileInfo.Exists);

                var streamReader = new StreamReader(fileInfo.FullName);
                Assert.IsNotNull(streamReader.ReadToEnd());
                streamReader.Close();

                //File.Delete(fileInfo.FullName);
            }
        }

        [TestMethod]
        [Priority(1)]
        [Owner("AHSAN")]
        public void LogErrorWithNullInnerException()
        {
            try
            {
                throw new Exception("ErrorLogger");
            }
            catch (Exception exception)
            {
                Logger.LogError(LoggingTypeModel.LogCategory.Process, exception);

                var loggerConfig = _config.Text;

                //Check that the log file exists with text inside
                var fileInfo = new FileInfo(loggerConfig.FileInformation.LogFileLocation + "\\" + loggerConfig.FileInformation.LogFileName);

                Assert.IsTrue(fileInfo.Exists);

                var streamReader = new StreamReader(fileInfo.FullName);
                var errorText = streamReader.ReadToEnd();
                streamReader.Close();

                Assert.IsNotNull(errorText);
                //Assert.That(!errorText.Contains("InnerException"));

                //File.Delete(fileInfo.FullName);
            }
        }

        [TestMethod]
        [Priority(1)]
        [Owner("AHSAN")]
        [Description("")]
        public void LogInfo()
        {
            try
            {
                throw new Exception("ErrorLogger", new Exception("This is my inner exception"));
            }
            catch (Exception exception)
            {
                Logger.LogInfo(LoggingTypeModel.LogCategory.Process, exception);

                //Check that the log file exists with text inside
                var loggerConfig = _config.Text;

                var fileInfo = new FileInfo(loggerConfig.FileInformation.LogFileLocation + "\\" + loggerConfig.FileInformation.LogFileName);
                Assert.IsTrue(fileInfo.Exists);

                var streamReader = new StreamReader(fileInfo.FullName);
                Assert.IsNotNull(streamReader.ReadToEnd());
                streamReader.Close();

                //File.Delete(fileInfo.FullName);
            }
        }

        [TestMethod]
        [Priority(1)]
        [Owner("AHSAN")]
        public void LogDebug()
        {
            try
            {
                throw new Exception("ErrorLogger", new Exception("This is my inner exception"));
            }
            catch (Exception exception)
            {
                Logger.LogDebug(LoggingTypeModel.LogCategory.Process, exception);

                var loggerConfig = _config.Text;

                //Check that the log file exists with text inside
                var fileInfo = new FileInfo(loggerConfig.FileInformation.LogFileLocation + "\\" + loggerConfig.FileInformation.LogFileName);
                Assert.IsTrue(fileInfo.Exists);

                var streamReader = new StreamReader(fileInfo.FullName);
                Assert.IsNotNull(streamReader.ReadToEnd());
                streamReader.Close();

                //File.Delete(fileInfo.FullName);
            }
        }

        [TestMethod]
        [Priority(1)]
        [Owner("AHSAN")]
        public void Read()
        {
            var log = Logger.Read();
            Assert.IsNotNull(log);
            Assert.IsTrue(log.Count > 0);
        }

        [TestMethod]
        [Priority(1)]
        [Owner("AHSAN")]
        public void PurgeArchive()
        {
            var logger = new Archive();
            logger.Purge();
        }
    }
}