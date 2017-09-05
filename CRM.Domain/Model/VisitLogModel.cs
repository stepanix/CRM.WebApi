using System;


namespace CRM.Domain.Model
{
    public class VisitLogModel
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }        
        public string CreatorUserId { get; set; }
        public string LastModifierUserId { get; set; }
        public UserModel LastModifierUser { get; set; }
        public UserModel CreatorUser { get; set; }
        public int TenantId { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
