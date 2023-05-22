using OSOS.Models;
using System.Collections.Generic;


namespace OSOS.Services.Interfaces
{
    public interface IPublicHolydayRepository
    {
        public List<PublicHoliday> AllPublicHolidays();
    }
}
