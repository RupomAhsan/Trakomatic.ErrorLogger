﻿using ErrorLogger.BusinessLogic.Configuration;
using ErrorLogger.Entities;
using ErrorLogger.Interfaces;
using ErrorLogger.Models;
using System;
using System.Linq;

namespace ErrorLogger.BusinessLogic.Sql
{
    internal class LoggingSql : ILoggingWriter, ILoggingPurge
    {
        private readonly ErrorLoggerEntities _context;

        public LoggingSql()
        {
            _context = new ErrorLoggerEntities(new SqlConnectionBuilder().ConnectionString().ToString());
        }

        public bool Exists()
        {
            return _context.Database.Exists();
        }

        public void Create()
        {
            _context.Database.CreateIfNotExists();
            _context.SaveChanges();
        }

        public void Write(string loggingLevel, LoggingTypeModel.LogCategory logCategory, string error, DateTime dateTime)
        {
            var sqlError = new Error
            {
                LoggingLevel = loggingLevel,
                DateTimeUTC = dateTime,
                ErrorType = logCategory.ToString(),
                Message = error
            };

            _context.Errors.Add(sqlError);
            _context.SaveChanges();
        }

        public void Purge()
        {
            var config = new ConfigurationHandler().Read().Sql;

            if (config.LoggerInformation.HistoryToKeep == 0)
            {
                return;
            }

            var calculatedPurgeDate = DateTime.Now.AddDays(-config.LoggerInformation.HistoryToKeep.Value);

            var recordsToPurge = _context.Errors.Where(dt => dt.DateTimeUTC < calculatedPurgeDate).ToList();

            _context.Errors.RemoveRange(recordsToPurge);
            _context.SaveChanges();
        }
    }
}