using OSOS.Models;
using OSOS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OSOS.Services
{
    public class WeekendAndHolidayExclusionStrategy : IWorkingDayStrategy
    {
        public DateTime CalculateEndDate(DateTime startDate, int estimatedWorkingDays, List<PublicHoliday> publicHolidays)
        {
            var  endDate = startDate;
            var remainingWorkingDays = estimatedWorkingDays;

            while (remainingWorkingDays > 0)
            {
                endDate = endDate.AddDays(1);
                if (endDate.DayOfWeek != DayOfWeek.Saturday && endDate.DayOfWeek != DayOfWeek.Sunday && !publicHolidays.Any(holiday => holiday.Date == endDate))
                {
                    remainingWorkingDays--;
                }
            }

            return endDate;
        }
    }
}
