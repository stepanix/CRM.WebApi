using System;

namespace CRM.WebApi.Dto.Schedules.In
{
    public class ScheduleDtoIn
    {
        public int PlaceId { get; set; }
        
        public DateTime VisitDate { get; set; }
       
        public DateTime VisitTime { get; set; }
        
        public string Recurring { get; set; }
        
        public string VisitNote { get; set; }
    }
}