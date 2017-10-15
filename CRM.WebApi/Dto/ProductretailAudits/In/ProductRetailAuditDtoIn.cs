

namespace CRM.WebApi.Dto.ProductretailAudits.In
{
    public class ProductRetailAuditDtoIn
    {        
        public int Id { get; set; }
        public string SyncId { get; set; }
        public int PlaceId { get; set; }
        public int RetailAuditFormId { get; set; }
        public string RetailAuditFormFieldValues { get; set; }
        public bool IsSaved { get; set; }
        public int ScheduleId { get; set; }
        public string PlaceRepoId { get; set; }
        public string ScheduleRepoId { get; set; }
        public bool? Available { get; set; }
        public bool? Promoted { get; set; }
        public double? Price { get; set; }
        public double? StockLevel { get; set; }
        public string Note { get; set; }
    }
}