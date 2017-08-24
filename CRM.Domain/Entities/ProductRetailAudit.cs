using CRM.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class ProductRetailAudit : BaseEntity<int>
    {
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        [ForeignKey("RetailAuditForm")]
        public int RetailAuditFormId { get; set; }
        public RetailAuditForm RetailAuditForm { get; set; }
        public string RetailAuditFormFieldValues { get; set; }
        public bool IsSaved { get; set; }
    }
}
