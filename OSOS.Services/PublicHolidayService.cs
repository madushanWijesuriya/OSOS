using OSOS.Models;
using OSOS.Services.Interfaces;
using System;
using System.Collections.Generic;


namespace OSOS.Services
{
    public class PublicHolidayService : IPublicHolydayRepository
    {
        public List<PublicHoliday> AllPublicHolidays()
        {
            List<PublicHoliday> publicHolidays = new List<PublicHoliday>
        {
            new PublicHoliday { Date = new DateTime(2023, 5, 23) },
            new PublicHoliday { Date = new DateTime(2023, 5, 25) },
            // Add more public holidays as needed
        };

            return publicHolidays;
        }
    }
}
