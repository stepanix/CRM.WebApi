using CRM.Domain.Entity.Base;
using CRM.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class RetailAuditForm : BaseEntity<int>
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string Name { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(2000)]
        public string Description { get; set; }
        public bool? Available { get; set; }
        public bool? Promoted { get; set; }
        public decimal? Price { get; set; }
        public int? StockLevel { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(2000)]
        public string Note { get; set; }
        public string Fields { get; set; }
        [Required]
        [ForeignKey("CreatorUser")]
        public string CreatorUserId { get; set; }
        [Required]
        [ForeignKey("LastModifierUser")]
        public string LastModifierUserId { get; set; }
        public User LastModifierUser { get; set; }
        public User CreatorUser { get; set; }
        [Required]
        [ForeignKey("Tenant")]
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
