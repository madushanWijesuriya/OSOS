using OSOS.Models;
using System;
using System.Collections.Generic;


namespace OSOS.Services.Interfaces
{
    public interface IWorkingDayStrategy
    {
        DateTime CalculateEndDate(DateTime startDate, int estimatedWorkingDays, List<PublicHoliday> publicHolidays);
    }
}
