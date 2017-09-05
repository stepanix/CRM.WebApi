using System;

namespace CRM.WebApi.Dto.Schedules.In
{
    public class ScheduleDtoIn
    {
        public int PlaceId { get; set; }
        public string UserId { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime? VisitTime { get; set; }
        public string VisitNote { get; set; }
        public bool IsRecurring { get; set; }
        public int? RepeatCycle { get; set; }
        public bool IsVisited { get; set; }
        public bool IsScheduled { get; set; }
    }
}