using ErrorLogger.BusinessLogic.Generic;
//using ErrorLogger.BusinessLogic.Sqlite;
using ErrorLogger.Entities;
using ErrorLogger.Interfaces;
using ErrorLogger.Models;
using System;
using System.Collections.Generic;

namespace ErrorLogger.Loggers
{
    public class SqliteLogger : ILogger
    {
        public LoggingLevel LoggingLevel { get; set; }

        private readonly LoggingSqlite _logger;

        public SqliteLogger()
        {
            _logger = new LoggingSqlite();

            if (!_logger.Exists())
            {
                _logger.Create();
            }
        }
        public void LogError(LoggingTypeModel.LogCategory logCategory, Exception exception)
        {
            if (!LoggingLevelEnabled.Decide(LoggingLevel).Error)
            {
                return;
            }

            _logger.Write("ERROR", logCategory, GenerateError.GetException(exception), DateTime.Now);
        }

        public void LogInfo(LoggingTypeModel.LogCategory logCategory, Exception exception)
        {
            if (!LoggingLevelEnabled.Decide(LoggingLevel).Info)
            {
                return;
            }

            _logger.Write("INFO", logCategory, GenerateError.GetException(exception), DateTime.Now);
        }

        public void LogDebug(LoggingTypeModel.LogCategory logCategory, Exception exception)
        {
            if (!LoggingLevelEnabled.Decide(LoggingLevel).Debug)
            {
                return;
            }

            _logger.Write("DEBUG", logCategory, GenerateError.GetException(exception), DateTime.Now);
        }

        public void LogError(LoggingTypeModel.LogCategory logCategory, string message)
        {
            if (!LoggingLevelEnabled.Decide(LoggingLevel).Error)
            {
                return;
            }

            _logger.Write("ERROR", logCategory, AllowedCharacters.Replace(message), DateTime.Now);
        }

        public void LogInfo(LoggingTypeModel.LogCategory logCategory, string message)
        {
            if (!LoggingLevelEnabled.Decide(LoggingLevel).Info)
            {
                return;
            }

            _logger.Write("INFO", logCategory, AllowedCharacters.Replace(message), DateTime.Now);
        }

        public void LogDebug(LoggingTypeModel.LogCategory logCategory, string message)
        {
            if (!LoggingLevelEnabled.Decide(LoggingLevel).Debug)
            {
                return;
            }

            _logger.Write("DEBUG", logCategory, AllowedCharacters.Replace(message), DateTime.Now);
        }

        public IReadOnlyCollection<Error> ReadLog()
        {
            throw new NotImplementedException();
        }
    }
}
