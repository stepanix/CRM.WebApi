using CRM.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string Name { get; set; }
    }
}
