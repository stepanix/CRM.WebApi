using System;


namespace CRM.WebApi.Dto.VisitLogs.In
{
    public class VisitLogDtoIn
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}