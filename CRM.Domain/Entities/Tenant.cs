

using CRM.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities
{
    public class Tenant : BaseEntity<int>
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(1000)]
        public string Name { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(2000)]
        public string Address { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string WebSite { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string ContactPerson { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string ContactNumber { get; set; }
    }
}
