using CRM.Domain.Entity.Base;
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
    }
}
