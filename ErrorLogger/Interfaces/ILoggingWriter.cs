using ErrorLogger.Models;
using System;

namespace ErrorLogger.Interfaces
{
    public interface ILoggingWriter
    {
        bool Exists();

        void Create();

        void Write(string loggingLevel, LoggingTypeModel.LogCategory logCategory, string error,
            DateTime dateTime);
    }
}
