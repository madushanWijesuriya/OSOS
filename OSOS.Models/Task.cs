using System;


namespace OSOS.Models
{
    public class Task
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EstimatedWorkingDays { get; set; }
    }
}
