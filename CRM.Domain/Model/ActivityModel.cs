using System;


namespace CRM.Domain.Model
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }       
        public int PlaceId { get; set; }
        public PlaceModel Place { get; set; }
        public string ActivityLog { get; set; }
        public int TenantId { get; set; }
        public TenantModel Tenant { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
