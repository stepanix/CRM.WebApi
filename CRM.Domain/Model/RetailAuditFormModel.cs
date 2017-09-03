using System;

namespace CRM.Domain.Model
{
    public class RetailAuditFormModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Available { get; set; }
        public bool? Promoted { get; set; }
        public decimal? Price { get; set; }
        public int? StockLevel { get; set; }
        public string Note { get; set; }
        public string Fields { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatorUserId { get; set; }
        public string LastModifierUserId { get; set; }
        public int TenantId { get; set; }
    }
}
