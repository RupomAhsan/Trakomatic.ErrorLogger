using ErrorLogger.Entities;
using ErrorLogger.Models;
using System;
using System.Collections.Generic;

namespace ErrorLogger.Interfaces
{
    public interface ILogReader
    {
        IReadOnlyCollection<Error> Read();
        IReadOnlyCollection<Error> ReadMaxRecordCount(int recordCount);
        IReadOnlyCollection<Error> ReadBetweenDates(DateTime startDate, DateTime endDate);
        IReadOnlyCollection<Error> ReadSpecificCategory(LoggingTypeModel.LogCategory category);

    }
}
