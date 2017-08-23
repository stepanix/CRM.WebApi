using System;


namespace CRM.Domain.Model
{
    public class ScheduleModel
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public PlaceModel Place { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime VisitTime { get; set; }        
        public string Recurring { get; set; }
        public string VisitNote { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
