using System;
using ErrorLogger.Entities;
using System.Collections.Generic;
using ErrorLogger.Models;

namespace ErrorLogger.Interfaces
{
    public interface ILogReaderV2
    {
        IReadOnlyCollection<Error> ReadMaxRecordCount(int recordCount);

        IReadOnlyCollection<Error> ReadBetweenDates(DateTime startDate, DateTime endDate);

        IReadOnlyCollection<Error> ReadSpecificCategory(LoggingTypeModel.LogCategory category);
    }
}
