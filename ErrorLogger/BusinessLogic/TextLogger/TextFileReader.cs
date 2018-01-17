using CsvHelper;
using ErrorLogger.BusinessLogic.Configuration;
using ErrorLogger.Entities;
using ErrorLogger.Interfaces;
using ErrorLogger.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ErrorLogger.BusinessLogic.TextLogger
{
    public class TextFileReader : ILogReader
    {
        private readonly LoggerConfig _config;

        public TextFileReader()
        {
            _config = new ConfigurationHandler().Read();
        }

        public IReadOnlyCollection<Error> Read()
        {
            var fs = new FileStream(_config.Text.FileInformation.LogFileLocation + "\\" +
                                    _config.Text.FileInformation.LogFileName, FileMode.Open, FileAccess.Read,
                FileShare.ReadWrite);

            var csv = new CsvReader(new StreamReader(fs));

            //csv.Configuration.QuoteAllFields = true;
            csv.Configuration.HasHeaderRecord = true;

            var errorLog = csv.GetRecords<Error>();

            var logFile = errorLog.Select(error => new Error
            {
                LoggingLevel = error.LoggingLevel,
                ErrorType = error.ErrorType,
                Message = error.Message,
                DateTimeUTC = Convert.ToDateTime(error.DateTimeUTC)
            }).ToList();

            fs.Close();

            return logFile;
        }

        public IReadOnlyCollection<Error> ReadBetweenDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Error> ReadMaxRecordCount(int recordCount)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Error> ReadSpecificCategory(LoggingTypeModel.LogCategory category)
        {
            throw new NotImplementedException();
        }
    }
}