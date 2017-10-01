

namespace CRM.WebApi.Dto.ProductretailAudits.In
{
    public class ProductRetailAuditDtoIn
    {        
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public int RetailAuditFormId { get; set; }
        public string RetailAuditFormFieldValues { get; set; }
        public bool IsSaved { get; set; }
        public int ScheduleId { get; set; }
        public string PlaceRepoId { get; set; }
        public string ScheduleRepoId { get; set; }
    }
}