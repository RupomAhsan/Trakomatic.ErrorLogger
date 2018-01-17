using ErrorLogger.Entities;
using ErrorLogger.Factories;
using ErrorLogger.Interfaces;
using ErrorLogger.Models;
using System;
using System.Collections.Generic;

namespace ErrorLogger
{
    public static class Logger
    {
        private static readonly ILogger LoggerInterface;
        private static readonly ILogReader LogReader;

        static Logger()
        {
            var loggerFactory = new LoggerFactory();
            LoggerInterface = loggerFactory.GetLoggerRepository();

            var logReaderFactory = new LogReaderFactory();
            LogReader = logReaderFactory.GetLogReaderRepository();
        }

        /// <summary>
        /// Logs a new record to the Log Store as a type Error with the given exception.
        /// </summary>
        /// <param name="logCategory"></param>
        /// <param name="exception"></param>
        public static void LogError(LoggingTypeModel.LogCategory logCategory, Exception exception)
        {
            try
            {
                Console.WriteLine($"{DateTime.Now} - {logCategory} - {exception}");
                LoggerInterface.LogError(logCategory, exception);
            }
            catch(Exception ex)
            {
            }
        }

        /// <summary>
        /// Logs a new record to the Log Store as a type Error with the given exception.
        /// </summary>
        /// <param name="logCategory"></param>
        /// <param name="exception"></param>
        public static void LogInfo(LoggingTypeModel.LogCategory logCategory, Exception exception)
        {
            try
            {
                Console.WriteLine($"{DateTime.Now} - {logCategory} - {exception}");
                LoggerInterface.LogInfo(logCategory, exception);
            }
            catch
            {
            }

        }

        /// <summary>
        /// Logs a new record to the Log Store as a type Error with the given exception.
        /// </summary>
        /// <param name="logCategory"></param>
        /// <param name="exception"></param>
        public static void LogDebug(LoggingTypeModel.LogCategory logCategory, Exception exception)
        {
            try
            {
                Console.WriteLine($"{DateTime.Now} - {logCategory} - {exception}");
                LoggerInterface.LogDebug(logCategory, exception);
            }
            catch
            {
            }

        }

        /// <summary>
        /// Logs a new record to the Log Store as a type Error with the given String Message.
        /// </summary>
        /// <param name="logCategory"></param>
        /// <param name="message"></param>
        public static void LogError(LoggingTypeModel.LogCategory logCategory, string message)
        {
            try
            {
                Console.WriteLine($"{DateTime.Now} - {logCategory} - {message}");
                LoggerInterface.LogError(logCategory, message);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Logs a new record to the Log Store as a type Error with the given String Message.
        /// </summary>
        /// <param name="logCategory"></param>
        /// <param name="message"></param>
        public static void LogInfo(LoggingTypeModel.LogCategory logCategory, string message)
        {
            try
            {
                Console.WriteLine($"{DateTime.Now} - {logCategory} - {message}");
                LoggerInterface.LogInfo(logCategory, message);
            }
            catch
            {
            }

        }

        /// <summary>
        /// Logs a new record to the Log Store as a type Error with the given String Message.
        /// </summary>
        /// <param name="logCategory"></param>
        /// <param name="message"></param>
        public static void LogDebug(LoggingTypeModel.LogCategory logCategory, string message)
        {
            try
            {
                Console.WriteLine($"{DateTime.Now} - {logCategory} - {message}");
                LoggerInterface.LogDebug(logCategory, message);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Reads all Logged Errors from the Log Store.
        /// </summary>
        /// <returns>IReadonlyCollection</returns>
        public static IReadOnlyCollection<Error> Read()
        {
            try
            {
                return LogReader.Read();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Reads the Last X Logged Errors from the Log Store ordered by Date and Time Logged in Descending order.  Not available if using the TextFile logger.
        /// </summary>
        /// <param name="recordCount"></param>
        /// <returns>IReadOnlyCollection</returns>
        public static IReadOnlyCollection<Error> Read(int recordCount)
        {
            try
            {
                return LogReader.ReadMaxRecordCount(recordCount);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Read all Logged Errors between given Dates and Times. Not available if using the TextFile logger.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>IReadOnlyCollection</returns>
        public static IReadOnlyCollection<Error> Read(DateTime startDate, DateTime endDate)
        {
            var log = LogReader.ReadBetweenDates(startDate, endDate);

            return log;
        }

        /// <summary>
        /// Returns all Logged Errors by given Log Category Type.  Not available if using the TextFile logger.
        /// </summary>
        /// <param name="logCategory"></param>
        /// <returns>IReadOnlyCollection</returns>
        public static IReadOnlyCollection<Error> Read(LoggingTypeModel.LogCategory logCategory)
        {
            var log = LogReader.ReadSpecificCategory(logCategory);

            return log;
        }
    }
}