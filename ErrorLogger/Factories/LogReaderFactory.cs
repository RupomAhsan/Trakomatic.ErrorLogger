using ErrorLogger.BusinessLogic.Configuration;
using ErrorLogger.BusinessLogic.Sql;
using ErrorLogger.BusinessLogic.TextLogger;
using ErrorLogger.Interfaces;
using ErrorLogger.Models;
using System;
//using ErrorLogger.BusinessLogic.Sqlite;

namespace ErrorLogger.Factories
{
    internal class LogReaderFactory
    {
        private readonly LoggerConfig _config = new ConfigurationHandler().Read();

        internal ILogReader GetLogReaderRepository()
        {
            ILogReader repo = null;
            switch (_config.LoggerType)
            {
                case LoggingTypeModel.LogOutputType.TextFile:
                    repo = new TextFileReader();
                    break;
                case LoggingTypeModel.LogOutputType.SQL:
                    repo = new SqlReader();
                    break;
                //case LoggingTypeModel.LogOutputType.SQLite:
                //    repo = new SqliteReader();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return repo;
        }
    }
}
