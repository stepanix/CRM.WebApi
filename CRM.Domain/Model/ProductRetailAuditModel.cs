using System;

namespace CRM.Domain.Model
{
    public class ProductRetailAuditModel
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public PlaceModel Place { get; set; }
        public int RetailAuditFormId { get; set; }
        public RetailAuditFormModel RetailAuditForm { get; set; }
        public string RetailAuditFormFieldValues { get; set; }
        public bool IsSaved { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
