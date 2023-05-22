using Microsoft.AspNetCore.Mvc;
using OSOS.Services.Interfaces;
using System;


namespace OSOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private IPublicHolydayRepository _publicHolidayService;
        private IWorkingDayStrategy _workingDayStrategy;

        public TasksController(IPublicHolydayRepository publicHolidayRepository, IWorkingDayStrategy workingDayStrategy)
        {
            _publicHolidayService = publicHolidayRepository;
            _workingDayStrategy = workingDayStrategy; 
        }
        [HttpGet("getCompletionDate")]
        public IActionResult CalculateEndDate(DateTime startDate, int estimateDate)
        {
            var publicHoliDays = _publicHolidayService.AllPublicHolidays();
            var endDate = _workingDayStrategy.CalculateEndDate(startDate, estimateDate, publicHoliDays);
            return Ok(endDate);
        }
    }
}