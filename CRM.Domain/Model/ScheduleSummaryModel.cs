

namespace CRM.Domain.Model
{
    public class ScheduleSummaryModel
    {
        public int? TotalVisitCount { get; set; }
        public int? ScheduledCount { get; set; }
        public int? VisitCount { get; set; }
        public int? UnscheduledCount { get; set; }
        public int? MissedCount { get; set; }
    }
}
