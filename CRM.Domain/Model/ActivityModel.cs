using System;

namespace CRM.Domain.Model
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public string SyncId { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }       
        public int PlaceId { get; set; }
        public PlaceModel Place { get; set; }
        public string ActivityLog { get; set; }
        public string ActivityTypeId { get; set; }
        public int TenantId { get; set; }
        public TenantModel Tenant { get; set; }
        public FormValueModel FormValue { get; set; }
        public PhotoModel Photo { get; set; }
        public NoteModel Note { get; set; }
        public ProductRetailAuditModel ProductRetailAudit { get; set; }
        public OrderModel Order { get; set; }        
        public DateTime AddedDate { get; set; }
        public DateTime DateCreated { get; set; }
        public int? FormCount { get; set; }
        public int? NoteCount { get; set; }
        public int? RetailAuditCount { get; set; }
        public int? OrderCount { get; set; }
        public int? PhotoCount { get; set; }
        public int? TotalVisitCount { get; set; }
        public int? ScheduledVisitCount { get; set; }
        public int? UnScheduledVisitCount { get; set; }
        public int? MissedVisitCount { get; set; }
        public int? VisitCount { get; set; }
        public string OrderTotal { get; set; }
    }
}
